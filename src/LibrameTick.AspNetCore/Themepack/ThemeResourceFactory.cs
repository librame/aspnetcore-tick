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
/// 定义实现 <see cref="IThemeResourceFactory"/> 的主题资源工厂。
/// </summary>
/// <typeparam name="TResourceBase">指定的资源基础类型。</typeparam>
public class ThemeResourceFactory<TResourceBase> : ThemeResourceFactory
{
    /// <summary>
    /// 构造一个 <see cref="ThemeResourceFactory{TResourceBase}"/>。
    /// </summary>
    /// <param name="resourceAssembly">给定的资源程序集（可选；默认使用与资源基础类型相同的程序集）。</param>
    public ThemeResourceFactory(Assembly? resourceAssembly = null)
        : base(typeof(TResourceBase), resourceAssembly)
    {
    }

}


/// <summary>
/// 定义实现 <see cref="IThemeResourceFactory"/> 的主题资源工厂。
/// </summary>
public class ThemeResourceFactory : PluginResourceFactory, IThemeResourceFactory
{
    /// <summary>
    /// 构造一个 <see cref="ThemeResourceFactory"/>。
    /// </summary>
    /// <param name="resourceBaseType">给定的资源基础类型。</param>
    /// <param name="resourceAssembly">给定的资源程序集（可选；默认使用与资源基础类型相同的程序集）。</param>
    public ThemeResourceFactory(Type resourceBaseType, Assembly? resourceAssembly = null)
        : base(resourceBaseType, resourceAssembly)
    {
    }


    /// <summary>
    /// 创建指定文化信息的主题资源。
    /// </summary>
    /// <param name="culture">给定的 <see cref="CultureInfo"/>（可选）。</param>
    /// <returns>返回 <see cref="IThemeResource"/>。</returns>
    public new IThemeResource Create(CultureInfo? culture = null)
        => (IThemeResource)base.Create(culture);

}
