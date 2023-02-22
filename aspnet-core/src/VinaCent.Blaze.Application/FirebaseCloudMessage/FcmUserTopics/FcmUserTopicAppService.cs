using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics
{
    public class FcmUserTopicAppService : AsyncCrudAppService<FcmUserTopic, FcmUserTopicDto, Guid>, IFcmUserTopicAppService
    {
        public FcmUserTopicAppService(IRepository<FcmUserTopic, Guid> repository) : base(repository)
        {
        }
    }
}
