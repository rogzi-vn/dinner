using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage.Dto
{
    public class FcmMsgBody
    {
        public string Token { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
