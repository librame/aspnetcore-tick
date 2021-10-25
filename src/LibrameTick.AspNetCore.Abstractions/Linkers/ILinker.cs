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
/// 定义一个链接器接口。
/// </summary>
public interface ILinker : IIsolatableArea
{
    /// <summary>
    /// 参数值集合对象。
    /// </summary>
    object? Values { get; }

    /// <summary>
    /// 协议。
    /// </summary>
    string? Protocol { get; }

    /// <summary>
    /// 主机。
    /// </summary>
    string? Host { get; }

    /// <summary>
    /// 片段。
    /// </summary>
    string? Fragment { get; }
}
