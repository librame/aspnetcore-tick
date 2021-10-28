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
/// 定义实现 <see cref="ILinker"/> 的动作 Razor 视图链接器。
/// </summary>
public class ActionRazorLinker : RazorLinker
{
    /// <summary>
    /// 构造一个 <see cref="ActionRazorLinker"/>。
    /// </summary>
    /// <param name="action">给定的动作（即视图名称，可选）。</param>
    /// <param name="controller">给定的控制器（可选）。</param>
    /// <param name="values">给定的参数值集合对象（可选）。</param>
    /// <param name="protocol">给定的协议（可选）。</param>
    /// <param name="host">给定的主机（可选）。</param>
    /// <param name="fragment">给定的片段（可选）。</param>
    /// <param name="area">给定的区域（可选）。</param>
    /// <param name="lockedArea">锁定区域（默认锁定；表示区域不会在环境正常化中修改）。</param>
    public ActionRazorLinker(string? action = null, string? controller = null, object? values = null,
        string? protocol = null, string? host = null, string? fragment = null,
        string? area = null, bool lockedArea = true)
        : base(action, values, protocol, host, fragment, area, lockedArea)
    {
        Controller = controller;
    }


    /// <summary>
    /// 动作。
    /// </summary>
    public string? Action
        => ViewName;

    /// <summary>
    /// 控制器。
    /// </summary>
    public string? Controller { get; protected set; }


    /// <summary>
    /// 生成链接。
    /// </summary>
    /// <param name="helper">给定的 <see cref="IUrlHelper"/>。</param>
    /// <returns>返回链接字符串。</returns>
    public override string? GenerateLink(IUrlHelper helper)
        => helper.ActionLink(ViewName, Controller, Values, Protocol, Host, Fragment);


    /// <summary>
    /// 转换为字符串。
    /// </summary>
    /// <returns>返回模拟链接字符串。</returns>
    public override string ToString()
        => $"{nameof(Action)}={Action};{nameof(Controller)}={Controller};{base.ToString()}";

}
