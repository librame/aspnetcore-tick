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
/// 定义一个站点配置接口。
/// </summary>
public interface ISiteConfiguration
{
    /// <summary>
    /// 应用上下文。
    /// </summary>
    /// <value>
    /// 返回 <see cref="IApplicationContext"/>。
    /// </value>
    IApplicationContext Context { get; }
}
