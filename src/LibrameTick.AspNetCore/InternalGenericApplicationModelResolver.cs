#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.Extensions;
using Librame.Extensions.Core;

namespace Librame.AspNetCore;

class InternalGenericApplicationModelResolver : IGenericApplicationModelResolver
{
    private readonly GenericApplicationModelOptions _options;

    private Dictionary<Type, GenericTypeDescriptor>? _descriptors;


    public InternalGenericApplicationModelResolver(IOptionsMonitor<WebExtensionOptions> options)
    {
        _options = options.CurrentValue.GenericApplicationModel;
    }


    public IReadOnlyDictionary<Type, GenericTypeDescriptor> ResolveDescriptors()
    {
        if (_descriptors is null)
        {
            var assemblies = AssemblyLoader.LoadAssemblies(_options.AssemblyLoading);
            if (assemblies is null)
                throw new ArgumentException("The assembly containing the generic application model was not found.");

            var attributeType = typeof(GenericApplicationModelAttribute);

            var modelTypes = assemblies.Where(p => !p.IsDynamic) // 动态程序集不支持导出类型集合
                .SelectMany(s => s.ExportedTypes)
                .Where(p => p.IsTypeDefinition && p.IsDefined(attributeType) && p.IsConcreteType()).ToArray();

            if (modelTypes is null || modelTypes.Length < 1)
                throw new DllNotFoundException($"The generic application model assembly implementing {nameof(GenericApplicationModelAttribute)} was not found, please confirm that any generic application model is installed.");

            _descriptors = new();

            foreach (var modelType in modelTypes)
            {
                var attribute = (GenericApplicationModelAttribute)modelType.GetCustomAttribute(attributeType)!;
                if (!attribute.ValidateModel(modelType, out var modelTypeInfo))
                    throw new ArgumentException("定义的形参类型数与指定的实参类型数不一致。");

                for (var i = 0; i < modelTypeInfo.GenericTypeParameters.Length; i++)
                {
                    var parameterType = modelTypeInfo.GenericTypeParameters[i];
                    if (_descriptors.ContainsKey(parameterType))
                    {
                        var descriptor = _descriptors[parameterType];
                        if (descriptor.ArgumentType != attribute.ArgumentTypes[i])
                            throw new ArgumentException("已存在相同形参类型的实参类型实现。");

                        if (!descriptor.TypeDefinitions.Contains(modelTypeInfo))
                            descriptor.TypeDefinitions.Add(modelTypeInfo);
                    }
                    else
                    {
                        var descriptor = new GenericTypeDescriptor(parameterType);
                        descriptor.ArgumentType = attribute.ArgumentTypes[i];

                        descriptor.TypeDefinitions.Add(modelTypeInfo);
                        _descriptors.Add(parameterType, descriptor);
                    }
                }
            }
        }

        return _descriptors;
    }


    public GenericTypeDescriptor UpdateDescriptor(Type parameterType, Action<GenericTypeDescriptor> updateAction)
    {
        var descriptors = ResolveDescriptors();

        var descriptor = descriptors[parameterType];
        updateAction(descriptor);

        return descriptor;
    }

}
