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
/// 项目描述符。
/// </summary>
public class SiteDescriptor
{
    /// <summary>
    /// 构造一个 <see cref="SiteDescriptor"/>。
    /// </summary>
    /// <param name="info">给定的 <see cref="ISiteInfo"/>。</param>
    /// <param name="navigation">给定的 <see cref="ISiteNavigation"/>。</param>
    public SiteDescriptor(ISiteInfo info, ISiteNavigation navigation)
    {
        Info = info;
        Navigation = navigation;
    }


    /// <summary>
    /// 项目信息。
    /// </summary>
    public ISiteInfo Info { get; }

    /// <summary>
    /// 项目导航。
    /// </summary>
    public ISiteNavigation Navigation { get; }

    /// <summary>
    /// 根项目导航。
    /// </summary>
    public ISiteNavigation RootNavigation
        => Navigation.RootNavigation;

    /// <summary>
    /// 身份项目导航。
    /// </summary>
    public ISiteNavigation IdentityNavigation
        => Navigation.IdentityNavigation;

}
