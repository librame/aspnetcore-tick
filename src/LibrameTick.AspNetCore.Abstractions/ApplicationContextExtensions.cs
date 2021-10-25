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
/// <see cref="IApplicationContext"/> 静态扩展。
/// </summary>
public static class ApplicationContextExtensions
{
    /// <summary>
    /// 设置当前项目。
    /// </summary>
    /// <param name="context">给定的 <see cref="IApplicationContext"/>。</param>
    /// <param name="viewContext">给定的 <see cref="ViewContext"/>。</param>
    /// <returns>返回 <see cref="SiteDescriptor"/>。</returns>
    public static SiteDescriptor SetCurrentProject(this IApplicationContext context, ViewContext viewContext)
        => context.SetCurrentProject(viewContext?.HttpContext);

    /// <summary>
    /// 设置当前项目。
    /// </summary>
    /// <param name="context">给定的 <see cref="IApplicationContext"/>。</param>
    /// <param name="httpContext">给定的 <see cref="HttpContext"/>。</param>
    /// <returns>返回 <see cref="SiteDescriptor"/>。</returns>
    public static SiteDescriptor SetCurrentProject(this IApplicationContext context, HttpContext httpContext)
        => context?.Project.SetCurrent(httpContext?.GetRouteData()?.Values.AsRouteDescriptor()?.Area);

    /// <summary>
    /// 设置当前项目。
    /// </summary>
    /// <param name="context">给定的 <see cref="IApplicationContext"/>。</param>
    /// <param name="route">给定的 <see cref="AbstractRouteDescriptor"/>。</param>
    /// <returns>返回 <see cref="SiteDescriptor"/>。</returns>
    public static SiteDescriptor SetCurrentProject(this IApplicationContext context, AbstractRouteDescriptor route)
        => context?.Project.SetCurrent(route?.Area);
}
