#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.Extensions.Core;

namespace Librame.AspNetCore.Themepack;

/// <summary>
/// 定义实现 <see cref="IOptions"/> 的主题选项。
/// </summary>
public class ThemeOptions : AbstractOptionsNotifier
{
    /// <summary>
    /// 构造一个独立属性通知器的 <see cref="ThemeOptions"/>（此构造函数适用于独立使用 <see cref="ThemeOptions"/> 的情况）。
    /// </summary>
    /// <param name="sourceAliase">给定的源别名（独立属性通知器必须命名实例）。</param>
    public ThemeOptions(string sourceAliase)
        : base(sourceAliase)
    {
        AssemblyLoading = new(Notifier, nameof(Themepack));
        AssemblyLoading.FilteringDescriptors.Add(InitialThemepackFiltering());
    }

    /// <summary>
    /// 使用给定的 <see cref="IPropertyNotifier"/> 构造一个 <see cref="ThemeOptions"/>。
    /// </summary>
    /// <param name="parentNotifier">给定的父级 <see cref="IPropertyNotifier"/>。</param>
    /// <param name="sourceAliase">给定的源别名（可选）。</param>
    public ThemeOptions(IPropertyNotifier parentNotifier, string? sourceAliase = null)
        : base(parentNotifier, sourceAliase)
    {
        AssemblyLoading = new(Notifier, nameof(Themepack));
        AssemblyLoading.FilteringDescriptors.Add(InitialThemepackFiltering());
    }


    /// <summary>
    /// 程序集加载选项。
    /// </summary>
    public AssemblyLoadingOptions AssemblyLoading { get; init; }


    /// <summary>
    /// 公共布局 Cookie 授权可见性（默认可见）。
    /// </summary>
    public bool CommonCookieConsentVisibility
    {
        get => Notifier.GetOrAdd(nameof(CommonCookieConsentVisibility), true);
        set => Notifier.AddOrUpdate(nameof(CommonCookieConsentVisibility), value);
    }

    /// <summary>
    /// 公共布局底栏版权可见性（默认可见）。
    /// </summary>
    public bool CommonFooterVisibility
    {
        get => Notifier.GetOrAdd(nameof(CommonFooterVisibility), true);
        set => Notifier.AddOrUpdate(nameof(CommonFooterVisibility), value);
    }

    /// <summary>
    /// 公共布局顶栏导航可见性（默认可见）。
    /// </summary>
    public bool CommonHeaderNavigationVisibility
    {
        get => Notifier.GetOrAdd(nameof(CommonHeaderNavigationVisibility), true);
        set => Notifier.AddOrUpdate(nameof(CommonHeaderNavigationVisibility), value);
    }

    /// <summary>
    /// 公共布局本地化可见性（默认可见）。
    /// </summary>
    public bool CommonLocalizationVisibility
    {
        get => Notifier.GetOrAdd(nameof(CommonLocalizationVisibility), true);
        set => Notifier.AddOrUpdate(nameof(CommonLocalizationVisibility), value);
    }

    /// <summary>
    /// 公共布局登陆可见性（默认可见）。
    /// </summary>
    public bool CommonLoginVisibility
    {
        get => Notifier.GetOrAdd(nameof(CommonLoginVisibility), true);
        set => Notifier.AddOrUpdate(nameof(CommonLoginVisibility), value);
    }


    /// <summary>
    /// 管理布局底栏版权可见性（默认可见）。
    /// </summary>
    public bool ManageFooterVisibility
    {
        get => Notifier.GetOrAdd(nameof(ManageFooterVisibility), true);
        set => Notifier.AddOrUpdate(nameof(ManageFooterVisibility), value);
    }

    /// <summary>
    /// 管理布局登陆可见性（默认可见）。
    /// </summary>
    public bool ManageLoginVisibility
    {
        get => Notifier.GetOrAdd(nameof(ManageLoginVisibility), true);
        set => Notifier.AddOrUpdate(nameof(ManageLoginVisibility), value);
    }

    /// <summary>
    /// 管理布局侧栏导航可见性（默认可见）。
    /// </summary>
    public bool ManageSidebarVisibility
    {
        get => Notifier.GetOrAdd(nameof(ManageSidebarVisibility), true);
        set => Notifier.AddOrUpdate(nameof(ManageSidebarVisibility), value);
    }


    private static AssemblyFilteringDescriptor InitialThemepackFiltering()
    {
        // 设定主题包程序集筛选器描述符
        var filtering = new AssemblyFilteringDescriptor("ThemepackFiltering");

        // 包含 ?.AspNetCore.Themepack.? 格式的程序集名称
        filtering.Filters.Add(new FilteringRegex(@$"(\w+)\.{nameof(AspNetCore)}\.{nameof(Themepack)}\.(\w+)",
            FilteringMode.Inclusive));

        return filtering;
    }

}
