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
public interface IGenericApplicationModelManager
{
    /// <summary>
    /// 泛型类型描述符字典集合。
    /// </summary>
    IReadOnlyDictionary<Type, GenericTypeDescriptor> TypeDescriptors { get; }


    /// <summary>
    /// 构建泛型应用模型。
    /// </summary>
    /// <param name="typeDefinition">给定的泛型类型定义。</param>
    /// <returns>返回泛型实现类型。</returns>
    Type BuildGenericApplicationModel(TypeInfo typeDefinition);
}
