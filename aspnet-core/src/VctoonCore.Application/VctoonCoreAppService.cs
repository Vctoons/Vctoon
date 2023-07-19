﻿using VctoonCore.Localization;
using Volo.Abp.Application.Services;

namespace VctoonCore;

/* Inherit your application services from this class.
 */
public abstract class VctoonCoreAppService : ApplicationService
{
    protected VctoonCoreAppService()
    {
        LocalizationResource = typeof(VctoonCoreResource);
    }
}
