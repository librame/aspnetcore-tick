#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

namespace Librame.AspNetCore.Themepack.Simple;

/// <summary>
/// 定义实现 <see cref="IThemeInfo"/> 的 Web 主题信息。
/// </summary>
public class ThemeInfo : AbstractLibrameThemeInfo
{
    /// <summary>
    /// 本地化定位器。
    /// </summary>
    public override IStringLocalizer? Localizer
        => new ThemeResourceStringLocalizer<ThemeResource>();

    /// <summary>
    /// 名称。
    /// </summary>
    public override string Name
        => nameof(Simple);


    /// <summary>
    /// 获取布局提供程序。
    /// </summary>
    /// <returns>返回 <see cref="ILayoutProvider"/>。</returns>
    protected override ILayoutProvider GetLayoutProvider()
        => new AssemblyLayoutProvider(InfoAssembly);

    /// <summary>
    /// 获取静态文件提供程序。
    /// </summary>
    /// <remarks>
    /// 通常是包含“wwwroot”静态资源文件的嵌入程序集。
    /// </remarks>
    /// <returns>返回 <see cref="IFileProvider"/>。</returns>
    public override IFileProvider GetStaticFileProvider()
        => new ManifestEmbeddedFileProvider(InfoAssembly, "wwwroot");
}
