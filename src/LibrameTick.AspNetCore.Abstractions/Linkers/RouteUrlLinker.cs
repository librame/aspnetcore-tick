#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

namespace Librame.AspNetCore.Linkers;

/// <summary>
/// 定义实现 <see cref="ILinker"/> 的路由 URL 链接器。
/// </summary>
public abstract class RouteUrlLinker : AbstractLinker, IEquatable<RouteUrlLinker>
{
    /// <summary>
    /// 构造一个 <see cref="RouteUrlLinker"/>。
    /// </summary>
    /// <param name="id">给定的参数（可选）。</param>
    protected RouteUrlLinker(string? id = null, string? area = null, bool lockedArea = true)
    {
        Id = id;
        Area = area;
        LockedArea = lockedArea;
    }

    //string? routeName, object? values

    /// <summary>
    /// 参数。
    /// </summary>
    public string? Id { get; internal set; }


    ///// <summary>
    ///// 是指定视图名称。
    ///// </summary>
    ///// <param name="compare">给定的 <see cref="RouteUrlLinker"/>。</param>
    ///// <returns>返回布尔值。</returns>
    //public virtual bool IsViewName(RouteUrlLinker compare)
    //    => IsViewName(compare.GetViewName());UrlHelperExtensions

    ///// <summary>
    ///// 是指定视图名称。
    ///// </summary>
    ///// <param name="viewName">给定的视图名称。</param>
    ///// <returns>返回布尔值。</returns>
    //public virtual bool IsViewName(string viewName)
    //    => GetViewName().Equals(viewName, StringComparison.OrdinalIgnoreCase);

    ///// <summary>
    ///// 获取视图名称。
    ///// </summary>
    ///// <returns>返回字符串。</returns>
    //public abstract string GetViewName();


    /// <summary>
    /// 是否相等。
    /// </summary>
    /// <param name="other">给定的 <see cref="RouteUrlLinker"/>。</param>
    /// <returns>返回布尔值。</returns>
    public bool Equals(RouteUrlLinker? other)
        => ToString().Equals(other?.ToString(), StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// 是否相等。
    /// </summary>
    /// <param name="obj">给定的对象。</param>
    /// <returns>返回布尔值。</returns>
    public override bool Equals(object? obj)
        => obj is RouteUrlLinker other && Equals(other);


    /// <summary>
    /// 获取哈希码。
    /// </summary>
    /// <returns>返回整数。</returns>
    public override int GetHashCode()
        => ToString().GetHashCode(StringComparison.InvariantCulture);


    /// <summary>
    /// 转换为字符串。
    /// </summary>
    /// <returns>返回模拟链接字符串。</returns>
    public override string ToString()
        => GenerateSimulativeLink();

}
