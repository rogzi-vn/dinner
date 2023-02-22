using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmDeviceTokenTopics.Dto
{
    [AutoMap(typeof(FcmDeviceTokenTopic))]
    public class FcmDeviceTokenTopicDto : EntityDto<Guid>
    {
        public Guid TopicId { get; set; }
        public string DeviceToken { get; set; }

        public virtual FcmTopic Topic { get; set; }
    }
}
