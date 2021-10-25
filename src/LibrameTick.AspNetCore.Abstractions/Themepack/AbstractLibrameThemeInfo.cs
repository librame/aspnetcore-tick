#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

namespace Librame.AspNetCore.Themepack;

/// <summary>
/// 定义抽象实现 <see cref="IThemeInfo"/> 的 Librame 主题信息。
/// </summary>
public abstract class AbstractLibrameThemeInfo : AbstractThemeInfo
{
    /// <summary>
    /// 作者集合。
    /// </summary>
    public override string? Authors
        => "Librame Pong";

    /// <summary>
    /// 联系。
    /// </summary>
    public override string? Contact
        => InfoAssembly.GetCustomAttribute<AssemblyMetadataAttribute>()?.Value; // RepositoryUrl
}
