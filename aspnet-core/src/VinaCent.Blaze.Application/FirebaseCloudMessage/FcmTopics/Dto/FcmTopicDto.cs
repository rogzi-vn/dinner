using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmTopics.Dto
{
    [AutoMap(typeof(FcmTopic))]
    public class FcmTopicDto : EntityDto<Guid>
    {
        public string DisplayName { get; set; }
        public string Desciption { get; set; }
    }
}
