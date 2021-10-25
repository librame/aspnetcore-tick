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

class InternalThemeManager : IThemeManager
{
    private readonly object _locker = new object();

    private IThemeInfo? _currentInfo;


    public InternalThemeManager(IThemeResolver resolver)
    {
        Infos = resolver.ResolveInfos().ToDictionary(ks => ks.Name, es => es);
    }


    public IReadOnlyDictionary<string, IThemeInfo> Infos { get; init; }


    public IThemeInfo CurrentInfo
    {
        get
        {
            if (_currentInfo is null)
                _currentInfo = Infos.Values.First();

            return _currentInfo;
        }
    }


    public IThemeInfo SetCurrentInfo(string name)
    {
        lock (_locker)
        {
            var info = FindInfo(name);
            if (info is null)
                throw new ArgumentException($"No theme information was found for the specified name '{name}'.");
                
            _currentInfo = info;
        }
            
        return _currentInfo;
    }


    public IThemeInfo? FindInfo(string name)
    {
        if (Infos.TryGetValue(name, out var info))
            return info;

        return null;

        //// 项目信息键名支持 default
        //if (name.IsNotEmpty() && Infos.TryGetValue(name, out IWebThemeInfo info))
        //    return info;

        //return Infos.Values.First();
    }

}
