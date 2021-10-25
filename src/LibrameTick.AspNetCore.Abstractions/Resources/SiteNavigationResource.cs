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
/// 定义实现 <see cref="AbstractViewResource"/> 的站点导航资源。
/// </summary>
public class SiteNavigationResource : AbstractResource
{

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

    /// <summary>
    /// 首页。
    /// </summary>
    public string Index { get; set; }


    /// <summary>
    /// 关于。
    /// </summary>
    public string About { get; }

    /// <summary>
    /// 联系。
    /// </summary>
    public string Contact { get; }

    /// <summary>
    /// 隐私。
    /// </summary>
    public string Privacy { get; }

    /// <summary>
    /// 站点地图。
    /// </summary>
    public string Sitemap { get; }

    /// <summary>
    /// 项目库。
    /// </summary>
    public string Repository { get; set; }

    /// <summary>
    /// 反馈。
    /// </summary>
    public string Issues { get; set; }

    /// <summary>
    /// 授权。
    /// </summary>
    public string Licenses { get; set; }

    /// <summary>
    /// 拒绝访问。
    /// </summary>
    public string AccessDenied { get; set; }


    /// <summary>
    /// 注册。
    /// </summary>
    public string Register { get; set; }

    /// <summary>
    /// 登入。
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// 扩展登入。
    /// </summary>
    public string ExternalLogin { get; set; }

    /// <summary>
    /// 登出。
    /// </summary>
    public string Logout { get; set; }

    /// <summary>
    /// 管理。
    /// </summary>
    public string Manage { get; set; }

#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

}
