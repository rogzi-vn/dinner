using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using VinaCent.Blaze.Authorization.Users;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserDeviceTokens.Dto
{
    [AutoMap(typeof(FcmUserDeviceToken))]
    public class FcmUserDeviceTokenDto : EntityDto<Guid>
    {
        public long UserId { get; set; }
        public string UserToken { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
