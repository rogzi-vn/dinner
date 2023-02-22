using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmUserDeviceTokens.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserDeviceTokens
{
    public class FcmUserDeviceTokenAppService : AsyncCrudAppService<FcmUserDeviceToken, FcmUserDeviceTokenDto, Guid>, IFcmUserDeviceTokenAppService
    {
        public FcmUserDeviceTokenAppService(IRepository<FcmUserDeviceToken, Guid> repository) : base(repository)
        {
        }
    }
}
