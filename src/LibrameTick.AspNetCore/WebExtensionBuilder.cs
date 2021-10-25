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
/// 定义实现 <see cref="IExtensionBuilder"/> 的 Web 扩展构建器。
/// </summary>
public class WebExtensionBuilder : BaseExtensionBuilder<WebExtensionBuilder, WebExtensionOptions>
{
    /// <summary>
    /// 构造一个 <see cref="WebExtensionBuilder"/>。
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="parentBuilder"/> 为空。
    /// </exception>
    /// <param name="parentBuilder">给定的父级 <see cref="IExtensionBuilder"/>。</param>
    /// <param name="setupOptions">给定用于设置选项的动作（可选；为空则不设置）。</param>
    /// <param name="configOptions">给定使用 <see cref="IConfiguration"/> 的选项配置（可选；为空则不配置）。</param>
    public WebExtensionBuilder(IExtensionBuilder parentBuilder,
        Action<WebExtensionOptions>? setupOptions = null, IConfiguration? configOptions = null)
        : base(parentBuilder, setupOptions, configOptions)
    {
        if (!Services.ContainsService<IHttpContextAccessor>())
            Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // Themepack
        ServiceCharacteristics.AddSingleton<IThemeManager>();
        ServiceCharacteristics.AddSingleton<IThemeResolver>();
    }


    //private void AddInternalServices()
    //{
    //    // Applications
    //    AddService<IApplicationContext, ApplicationContext>();

    //    // DataAnnotations
    //    Services.TryReplaceAll<IValidationAttributeAdapterProvider, ResetValidationAttributeAdapterProvider>();

    //    var oldMvcDataAnnotationsMvcOptionsSetupType = typeof(IValidationAttributeAdapterProvider).Assembly
    //        .GetType("Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcOptionsSetup");

    //    Services.TryReplaceAll(typeof(IConfigureOptions<MvcOptions>),
    //        typeof(ResetMvcDataAnnotationsMvcOptionsSetup),
    //        oldMvcDataAnnotationsMvcOptionsSetupType);

    //    // Localizers
    //    AddService(typeof(IDictionaryHtmlLocalizer<>), typeof(DictionaryHtmlLocalizer<>));
    //    AddService<IDictionaryHtmlLocalizerFactory, DictionaryHtmlLocalizerFactory>();

    //    // Projects
    //    AddService<IProjectContext, ProjectContext>();

    //    // Services
    //    AddService<ICopyrightService, CopyrightService>();
    //    AddService<IUserPortraitService, UserPortraitService>();

    //    // Themepacks
    //    AddService<IThemepackContext, ThemepackContext>();
    //}


    ///// <summary>
    ///// 获取指定服务类型的特征。
    ///// </summary>
    ///// <param name="serviceType">给定的服务类型。</param>
    ///// <returns>返回 <see cref="ServiceCharacteristics"/>。</returns>
    //public override ServiceCharacteristics GetServiceCharacteristics(Type serviceType)
    //    => WebBuilderServiceCharacteristicsRegistration.Register.GetOrDefault(serviceType);

}
