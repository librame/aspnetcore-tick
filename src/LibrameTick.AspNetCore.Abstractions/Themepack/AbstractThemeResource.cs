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
/// 定义抽象实现 <see cref="IThemeResource"/> 的主题资源。
/// </summary>
public abstract class AbstractThemeResource : AbstractPluginResource, IThemeResource
{
    /// <summary>
    /// 构造一个 <see cref="AbstractThemeResource"/>。
    /// </summary>
    /// <param name="resourceName">给定的主题资源名称。</param>
    protected AbstractThemeResource(string resourceName)
        : base(resourceName)
    {
    }

}
