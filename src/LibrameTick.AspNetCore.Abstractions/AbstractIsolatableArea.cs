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
public abstract class AbstractIsolatableArea : IIsolatableArea, IEquatable<IIsolatableArea>
{
    /// <summary>
    /// 默认区域名称。
    /// </summary>
    public const string DefaultAreaName = "default";


    /// <summary>
    /// 构造一个 <see cref="AbstractIsolatableArea"/>。
    /// </summary>
    /// <param name="area">给定的区域（可选；默认为 <see cref="DefaultAreaName"/>）。</param>
    /// <param name="lockedArea">锁定区域（默认锁定；表示区域不会在环境正常化中修改）。</param>
    protected AbstractIsolatableArea(string? area = null, bool lockedArea = true)
    {
        Area = area ?? DefaultAreaName;
        LockedArea = lockedArea;
    }


    /// <summary>
    /// 区域。
    /// </summary>
    public string? Area { get; init; }

    /// <summary>
    /// 锁定区域（表示区域能否在环境正常化中修改）。
    /// </summary>
    public bool LockedArea { get; init; }


    public virtual bool VerifyLockedArea()
        =>;


    /// <summary>
    /// 是否相等。
    /// </summary>
    /// <param name="other">给定的 <see cref="IIsolatableArea"/>。</param>
    /// <returns>返回布尔值。</returns>
    public virtual bool Equals(IIsolatableArea? other)
        => GetHashCode() == other?.GetHashCode();

    /// <summary>
    /// 是否相等。
    /// </summary>
    /// <param name="obj">给定的对象。</param>
    /// <returns>返回布尔值。</returns>
    public override bool Equals(object? obj)
        => obj is IIsolatableArea other && Equals(other);


    /// <summary>
    /// 获取哈希码。
    /// </summary>
    /// <returns>返回整数。</returns>
    public override int GetHashCode()
        => ToString().GetHashCode();


    /// <summary>
    /// 转换为字符串。
    /// </summary>
    /// <returns>返回模拟链接字符串。</returns>
    public override string ToString()
        => $"{nameof(Area)}={Area};{nameof(LockedArea)}={LockedArea}";

}
