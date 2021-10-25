#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.Extensions.Resources;

namespace Librame.AspNetCore.Resources;

/// <summary>
/// 定义抽象实现 <see cref="IResource"/> 的视图资源。
/// </summary>
public abstract class AbstractViewResource : AbstractResource
{

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

    /// <summary>
    /// 标题。
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 描述。
    /// </summary>
    public string Descr { get; set; }

#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

}
