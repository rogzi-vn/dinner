using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using VinaCent.Blaze.Controllers;
using VinaCent.Blaze.FirebaseCloudMessage.FcmUserTopics;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics.Dto;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VinaCent.Blaze.Web.Areas.AdminCP.Controllers.Fcm
{
    [AbpMvcAuthorize]
    [Area("AdminCP")]
    [Route("admincp/fcm/user-topics")]
    public class FcmUserTopicsController : BlazeControllerBase
    {
        private readonly IFcmUserTopicAppService _fcmUserTopicAppService;
        private readonly IFcmTopicAppService _fcmTopicAppService;

        public FcmUserTopicsController(IFcmUserTopicAppService fcmUserTopicAppService, IFcmTopicAppService fcmTopicAppService)
        {
            _fcmUserTopicAppService = fcmUserTopicAppService;
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
            var dto = await _fcmUserTopicAppService.GetAsync(new EntityDto<Guid>(id));
            return PartialView("_EditModal", dto);
        }
    }
}
