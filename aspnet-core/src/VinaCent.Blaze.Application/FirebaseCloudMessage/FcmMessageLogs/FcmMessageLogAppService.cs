using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using VinaCent.Blaze.FirebaseCloudMessage.FcmMessageLogs.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmMessageLogs
{
    public class FcmMessageLogAppService : AsyncCrudAppService<FcmMessageLog, FcmMessageLogDto, Guid, FcmMessageLogFilterDto, FcmMessageLogCreateOrUpdate, FcmMessageLogCreateOrUpdate>, IFcmMessageLogAppService
    {
        public FcmMessageLogAppService(IRepository<FcmMessageLog, Guid> repository) : base(repository)
        {
        }
    }
}
