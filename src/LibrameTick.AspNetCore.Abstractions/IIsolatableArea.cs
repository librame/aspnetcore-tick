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
/// 定义一个可隔离区域接口。
/// </summary>
public interface IIsolatableArea
{
    /// <summary>
    /// 区域。
    /// </summary>
    string? Area { get; }

    /// <summary>
    /// 锁定区域（表示区域能否在环境正常化中修改）。
    /// </summary>
    bool LockedArea { get; }
}
