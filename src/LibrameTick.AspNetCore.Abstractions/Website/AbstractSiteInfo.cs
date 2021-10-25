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

namespace Librame.AspNetCore;

/// <summary>
/// 定义抽象实现 <see cref="ISiteInfo"/> 的站点信息。
/// </summary>
public abstract class AbstractSiteInfo : AbstractPluginInfo, ISiteInfo
{
    /// <summary>
    /// 构造一个 <see cref="AbstractSiteInfo"/>。
    /// </summary>
    /// <param name="services">给定的 <see cref="IServiceProvider"/>。</param>
    protected AbstractSiteInfo(IServiceProvider services)
        : base()
    {
        Services = services;
    }


    /// <summary>
    /// 服务提供程序。
    /// </summary>
    public IServiceProvider Services { get; }
}
