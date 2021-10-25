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
/// 定义一个主题解析器接口。
/// </summary>
public interface IThemeResolver
{
    /// <summary>
    /// 解析主题信息列表。
    /// </summary>
    /// <returns>返回 <see cref="IReadOnlyList{IThemeInfo}"/>。</returns>
    IReadOnlyList<IThemeInfo> ResolveInfos();
}
