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
using Librame.Extensions.Core;

namespace Librame.AspNetCore.Themepack;

class InternalThemeResolver : IThemeResolver
{
    private readonly WebExtensionOptions _options;

    private List<IThemeInfo>? _infos;


    public InternalThemeResolver(WebExtensionOptions options)
    {
        _options = options;
    }


    public IReadOnlyList<IThemeInfo> ResolveInfos()
    {
        if (_infos is null)
        {
            var infoTypes = AssemblyLoader.LoadConcreteTypes(typeof(IThemeInfo),
                _options.Theme.AssemblyLoading);

            if (infoTypes is null || infoTypes.Length < 1)
                throw new DllNotFoundException($"The themepack assembly implementing {nameof(IThemeInfo)} was not found, please confirm that any themepack is installed.");

            _infos = infoTypes.Select(s => (IThemeInfo)s.NewByExpression()).ToList();
            _infos.Sort();
        }

        return _infos;
    }

}
