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
/// 定义实现 <see cref="IStringLocalizer{TResourceBase}"/> 的主题资源字符串定位器。
/// </summary>
/// <typeparam name="TResourceBase">指定的资源基础类型。</typeparam>
public class ThemeResourceStringLocalizer<TResourceBase> : ThemeResourceStringLocalizer, IStringLocalizer<TResourceBase>
{
    /// <summary>
    /// 构造一个 <see cref="ThemeResourceStringLocalizer{TResourceBase}"/>。
    /// </summary>
    /// <param name="resourceAssembly">给定的资源程序集（可选；默认使用与资源基础类型相同的程序集）。</param>
    public ThemeResourceStringLocalizer(Assembly? resourceAssembly = null)
        : base(typeof(TResourceBase), resourceAssembly)
    {
    }

}


/// <summary>
/// 定义实现 <see cref="IStringLocalizer"/> 的主题资源字符串定位器。
/// </summary>
public class ThemeResourceStringLocalizer : PluginResourceStringLocalizer
{
    /// <summary>
    /// 构造一个 <see cref="ThemeResourceStringLocalizer"/>。
    /// </summary>
    /// <param name="resourceBaseType">给定的资源基础类型。</param>
    /// <param name="resourceAssembly">给定的资源程序集（可选；默认使用与资源基础类型相同的程序集）。</param>
    public ThemeResourceStringLocalizer(Type resourceBaseType, Assembly? resourceAssembly = null)
        : this(new ThemeResourceFactory(resourceBaseType, resourceAssembly))
    {
    }

    /// <summary>
    /// 构造一个 <see cref="ThemeResourceStringLocalizer"/>。
    /// </summary>
    /// <param name="resourceFactory">给定的 <see cref="IThemeResourceFactory"/>。</param>
    public ThemeResourceStringLocalizer(IThemeResourceFactory resourceFactory)
        : base(resourceFactory)
    {
    }

}
