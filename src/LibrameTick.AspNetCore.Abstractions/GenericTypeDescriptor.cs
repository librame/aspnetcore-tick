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
/// 定义泛型应用模型描述符。
/// </summary>
public class GenericTypeDescriptor
{
    /// <summary>
    /// 构造一个 <see cref="GenericTypeDescriptor"/>。
    /// </summary>
    /// <param name="parameterType">给定的泛型形参类型。</param>
    public GenericTypeDescriptor(Type parameterType)
    {
        ParameterType = parameterType;
    }


    /// <summary>
    /// 形参类型。
    /// </summary>
    public Type ParameterType { get; init; }

    /// <summary>
    /// 实参类型。
    /// </summary>
    public Type? ArgumentType { get; set; }

    /// <summary>
    /// 类型定义列表。
    /// </summary>
    public List<TypeInfo> TypeDefinitions { get; init; } = new();
}
