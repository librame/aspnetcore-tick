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
/// 定义用于存放布局的键集合。
/// </summary>
public static class LayoutKeys
{
    private static List<string> _layoutKeys = InitialKeys();

    private static List<string> InitialKeys()
        => new List<string> { nameof(Common), nameof(Login), nameof(Manage) };


    /// <summary>
    /// 公共布局键。
    /// </summary>
    public static string Common
        => _layoutKeys[0];

    /// <summary>
    /// 登陆布局键。
    /// </summary>
    public static string Login
        => _layoutKeys[1];

    /// <summary>
    /// 管理布局键。
    /// </summary>
    public static string Manage
        => _layoutKeys[2];


    /// <summary>
    /// 添加键。
    /// </summary>
    /// <param name="key">给定的键名。</param>
    public static void Add(string key)
        => _layoutKeys.Add(key);

    /// <summary>
    /// 包含键。
    /// </summary>
    /// <param name="key">给定的键名。</param>
    /// <returns>返回布尔值。</returns>
    public static bool Contains(string key)
        => _layoutKeys.Any(fk => fk.Equals(key, StringComparison.OrdinalIgnoreCase));
}
