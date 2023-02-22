using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VinaCent.Blaze.FirebaseCloudMessage
{
    [AutoMap(typeof(FcmMessageLog))]
    public class FcmMessageLogDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string RawJsonData { get; set; }
        public Guid? TopicId { get; set; }
        public string Token { get; set; }
    }
}
