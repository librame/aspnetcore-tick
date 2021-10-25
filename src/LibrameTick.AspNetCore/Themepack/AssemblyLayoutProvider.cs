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

namespace Librame.AspNetCore.Themepack;

/// <summary>
/// 定义实现 <see cref="ILayoutProvider"/> 的程序集布局提供程序。
/// </summary>
public class AssemblyLayoutProvider : ILayoutProvider
{
    // 默认的布局路径匹配模式
    private const string _defaultRazorPathPattern
        = @"/Views/Shared/(\w+)/_Layout\.cshtml";

    // 默认匹配的分组值从索引 1 开始，索引 0 为 input
    private readonly Func<GroupCollection, string> _defaultNameSelector
        = groups => groups[1].Value;

    private readonly Type _razorAttributeType
        = typeof(RazorSourceChecksumAttribute);

    private readonly Assembly _themepackAssembly;


    /// <summary>
    /// 构造一个 <see cref="AssemblyLayoutProvider"/>。
    /// </summary>
    /// <param name="themepackAssembly">给定包含布局的主题包 <see cref="Assembly"/>。</param>
    public AssemblyLayoutProvider(Assembly themepackAssembly)
    {
        _themepackAssembly = themepackAssembly;
    }


    /// <summary>
    /// 获取主题包的布局路径集合。
    /// </summary>
    /// <param name="pathPattern">给定布局查找的路径模式（可选）。</param>
    /// <param name="nameSelector">给定符合布局查找路径模式的名称选择器（可选）。</param>
    /// <returns>返回包含布局名称与路径的字典集合。</returns>
    public Dictionary<string, string> GetRazorPaths(string? pathPattern = null,
        Func<GroupCollection, string>? nameSelector = null)
    {
        // 获取已编译的视图关联程序集
        var relatedAssemblies = RelatedAssemblyAttribute.GetRelatedAssemblies(_themepackAssembly, throwOnError: true);
        if (!relatedAssemblies.Any())
            throw new NotSupportedException($"No related assemblies '{_themepackAssembly.GetName().Name}' of compiled razor assembly found.");

        var layouts = new Dictionary<string, string>();
        var regex = new Regex(pathPattern ?? _defaultRazorPathPattern);

        if (nameSelector is null)
            nameSelector = _defaultNameSelector;

        relatedAssemblies.ForEach(assembly =>
        {
            var allAttributes = new List<RazorSourceChecksumAttribute>();

            foreach (var type in assembly.DefinedTypes.Where(p => p.IsDefined(_razorAttributeType, false)))
            {
                allAttributes.AddRange(type.GetCustomAttributes<RazorSourceChecksumAttribute>());
            }

            foreach (var path in allAttributes.Select(attrib => attrib.Identifier).Distinct())
            {
                var match = regex.Match(path);
                if (match.Success)
                {
                    var name = nameSelector.Invoke(match.Groups);
                    layouts.Add(name, path);
                }
            }
        });

        if (layouts.Count < 1)
            throw new FileNotFoundException($"The available layout '{_defaultRazorPathPattern}' could not be loaded.");

        return layouts;
    }

}
