using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmTopics
{
    public class FcmTopicAppService : AsyncCrudAppService<FcmTopic, FcmTopicDto, Guid>, IFcmTopicAppService
    {
        public FcmTopicAppService(IRepository<FcmTopic, Guid> repository) : base(repository)
        {
        }
    }
}
