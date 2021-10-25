#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.Extensions.Core;

namespace Librame.AspNetCore;

/// <summary>
/// 定义实现 <see cref="IOptions"/> 的泛型应用模型选项。
/// </summary>
public class GenericApplicationModelOptions : AbstractOptionsNotifier
{
    /// <summary>
    /// 构造一个独立属性通知器的 <see cref="GenericApplicationModelOptions"/>（此构造函数适用于独立使用 <see cref="GenericApplicationModelOptions"/> 的情况）。
    /// </summary>
    /// <param name="sourceAliase">给定的源别名（独立属性通知器必须命名实例）。</param>
    public GenericApplicationModelOptions(string sourceAliase)
        : base(sourceAliase)
    {
        AssemblyLoading = new(Notifier, "GenericApplicationModel");
        AssemblyLoading.FilteringDescriptors.Add(InitialGenericApplicationModelFiltering());
    }

    /// <summary>
    /// 使用给定的 <see cref="IPropertyNotifier"/> 构造一个 <see cref="GenericApplicationModelOptions"/>。
    /// </summary>
    /// <param name="parentNotifier">给定的父级 <see cref="IPropertyNotifier"/>。</param>
    /// <param name="sourceAliase">给定的源别名（可选）。</param>
    public GenericApplicationModelOptions(IPropertyNotifier parentNotifier, string? sourceAliase = null)
        : base(parentNotifier, sourceAliase)
    {
        AssemblyLoading = new(Notifier, "GenericApplicationModel");
        AssemblyLoading.FilteringDescriptors.Add(InitialGenericApplicationModelFiltering());
    }


    /// <summary>
    /// 程序集加载选项。
    /// </summary>
    public AssemblyLoadingOptions AssemblyLoading { get; init; }


    private static AssemblyFilteringDescriptor InitialGenericApplicationModelFiltering()
    {
        // 设定包含泛型应用模型的程序集筛选器描述符
        var filtering = new AssemblyFilteringDescriptor("GenericApplicationModelFiltering");

        // 包含 ?.AspNetCore.?.Mvc|Pages 格式的程序集名称
        filtering.Filters.Add(new FilteringRegex(@$"(\w+)\.{nameof(AspNetCore)}\.(\w+)\.(Mvc|Pages)",
            FilteringMode.Inclusive));

        return filtering;
    }

}
