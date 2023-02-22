using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using VinaCent.Blaze.Authorization.Users;

namespace VinaCent.Blaze.FirebaseCloudMessage
{
    [Table("FCM." + nameof(FcmUserTopic))]
    public class FcmUserTopic : Entity<Guid>
    {
        public long UserId { get; set; }
        public Guid FcmTopicId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(FcmTopicId))]
        public virtual FcmTopic FcmTopic { get; set; }
    }
}
