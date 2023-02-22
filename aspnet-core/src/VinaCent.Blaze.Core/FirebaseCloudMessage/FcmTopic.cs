using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VinaCent.Blaze.FirebaseCloudMessage
{
    [Table("FCM." + nameof(FcmTopic))]
    public class FcmTopic : Entity<Guid>
    {
        public string DisplayName { get; set; }
        public string Desciption { get; set; }
    }
}
