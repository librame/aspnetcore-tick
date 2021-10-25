#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.AspNetCore;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// <see cref="IApplicationBuilder"/> 静态扩展。
    /// </summary>
    public static class ApplicationBuilderDecoratorExtensions
    {

        /// <summary>
        /// 使用 Librame ASP.NET 应用。
        /// </summary>
        /// <param name="appBuilder">给定的 <see cref="IApplicationBuilder"/>。</param>
        /// <returns>返回 <see cref="ApplicationBuilderDecorator"/>。</returns>
        public static ApplicationBuilderDecorator UseLibrame(this IApplicationBuilder appBuilder)
        {
            var aspAppBuilder = new ApplicationBuilderDecorator(appBuilder);
            aspAppBuilder.UseMiddleware<WebRequestLocalizationMiddleware>();

            return aspAppBuilder;
        }


        ///// <summary>
        ///// 使用控制器端点路由集合。
        ///// </summary>
        ///// <param name="decorator">给定的 <see cref="IApplicationBuilderDecorator"/>。</param>
        ///// <param name="configureAreaRoutes">给定的 <see cref="IEndpointRouteBuilder"/> 配置区域路由集合动作（可选）。</param>
        ///// <returns>返回 <see cref="IApplicationBuilderDecorator"/>。</returns>
        //public static IApplicationBuilder UseControllerEndpoints(this IApplicationBuilder decorator,
        //    Action<IEndpointRouteBuilder> configureAreaRoutes = null)
        //{
        //    decorator.NotNull(nameof(decorator));

        //    decorator.Source.UseEndpoints(routes =>
        //    {
        //        configureAreaRoutes?.Invoke(routes);

        //        routes.MapDefaultControllerRoute();
        //    });

        //    return decorator;
        //}


        ///// <summary>
        ///// 使用页面端点路由集合。
        ///// </summary>
        ///// <param name="decorator">给定的 <see cref="IApplicationBuilderDecorator"/>。</param>
        ///// <param name="configureAreaRoutes">给定的 <see cref="IEndpointRouteBuilder"/> 配置区域路由集合动作（可选）。</param>
        ///// <returns>返回 <see cref="IApplicationBuilderDecorator"/>。</returns>
        //public static IApplicationBuilderDecorator UsePagesEndpoints(this IApplicationBuilderDecorator decorator,
        //    Action<IEndpointRouteBuilder> configureAreaRoutes = null)
        //{
        //    decorator.NotNull(nameof(decorator));

        //    decorator.Source.UseEndpoints(routes =>
        //    {
        //        configureAreaRoutes?.Invoke(routes);

        //        routes.MapRazorPages();
        //    });

        //    return decorator;
        //}

    }
}
