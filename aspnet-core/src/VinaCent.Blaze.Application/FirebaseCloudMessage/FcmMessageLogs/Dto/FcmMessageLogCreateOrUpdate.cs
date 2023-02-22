using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace VinaCent.Blaze.FirebaseCloudMessage
{
    [AutoMap(typeof(FcmMessageLog), typeof(FcmMessageLogDto))]
    public class FcmMessageLogCreateOrUpdate : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string RawJsonData { get; set; }
        public Guid? TopicId { get; set; }
        public string Token { get; set; }
    }
}
