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
/// 定义抽象实现 <see cref="IIsolatableArea"/> 的可隔离区域。
/// </summary>
public abstract class AbstractIsolatableArea : IIsolatableArea
{
    /// <summary>
    /// 构造一个 <see cref="AbstractIsolatableArea"/>。
    /// </summary>
    /// <param name="area">给定的区域（可选）。</param>
    /// <param name="lockedArea">锁定区域（默认锁定；表示区域不会在环境正常化中修改）。</param>
    protected AbstractIsolatableArea(string? area = null, bool lockedArea = true)
    {
        Area = area;
        LockedArea = lockedArea;
    }


    /// <summary>
    /// 区域。
    /// </summary>
    public string? Area { get; protected set; }

    /// <summary>
    /// 锁定区域（表示区域能否在环境正常化中修改）。
    /// </summary>
    public bool LockedArea { get; protected set; }
}
