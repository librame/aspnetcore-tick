#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.Extensions.Core.Plugins;

namespace Librame.AspNetCore.Themepack;

/// <summary>
/// 定义抽象实现 <see cref="IThemeInfo"/> 的主题信息。
/// </summary>
public abstract class AbstractThemeInfo : AbstractPluginInfo, IThemeInfo
{
    private IReadOnlyDictionary<string, string>? _layoutRazorPaths;


    /// <summary>
    /// 公共布局 Razor 路径。
    /// </summary>
    public virtual string CommonLayoutRazorPath
        => GetLayoutRazorPath(LayoutKeys.Common);

    /// <summary>
    /// 登入布局 Razor 路径。
    /// </summary>
    public virtual string LoginLayoutRazorPath
        => GetLayoutRazorPath(LayoutKeys.Login);

    /// <summary>
    /// 管理布局 Razor 路径。
    /// </summary>
    public virtual string ManageLayoutRazorPath
        => GetLayoutRazorPath(LayoutKeys.Manage);


    /// <summary>
    /// 获取指定布局键的 Razor 路径。
    /// </summary>
    /// <param name="layoutKey">给定的布局键。</param>
    /// <returns>返回路径。</returns>
    public string GetLayoutRazorPath(string layoutKey)
    {
        if (_layoutRazorPaths is null)
            _layoutRazorPaths = GetLayoutProvider().GetRazorPaths();

        return _layoutRazorPaths[layoutKey];
    }


    /// <summary>
    /// 获取布局提供程序。
    /// </summary>
    /// <returns>返回 <see cref="ILayoutProvider"/>。</returns>
    protected abstract ILayoutProvider GetLayoutProvider();

    /// <summary>
    /// 获取静态文件提供程序。
    /// </summary>
    /// <returns>返回 <see cref="IFileProvider"/>。</returns>
    public abstract IFileProvider GetStaticFileProvider();
}
