using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.AppCore.Languages.Dto;
using VinaCent.Blaze.FirebaseCloudMessage.FcmMessageLogs.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmMessageLogs
{
    public interface IFcmMessageLogAppService: IAsyncCrudAppService<FcmMessageLogDto, Guid, FcmMessageLogFilterDto, FcmMessageLogCreateOrUpdate>
    {
    }
}
