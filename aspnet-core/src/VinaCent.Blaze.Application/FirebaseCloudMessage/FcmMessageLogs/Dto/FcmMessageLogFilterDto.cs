using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaCent.Blaze.FirebaseCloudMessage.FcmMessageLogs.Dto
{
    public class FcmMessageLogFilterDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
