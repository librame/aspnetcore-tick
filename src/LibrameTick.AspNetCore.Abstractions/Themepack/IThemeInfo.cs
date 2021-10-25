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
/// 定义一个实现 <see cref="IPluginInfo"/> 的主题信息接口。
/// </summary>
public interface IThemeInfo : IPluginInfo
{
    /// <summary>
    /// 公共布局 Razor 路径。
    /// </summary>
    string CommonLayoutRazorPath { get; }

    /// <summary>
    /// 登入布局 Razor 路径。
    /// </summary>
    string LoginLayoutRazorPath { get; }

    /// <summary>
    /// 管理布局 Razor 路径。
    /// </summary>
    string ManageLayoutRazorPath { get; }


    /// <summary>
    /// 获取指定布局键的 Razor 路径。
    /// </summary>
    /// <param name="layoutKey">给定的布局键。</param>
    /// <returns>返回路径。</returns>
    string GetLayoutRazorPath(string layoutKey);


    ///// <summary>
    ///// 获取布局提供程序。
    ///// </summary>
    ///// <returns>返回 <see cref="ILayoutProvider"/>。</returns>
    //ILayoutProvider GetLayoutProvider();

    /// <summary>
    /// 获取静态文件提供程序（通常是包含“wwwroot”静态资源文件的嵌入程序集）。
    /// </summary>
    /// <returns>返回 <see cref="IFileProvider"/>。</returns>
    IFileProvider GetStaticFileProvider();
}
