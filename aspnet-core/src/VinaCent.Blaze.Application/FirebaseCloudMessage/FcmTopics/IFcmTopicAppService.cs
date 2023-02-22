using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics.Dto;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmTopics
{
    public interface IFcmTopicAppService: IAsyncCrudAppService<FcmTopicDto, Guid>
    {
    }
}
