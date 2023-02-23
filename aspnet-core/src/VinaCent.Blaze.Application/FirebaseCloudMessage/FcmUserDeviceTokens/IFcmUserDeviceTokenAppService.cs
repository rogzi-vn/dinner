using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics.Dto;
using VinaCent.Blaze.FirebaseCloudMessage.FcmUserDeviceTokens.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserDeviceTokens
{
    public interface IFcmUserDeviceTokenAppService : IAsyncCrudAppService<FcmUserDeviceTokenDto, Guid>
    {
        Task<FcmUserDeviceTokenDto> AddToken(FcmUserDeviceTokenDto token);
    }
}
