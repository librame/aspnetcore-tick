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
/// 定义一个实现 <see cref="IPluginResourceFactory"/> 的主题资源工厂接口。
/// </summary>
public interface IThemeResourceFactory : IPluginResourceFactory
{
    /// <summary>
    /// 创建指定文化信息的主题资源。
    /// </summary>
    /// <param name="culture">给定的 <see cref="CultureInfo"/>（可选）。</param>
    /// <returns>返回 <see cref="IThemeResource"/>。</returns>
    new IThemeResource Create(CultureInfo? culture = null);
}
