#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

namespace Librame.AspNetCore.Themepack;

/// <summary>
/// 定义一个主题管理器接口。
/// </summary>
public interface IThemeManager
{
    /// <summary>
    /// 主题信息字典集合。
    /// </summary>
    IReadOnlyDictionary<string, IThemeInfo> Infos { get; }

    /// <summary>
    /// 当前主题信息。
    /// </summary>
    IThemeInfo CurrentInfo { get; }


    /// <summary>
    /// 设置当前主题信息。
    /// </summary>
    /// <param name="name">给定的主题名称。</param>
    /// <returns>返回 <see cref="IThemeInfo"/>。</returns>
    IThemeInfo SetCurrentInfo(string name);

    /// <summary>
    /// 查找指定名称的主题信息。
    /// </summary>
    /// <param name="name">给定的主题名称。</param>
    /// <returns>返回 <see cref="IThemeInfo"/>。</returns>
    IThemeInfo? FindInfo(string name);
}
