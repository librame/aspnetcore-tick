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
/// 定义一个站点管理器接口。
/// </summary>
public interface ISiteManager
{
    /// <summary>
    /// 服务工厂。
    /// </summary>
    ServiceFactory ServiceFactory { get; }

    /// <summary>
    /// 页面。
    /// </summary>
    IEnumerable<ISiteNavigation> Navigations { get; }

    /// <summary>
    /// 信息字典集合。
    /// </summary>
    IReadOnlyDictionary<string, ISiteInfo> Infos { get; }


    /// <summary>
    /// 当前项目。
    /// </summary>
    /// <returns>返回 <see cref="ProjectDescriptor"/>。</returns>
    ProjectDescriptor Current { get; }


    /// <summary>
    /// 设置当前项目。
    /// </summary>
    /// <param name="area">给定的区域（请确保项目信息名称与给定的区域保持一致）。</param>
    /// <returns>返回 <see cref="ProjectDescriptor"/>。</returns>
    ProjectDescriptor SetCurrent(string area);


    /// <summary>
    /// 查找指定名称的项目信息。
    /// </summary>
    /// <param name="name">给定的项目名称。</param>
    /// <returns>返回 <see cref="ISiteInfo"/>。</returns>
    ISiteInfo FindInfo(string name);

    /// <summary>
    /// 查找指定区域的项目导航。
    /// </summary>
    /// <param name="area">给定的区域。</param>
    /// <returns>返回 <see cref="ISiteNavigation"/>。</returns>
    ISiteNavigation FindNavigation(string area);
}
