#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.AspNetCore.Themepack;
using Librame.Extensions.Core;

namespace Librame.AspNetCore;

/// <summary>
/// 定义实现 <see cref="IExtensionOptions"/> 的 Web 扩展选项。
/// </summary>
public class WebExtensionOptions : AbstractExtensionOptions<WebExtensionOptions>
{
    /// <summary>
    /// 默认文化信息数组。
    /// </summary>
    public static readonly CultureInfo[] DefaultCultureInfos = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("zh-CN"),
        new CultureInfo("zh-TW")
    };


    /// <summary>
    /// 构造一个 <see cref="WebExtensionOptions"/>。
    /// </summary>
    public WebExtensionOptions()
    {
        Theme = new(Notifier);
        GenericApplicationModel = new(Notifier);
        RequestLocalization = new();

        // RequestLocalization
        RequestLocalization.DefaultRequestCulture = new RequestCulture(DefaultCultureInfos[1]);
        RequestLocalization.SupportedCultures = DefaultCultureInfos;
        RequestLocalization.SupportedUICultures = DefaultCultureInfos;

        // RequestLocalization: Add RouteData
        RequestLocalization.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider
        {
            Options = RequestLocalization
        });
    }


    /// <summary>
    /// 主题。
    /// </summary>
    public ThemeOptions Theme { get; init; }

    /// <summary>
    /// 泛型应用模型。
    /// </summary>
    public GenericApplicationModelOptions GenericApplicationModel { get; init; }

    /// <summary>
    /// 请求本地化。
    /// </summary>
    [JsonIgnore]
    public RequestLocalizationOptions RequestLocalization { get; init; }


    /// <summary>
    /// 激活视图键名。
    /// </summary>
    public string ActiveViewKey
    {
        get => Notifier.GetOrAdd(nameof(ActiveViewKey), "ActiveView");
        set => Notifier.AddOrUpdate(nameof(ActiveViewKey), value);
    }

    /// <summary>
    /// 默认用户头像路径。
    /// </summary>
    public string DefaultUserPortraitPath
    {
        get => Notifier.GetOrAdd(nameof(DefaultUserPortraitPath), "portraits/default.png");
        set => Notifier.AddOrUpdate(nameof(DefaultUserPortraitPath), value);
    }

    /// <summary>
    /// 有外部认证方案的键名。
    /// </summary>
    public string HasExternalAuthenticationSchemesKey
    {
        get => Notifier.GetOrAdd(nameof(HasExternalAuthenticationSchemesKey), $"{typeof(WebExtensionOptions).Namespace}.HasExternalLogins");
        set => Notifier.AddOrUpdate(nameof(HasExternalAuthenticationSchemesKey), value);
    }

    /// <summary>
    /// 支持泛型控制器。
    /// </summary>
    public bool SupportedGenericController { get; private set; }

    ///// <summary>
    ///// 断定身份导航（默认使用“Identity”模块导航）。
    ///// </summary>
    //[JsonIgnore]
    //public Func<IProjectNavigation, bool> PredicateIdentityNavigation { get; set; }
    //    = nav => (bool)nav.Area?.Equals("Identity", StringComparison.OrdinalIgnoreCase);

    ///// <summary>
    ///// 查找应用程序集模式列表。
    ///// </summary>
    //public List<string> SearchApplicationAssemblyPatterns { get; } = new()
    //{
    //    $@"^{nameof(Librame)}.{nameof(AspNetCore)}.(\w+).{nameof(Web)}$"
    //};

}
