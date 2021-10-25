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

class InternalGenericApplicationModelManager : IGenericApplicationModelManager
{
    public InternalGenericApplicationModelManager(IGenericApplicationModelResolver resolver)
    {
        TypeDescriptors = resolver.ResolveDescriptors();
    }


    public IReadOnlyDictionary<Type, GenericTypeDescriptor> TypeDescriptors { get; init; }


    public Type BuildGenericApplicationModel(TypeInfo typeDefinition)
    {
        var argumentTypes = typeDefinition.GenericTypeParameters.Select(GetArgumentType).ToArray();
        return typeDefinition.MakeGenericType(argumentTypes);
    }

    private Type GetArgumentType(Type parameterType)
    {
        var descriptor = TypeDescriptors[parameterType];
        if (descriptor.ArgumentType is null)
            throw new ArgumentException($"The parameter type '{parameterType}' corresponding argument type is null.");

        return descriptor.ArgumentType;
    }

}
