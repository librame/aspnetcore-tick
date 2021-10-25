#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

namespace Librame.AspNetCore.Themepack.Simple;

/// <summary>
/// 定义实现 <see cref="IThemeResource"/> 的 Web 主题信息。
/// </summary>
public class ThemeResource : AbstractThemeResource
{
    /// <summary>
    /// 构造一个 <see cref="ThemeResource"/>。
    /// </summary>
    public ThemeResource()
        : base(nameof(Simple))
    {
    }


    /// <summary>
    /// 隐私和 Cookie 策略。
    /// </summary>
    public string PrivacyAndCookiePolicy
    {
        get => GetString(nameof(PrivacyAndCookiePolicy));
        set => Add(nameof(PrivacyAndCookiePolicy), value);
    }

    /// <summary>
    /// 隐私和 Cookie 策略按钮。
    /// </summary>
    public string PrivacyAndCookiePolicyButton
    {
        get => GetString(nameof(PrivacyAndCookiePolicyButton));
        set => Add(nameof(PrivacyAndCookiePolicyButton), value);
    }

}
