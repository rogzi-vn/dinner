using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using VinaCent.Blaze.Authorization;
using VinaCent.Blaze.Controllers;
using VinaCent.Blaze.FirebaseCloudMessage.FcmMessageLogs;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics;
using VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage;
using VinaCent.Blaze.FirebaseCloudMessage.FirebaseCloudMessage.Dto;

namespace VinaCent.Blaze.Web.Areas.AdminCP.Controllers
{
    [AbpMvcAuthorize]
    [Area("AdminCP")]
    [Route("admincp/fcm/message-logs")]
    public class FcmMessageLogsController : BlazeControllerBase
    {
        private readonly IFcmTopicAppService _fcmTopicAppService;
        private readonly IFcmAppService _fcmAppService;

        public FcmMessageLogsController(IFcmTopicAppService fcmTopicAppService, IFcmAppService fcmAppService)
        {
            _fcmTopicAppService = fcmTopicAppService;
            _fcmAppService = fcmAppService;
        }

        private async Task LoadTopics()
        {
            var topics = await _fcmTopicAppService.GetAllAsync(new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 1000
            });
            ViewBag.TopicSelectList = topics.Items.Select(x => new SelectListItem(x.DisplayName, x.Id.ToString()));
        }

        public async Task<IActionResult> Index()
        {
            await LoadTopics();
            return View();
        }

        [HttpPost("send-by-topic")]
        public async Task<IActionResult> SendByTopic(FcmMsgBody input)
        {
            await _fcmAppService.SendByTopic(input);
            AddSuccessNotify($"Đã gửi \"{input.Title}\" đến topic thành công!");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("send-by-token")]
        public async Task<IActionResult> SendByToken(FcmMsgBody input)
        {
            await _fcmAppService.SendByToken(input);
            AddSuccessNotify($"Đã gửi \"{input.Title}\" đến thiết bị thành công!");
            return RedirectToAction(nameof(Index));
        }
    }
}
