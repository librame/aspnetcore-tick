#region License

/* **************************************************************************************
 * Copyright (c) Librame Pong All rights reserved.
 * 
 * https://github.com/librame
 * 
 * You must not remove this notice, or any other, from this software.
 * **************************************************************************************/

#endregion

using Librame.AspNetCore.Resources;

namespace Librame.AspNetCore;

internal class DefaultSiteInfo : AbstractLibrameSiteInfo
{
    public DefaultSiteInfo(IServiceProvider services)
        : base(services)
    {
    }


    public override string Name
        => AbstractIsolatableArea.DefaultAreaName;

    public override IStringLocalizer? Localizer
        => Services.GetRequiredService<IStringLocalizer<DefaultSiteInfoResource>>();
}
