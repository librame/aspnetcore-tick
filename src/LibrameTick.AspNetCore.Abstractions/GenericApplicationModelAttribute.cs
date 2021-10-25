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
/// 定义泛型应用模型特性。
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class GenericApplicationModelAttribute : Attribute
{
    /// <summary>
    /// 构造一个 <see cref="GenericApplicationModelAttribute"/>。
    /// </summary>
    /// <param name="argumentTypes">给定实现泛型应用模型类型定义对应的实参类型数组。</param>
    public GenericApplicationModelAttribute(params Type[] argumentTypes)
    {
        ArgumentTypes = argumentTypes;
    }


    /// <summary>
    /// 参数类型数组。
    /// </summary>
    public Type[] ArgumentTypes { get; init; }


    /// <summary>
    /// 验证泛型应用模型有效性。
    /// </summary>
    /// <param name="typeDefinition">给定的泛型应用模型类型定义。</param>
    /// <param name="typeInfo">输出 <see cref="TypeInfo"/>。</param>
    /// <returns>返回是否有效的布尔值。</returns>
    public virtual bool ValidateModel(Type typeDefinition, out TypeInfo typeInfo)
    {
        typeInfo = typeDefinition.GetTypeInfo();
        return typeInfo.GenericTypeParameters.Length == ArgumentTypes.Length;
    }

}
