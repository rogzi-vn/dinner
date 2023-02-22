using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using VinaCent.Blaze.Authorization.Users;

namespace VinaCent.Blaze.FirebaseCloudMessage
{
    [Table("FCM." + nameof(FcmUserDeviceToken))]
    public class FcmUserDeviceToken : Entity<Guid>
    {
        public long UserId { get; set; }
        public string UserToken { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
