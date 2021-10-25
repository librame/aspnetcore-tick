#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Librame.AspNetCore;

internal class SiteManager : ISiteManager
{
    private readonly WebExtensionOptions _options;

    private SiteDescriptor _current;


    public SiteManager(ServiceFactory serviceFactory,
        IEnumerable<ISiteNavigation> navigations,
        IOptions<WebExtensionOptions> options)
    {
        ServiceFactory = serviceFactory.NotNull(nameof(serviceFactory));
        Navigations = navigations.NotNull(nameof(navigations));
        _options = options.NotNull(nameof(options)).Value;

        Initialize();
    }


    private void Initialize()
    {
        var identityNavigation = Navigations.FirstOrDefault(_options.PredicateIdentityNavigation);
        if (identityNavigation.IsNotNull())
        {
            Navigations.ForEach(nav => nav.IdentityNavigation = identityNavigation);
        }
    }


    private Dictionary<string, ISiteInfo> LoadInfos()
    {
        var infos = ApplicationHelper.GetApplicationInfos(_options.SearchApplicationAssemblyPatterns,
            type => type.EnsureCreate<ISiteInfo>(ServiceFactory)); // 此创建方法要求项目信息实现类型可公共构造

        // Add default AreaInfo
        var defaultInfo = new DefaultProjectInfo(ServiceFactory);
        infos.Add(defaultInfo.Name, defaultInfo);

        return infos;
    }


    public ServiceFactory ServiceFactory { get; }

    public IEnumerable<ISiteNavigation> Navigations { get; }

    public IReadOnlyDictionary<string, ISiteInfo> Infos
        => LoadInfos();


    public SiteDescriptor Current
    {
        get
        {
            if (_current.IsNull())
                return SetCurrent(null);

            return _current;
        }
    }


    public SiteDescriptor SetCurrent(string area)
    {
        ExtensionSettings.Preference.RunLocker(() =>
        {
            _current = new SiteDescriptor(FindInfo(area), FindNavigation(area));
        });
            
        return _current;
    }


    public ISiteInfo FindInfo(string name)
    {
        // 项目信息键名支持 default
        if (name.IsNotEmpty() && Infos.TryGetValue(name, out ISiteInfo info))
            return info;
            
        return Infos[DefaultSiteInfo.DefaultProjectName];
    }

    public ISiteNavigation FindNavigation(string area)
    {
        // 项目导航键名不支持 default
        if (area == DefaultSiteInfo.DefaultProjectName)
            area = null; // 默认项目导航的区域必须为空

        return Navigations.First(nav => nav.Area == area);
    }

}
