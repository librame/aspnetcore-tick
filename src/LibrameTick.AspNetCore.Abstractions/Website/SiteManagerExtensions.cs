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

///// <summary>
///// 抽象项目上下文静态扩展。
///// </summary>
//public static class SiteManagerExtensions
//{
//    /// <summary>
//    /// 设置当前项目。
//    /// </summary>
//    /// <param name="context">给定的 <see cref="ISiteManager"/>。</param>
//    /// <param name="viewContext">给定的 <see cref="ViewContext"/>。</param>
//    /// <returns>返回 <see cref="ProjectDescriptor"/>。</returns>
//    public static ProjectDescriptor SetCurrent(this ISiteManager context, ViewContext viewContext)
//        => context.SetCurrent(viewContext?.HttpContext);

//    /// <summary>
//    /// 设置当前项目。
//    /// </summary>
//    /// <param name="context">给定的 <see cref="ISiteManager"/>。</param>
//    /// <param name="httpContext">给定的 <see cref="HttpContext"/>。</param>
//    /// <returns>返回 <see cref="ProjectDescriptor"/>。</returns>
//    public static ProjectDescriptor SetCurrent(this ISiteManager context, HttpContext httpContext)
//        => context?.SetCurrent(httpContext?.GetRouteData()?.Values.AsRouteDescriptor()?.Area);

//    /// <summary>
//    /// 设置当前项目。
//    /// </summary>
//    /// <param name="context">给定的 <see cref="ISiteManager"/>。</param>
//    /// <param name="route">给定的 <see cref="AbstractRouteDescriptor"/>。</param>
//    /// <returns>返回 <see cref="ProjectDescriptor"/>。</returns>
//    public static ProjectDescriptor SetCurrent(this ISiteManager context, AbstractRouteDescriptor route)
//        => context?.SetCurrent(route?.Area);
//}
