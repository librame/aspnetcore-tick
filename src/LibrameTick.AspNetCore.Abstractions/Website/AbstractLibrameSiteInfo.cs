#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

namespace Librame.AspNetCore;

/// <summary>
/// 定义抽象实现 <see cref="ISiteInfo"/> 的 Librame 站点信息。
/// </summary>
public abstract class AbstractLibrameSiteInfo : AbstractSiteInfo
{
    /// <summary>
    /// 构造一个 <see cref="AbstractLibrameSiteInfo"/>。
    /// </summary>
    /// <param name="services">给定的 <see cref="IServiceProvider"/>。</param>
    protected AbstractLibrameSiteInfo(IServiceProvider services)
        : base(services)
    {
    }


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
