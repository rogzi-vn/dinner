using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VinaCent.Blaze.FirebaseCloudMessage
{
    [Table("FCM." + nameof(FcmMessageLog))]
    public class FcmMessageLog : AuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string RawJsonData { get; set; }
        public Guid? TopicId { get; set; }
        public string Token { get; set; }
    }
}
