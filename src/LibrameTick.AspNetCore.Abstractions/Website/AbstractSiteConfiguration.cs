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
/// 定义抽象实现 <see cref="ISiteConfiguration"/> 的站点配置。
/// </summary>
public abstract class AbstractSiteConfiguration : ISiteConfiguration
{
    /// <summary>
    /// 构造一个 <see cref="AbstractSiteConfiguration"/>。
    /// </summary>
    /// <param name="context">给定的 <see cref="IApplicationContext"/>。</param>
    protected AbstractSiteConfiguration(IApplicationContext context)
    {
        Context = context;
    }


    /// <summary>
    /// 应用上下文。
    /// </summary>
    /// <value>
    /// 返回 <see cref="IApplicationContext"/>。
    /// </value>
    public IApplicationContext Context { get; }
}
