using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmDeviceTokenTopics.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmDeviceTokenTopics
{
    public class FcmDeviceTokenTopicAppService : AsyncCrudAppService<FcmDeviceTokenTopic, FcmDeviceTokenTopicDto, Guid>, IFcmDeviceTokenTopicAppService
    {
        public FcmDeviceTokenTopicAppService(IRepository<FcmDeviceTokenTopic, Guid> repository) : base(repository)
        {
        }
    }
}
