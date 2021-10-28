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
/// 定义实现 <see cref="ILinker"/> 的 Razor 视图链接器。
/// </summary>
public abstract class RazorLinker : AbstractLinker
{
    /// <summary>
    /// 构造一个 <see cref="RazorLinker"/>。
    /// </summary>
    /// <param name="viewName">给定的视图名称（可选）。</param>
    /// <param name="values">给定的参数值集合对象（可选）。</param>
    /// <param name="protocol">给定的协议（可选）。</param>
    /// <param name="host">给定的主机（可选）。</param>
    /// <param name="fragment">给定的片段（可选）。</param>
    /// <param name="area">给定的区域（可选）。</param>
    /// <param name="lockedArea">锁定区域（默认锁定；表示区域不会在环境正常化中修改）。</param>
    protected RazorLinker(string? viewName = null, object? values = null,
        string? protocol = null, string? host = null, string? fragment = null,
        string? area = null, bool lockedArea = true)
        : base(values, protocol, host, fragment, area, lockedArea)
    {
        ViewName = viewName;
    }


    /// <summary>
    /// 视图名称。
    /// </summary>
    public string? ViewName { get; protected set; }


    /// <summary>
    /// 是指定视图名称。
    /// </summary>
    /// <param name="compare">给定的 <see cref="RazorLinker"/>。</param>
    /// <returns>返回布尔值。</returns>
    public virtual bool IsViewName(RazorLinker? compare)
        => IsViewName(compare?.ViewName);

    /// <summary>
    /// 是指定视图名称。
    /// </summary>
    /// <param name="viewName">给定的视图名称。</param>
    /// <returns>返回布尔值。</returns>
    public virtual bool IsViewName(string? viewName)
        => !string.IsNullOrEmpty(ViewName) && ViewName.Equals(viewName, StringComparison.OrdinalIgnoreCase);


    /// <summary>
    /// 转换为字符串。
    /// </summary>
    /// <returns>返回模拟链接字符串。</returns>
    public override string ToString()
        => $"{nameof(ViewName)}={ViewName};{base.ToString()}";

}
