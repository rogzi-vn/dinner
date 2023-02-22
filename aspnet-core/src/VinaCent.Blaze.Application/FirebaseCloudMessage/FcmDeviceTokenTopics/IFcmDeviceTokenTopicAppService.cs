using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmDeviceTokenTopics.Dto;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmDeviceTokenTopics
{
    public interface IFcmDeviceTokenTopicAppService : IAsyncCrudAppService<FcmDeviceTokenTopicDto, Guid>
    {
    }
}
