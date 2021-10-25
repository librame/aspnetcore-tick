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
/// 定义实现 <see cref="IApplicationBuilder"/> 的装饰器。
/// </summary>
public class ApplicationBuilderDecorator : IApplicationBuilder
{
    private readonly IApplicationBuilder _appBuilder;


    /// <summary>
    /// 构造一个 <see cref="ApplicationBuilderDecorator"/>。
    /// </summary>
    /// <param name="appBuilder">给定的 <see cref="IApplicationBuilder"/>。</param>
    public ApplicationBuilderDecorator(IApplicationBuilder appBuilder)
    {
        _appBuilder = appBuilder;
    }


    /// <summary>
    /// 应用服务集合。
    /// </summary>
    public IServiceProvider ApplicationServices
    {
        get => _appBuilder.ApplicationServices;
        set => _appBuilder.ApplicationServices = value;
    }

    /// <summary>
    /// 服务器特性集合。
    /// </summary>
    public IFeatureCollection ServerFeatures
        => _appBuilder.ServerFeatures;

    /// <summary>
    /// 属性字典。
    /// </summary>
    public IDictionary<string, object?> Properties
        => _appBuilder.Properties;


    /// <summary>
    /// 构建应用。
    /// </summary>
    /// <returns>返回 <see cref="RequestDelegate"/>。</returns>
    public RequestDelegate Build()
        => _appBuilder.Build();

    /// <summary>
    /// 新建应用构建器。
    /// </summary>
    /// <returns>返回 <see cref="IApplicationBuilder"/>。</returns>
    public IApplicationBuilder New()
        => _appBuilder.New();

    /// <summary>
    /// 使用中间件。
    /// </summary>
    /// <param name="middleware">给定的中间件方法。</param>
    /// <returns>返回 <see cref="IApplicationBuilder"/>。</returns>
    public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        => _appBuilder.Use(middleware);

}
