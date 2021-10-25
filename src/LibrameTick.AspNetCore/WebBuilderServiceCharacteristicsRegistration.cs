#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using System;
using System.Collections.Generic;

namespace Librame.AspNetCore.Web.Builders
{
    ///// <summary>
    ///// <see cref="IWebBuilder"/> 服务特征注册。
    ///// </summary>
    //public static class WebBuilderServiceCharacteristicsRegistration
    //{
    //    private static IServiceCharacteristicsRegister _register;

    //    /// <summary>
    //    /// 当前注册器。
    //    /// </summary>
    //    public static IServiceCharacteristicsRegister Register
    //    {
    //        get => _register.EnsureSingleton(() => new ServiceCharacteristicsRegister(InitializeCharacteristics()));
    //        set => _register = value.NotNull(nameof(value));
    //    }


    //    private static IDictionary<Type, ServiceCharacteristics> InitializeCharacteristics()
    //    {
    //        return new Dictionary<Type, ServiceCharacteristics>
    //        {
    //            // Applications
    //            { typeof(IApplicationContext), ServiceCharacteristics.Singleton() },
    //            { typeof(IApplicationPrincipal), ServiceCharacteristics.Singleton() },

    //            // Localizers
    //            { typeof(IDictionaryHtmlLocalizer<>), ServiceCharacteristics.Transient() },
    //            { typeof(IDictionaryHtmlLocalizerFactory), ServiceCharacteristics.Singleton() },

    //            // Projects
    //            { typeof(ISiteManager), ServiceCharacteristics.Singleton() },
    //            { typeof(ISiteNavigation), ServiceCharacteristics.Singleton() },

    //            // Services
    //            { typeof(ICopyrightService), ServiceCharacteristics.Singleton() },
    //            { typeof(IUserPortraitService), ServiceCharacteristics.Singleton() },

    //            // Themepacks
    //            { typeof(IThemepackContext), ServiceCharacteristics.Singleton() }
    //        };
    //    }

    //}
}
