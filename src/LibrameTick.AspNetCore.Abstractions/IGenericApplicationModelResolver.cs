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
/// 定义一个泛型应用模型解析器接口。
/// </summary>
public interface IGenericApplicationModelResolver
{
    /// <summary>
    /// 解析泛型类型描述符列表。
    /// </summary>
    /// <returns>返回 <see cref="IReadOnlyDictionary{Type, GenericTypeDescriptor}"/>。</returns>
    IReadOnlyDictionary<Type, GenericTypeDescriptor> ResolveDescriptors();

    /// <summary>
    /// 更新指定泛型类型形参描述符。
    /// </summary>
    /// <param name="parameterType">给定泛型类型的形参类型。</param>
    /// <param name="updateAction">给定的更新动作。</param>
    /// <returns>返回 <see cref="GenericTypeDescriptor"/>。</returns>
    GenericTypeDescriptor UpdateDescriptor(Type parameterType, Action<GenericTypeDescriptor> updateAction);
}
