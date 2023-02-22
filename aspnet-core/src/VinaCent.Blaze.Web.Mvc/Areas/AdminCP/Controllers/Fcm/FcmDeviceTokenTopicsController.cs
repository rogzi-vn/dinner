using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Abp.AspNetCore.Mvc.Authorization;
using VinaCent.Blaze.Controllers;
using VinaCent.Blaze.FirebaseCloudMessage.FcmDeviceTokenTopics;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VinaCent.Blaze.Web.Areas.AdminCP.Controllers.Fcm
{
    [AbpMvcAuthorize]
    [Area("AdminCP")]
    [Route("admincp/fcm/device-token-topics")]
    public class FcmDeviceTokenTopicsController : BlazeControllerBase
    {
        private readonly IFcmDeviceTokenTopicAppService _fcmDeviceTokenTopicAppService;
        private readonly IFcmTopicAppService _fcmTopicAppService;

        public FcmDeviceTokenTopicsController(IFcmDeviceTokenTopicAppService fcmDeviceTokenTopicAppService, IFcmTopicAppService fcmTopicAppService)
        {
            _fcmDeviceTokenTopicAppService = fcmDeviceTokenTopicAppService;
            _fcmTopicAppService = fcmTopicAppService;
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

        [HttpPost("edit-modal")]
        public async Task<ActionResult> EditModal(Guid id)
        {
            await LoadTopics();
            var dto = await _fcmDeviceTokenTopicAppService.GetAsync(new EntityDto<Guid>(id));
            return PartialView("_EditModal", dto);
        }
    }
}
