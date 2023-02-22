using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VinaCent.Blaze.FirebaseCloudMessage
{
    [Table("FCM." + nameof(FcmDeviceTokenTopic))]
    public class FcmDeviceTokenTopic : Entity<Guid>
    {
        public Guid TopicId { get; set; }
        public string DeviceToken { get; set; }

        [ForeignKey(nameof(TopicId))]
        public virtual FcmTopic Topic { get; set; }
    }
}
