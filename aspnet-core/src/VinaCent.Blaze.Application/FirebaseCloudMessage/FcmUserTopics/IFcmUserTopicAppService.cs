using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmUserDeviceTokens.Dto;
using VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics
{
    public interface IFcmUserTopicAppService : IAsyncCrudAppService<FcmUserTopicDto, Guid>
    {
    }
}
