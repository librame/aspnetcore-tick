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
/// 定义一个继承 <see cref="IPluginInfo"/> 的站点信息接口。
/// </summary>
public interface ISiteInfo : IPluginInfo
{
    /// <summary>
    /// 服务提供程序。
    /// </summary>
    IServiceProvider Services { get; }
}
