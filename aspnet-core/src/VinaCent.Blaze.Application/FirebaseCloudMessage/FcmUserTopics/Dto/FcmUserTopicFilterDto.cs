using Abp.Application.Services.Dto;
using System;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics.Dto
{
    public class FcmUserTopicFilterDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public Guid? TopicId { get; set; }
    }
}
