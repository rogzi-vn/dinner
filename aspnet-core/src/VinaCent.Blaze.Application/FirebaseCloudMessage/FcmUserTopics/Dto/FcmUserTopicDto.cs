using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using VinaCent.Blaze.Authorization.Users;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics.Dto
{
    [AutoMap(typeof(FcmUserTopic))]
    public class FcmUserTopicDto : EntityDto<Guid>
    {
        public long UserId { get; set; }
        public Guid FcmTopicId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(FcmTopicId))]
        public virtual FcmTopic FcmTopic { get; set; }
    }
}
