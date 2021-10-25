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
/// 定义抽象实现 <see cref="ILinker"/> 的链接器。
/// </summary>
public abstract class AbstractLinker : AbstractIsolatableArea, ILinker
{
    /// <summary>
    /// 构造一个 <see cref="AbstractLinker"/>。
    /// </summary>
    /// <param name="values">给定的参数值集合对象（可选）。</param>
    /// <param name="protocol">给定的协议（可选）。</param>
    /// <param name="host">给定的主机（可选）。</param>
    /// <param name="fragment">给定的片段（可选）。</param>
    /// <param name="area">给定的区域（可选）。</param>
    /// <param name="lockedArea">锁定区域（默认锁定；表示区域不会在环境正常化中修改）。</param>
    protected AbstractLinker(object? values = null,
        string? protocol = null, string? host = null, string? fragment = null,
        string? area = null, bool lockedArea = true)
        : base(area, lockedArea)
    {
        Values = values;
        Protocol = protocol;
        Host = host;
        Fragment = fragment;
    }


    /// <summary>
    /// 参数值集合对象。
    /// </summary>
    public object? Values { get; protected set; }

    /// <summary>
    /// 协议。
    /// </summary>
    public string? Protocol { get; protected set; }

    /// <summary>
    /// 主机。
    /// </summary>
    public string? Host { get; protected set; }

    /// <summary>
    /// 片段。
    /// </summary>
    public string? Fragment { get; protected set; }
}
