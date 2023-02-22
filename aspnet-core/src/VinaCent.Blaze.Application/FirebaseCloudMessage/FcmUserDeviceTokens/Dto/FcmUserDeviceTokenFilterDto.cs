using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmUserDeviceTokens.Dto
{
    public class FcmUserDeviceTokenFilterDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
