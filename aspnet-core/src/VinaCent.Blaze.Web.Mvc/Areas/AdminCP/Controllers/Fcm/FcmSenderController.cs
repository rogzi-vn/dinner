using Abp.AspNetCore.Mvc.Authorization;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinaCent.Blaze.Controllers;
using VinaCent.Blaze.Web.Areas.AdminCP.Models.Fcm;
using VinaCent.Blaze.Web.FirebaseCloudMessage;

namespace VinaCent.Blaze.Web.Areas.AdminCP.Controllers.Fcm
{
    [AbpMvcAuthorize]
    [Area("AdminCP")]
    [Route("admincp/fcm/send")]
    public class FcmSenderController : BlazeControllerBase
    {
        private readonly IFcmService _facmService;

        public FcmSenderController(IFcmService facmService)
        {
            _facmService = facmService;
        }

        [HttpPost("topic")]
        public async Task<IActionResult> SendMessageToTopic(FcmSendBodyiewModel input)
        {
            var msg = new Message()
            {
                Notification = new Notification
                {
                    Title = input.Title,
                    Body = input.Message
                },
                Topic = input.Token
            };
            var result = await _facmService.SendMessageAsync(msg);
            return Content(result);
        }

        [HttpPost("device")]
        public async Task<IActionResult> SendMessageToDevice(FcmSendBodyiewModel input)
        {
            var msg = new Message()
            {
                Notification = new Notification
                {
                    Title = input.Title,
                    Body = input.Message
                },
                Token = input.Token
            };
            var result = await _facmService.SendMessageAsync(msg);
            return Content(result);
        }
    }
}
