#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.Extensions;

namespace Librame.AspNetCore
{
    sealed class WebRequestLocalizationMiddleware
    {
        private const int MaxCultureFallbackDepth = 5;

        private readonly RequestDelegate _next;
        private readonly RequestLocalizationOptions _options;


        public WebRequestLocalizationMiddleware(RequestDelegate next, WebExtensionOptions options)
        {
            _next = next;
            _options = options.RequestLocalization;
        }


        public async Task Invoke(HttpContext context)
        {
            var requestCulture = _options.DefaultRequestCulture;

            IRequestCultureProvider? winningProvider = null;

            if (_options.RequestCultureProviders is not null)
            {
                foreach (var provider in _options.RequestCultureProviders)
                {
                    var providerResultCulture = await provider.DetermineProviderCultureResult(context).ConfigureAwait();
                    if (providerResultCulture is null)
                        continue;

                    var cultures = providerResultCulture.Cultures;
                    var uiCultures = providerResultCulture.UICultures;

                    CultureInfo? cultureInfo = null;
                    CultureInfo? uiCultureInfo = null;

                    if (_options.SupportedCultures is not null)
                    {
                        cultureInfo = GetCultureInfo(
                            cultures,
                            _options.SupportedCultures,
                            _options.FallBackToParentCultures);
                    }

                    if (_options.SupportedUICultures is not null)
                    {
                        uiCultureInfo = GetCultureInfo(
                            uiCultures,
                            _options.SupportedUICultures,
                            _options.FallBackToParentUICultures);
                    }

                    if (cultureInfo is null && uiCultureInfo is null)
                        continue;

                    if (cultureInfo is null && uiCultureInfo is not null)
                        cultureInfo = _options.DefaultRequestCulture.Culture;

                    if (cultureInfo is not null && uiCultureInfo is null)
                        uiCultureInfo = _options.DefaultRequestCulture.UICulture;

                    var result = new RequestCulture(cultureInfo!, uiCultureInfo!);
                    if (result is not null)
                    {
                        requestCulture = result;
                        winningProvider = provider;
                        break;
                    }
                }
            }

            context.Features.Set<IRequestCultureFeature>(new RequestCultureFeature(requestCulture, winningProvider));

            SetCurrentThreadCulture(requestCulture);

            await _next.Invoke(context).ConfigureAwait();
        }

        private static void SetCurrentThreadCulture(RequestCulture requestCulture)
        {
            CultureInfo.CurrentCulture = requestCulture.Culture;
            CultureInfo.CurrentUICulture = requestCulture.UICulture;
        }

        private static CultureInfo? GetCultureInfo(
            IList<StringSegment> cultureNames,
            IList<CultureInfo> supportedCultures,
            bool fallbackToParentCultures)
        {
            foreach (var cultureName in cultureNames)
            {
                if (cultureName != null)
                {
                    var cultureInfo = GetCultureInfo(cultureName, supportedCultures, fallbackToParentCultures, currentDepth: 0);
                    if (cultureInfo is not null)
                    {
                        return cultureInfo;
                    }
                }
            }

            return null;
        }

        private static CultureInfo? GetCultureInfo(StringSegment name, IList<CultureInfo> supportedCultures)
        {
            if (name == null || supportedCultures is not null)
                return null;

            var culture = supportedCultures?.FirstOrDefault(
                supportedCulture => StringSegment.Equals(supportedCulture.Name, name, StringComparison.OrdinalIgnoreCase));

            if (culture == null)
                return null;

            return CultureInfo.ReadOnly(culture);
        }

        private static CultureInfo? GetCultureInfo(
            StringSegment cultureName,
            IList<CultureInfo> supportedCultures,
            bool fallbackToParentCultures,
            int currentDepth)
        {
            var culture = GetCultureInfo(cultureName, supportedCultures);

            if (culture is null && fallbackToParentCultures && currentDepth < MaxCultureFallbackDepth)
            {
                var lastIndexOfHyphen = cultureName.LastIndexOf('-');

                if (lastIndexOfHyphen > 0)
                {
                    // Trim the trailing section from the culture name, e.g. "fr-FR" becomes "fr"
                    var parentCultureName = cultureName.Subsegment(0, lastIndexOfHyphen);

                    culture = GetCultureInfo(parentCultureName, supportedCultures, fallbackToParentCultures, currentDepth + 1);
                }
            }

            return culture;
        }
    }
}