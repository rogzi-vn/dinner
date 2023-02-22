using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VinaCent.Blaze.AppCore.Languages.Dto;
using VinaCent.Blaze.Authorization;
using VinaCent.Blaze.Controllers;
using VinaCent.Blaze.FirebaseCloudMessage.FcmTopics;

namespace VinaCent.Blaze.Web.Areas.AdminCP.Controllers
{
    [AbpMvcAuthorize]
    [Area("AdminCP")]
    [Route("admincp/fcm/topics")]
    public class FcmTopicsController : BlazeControllerBase
    {
        private readonly FcmTopicAppService _fcmTopicAppService;

        public FcmTopicsController(FcmTopicAppService fcmTopicAppService)
        {
            _fcmTopicAppService = fcmTopicAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("edit-modal")]
        public async Task<ActionResult> EditModal(Guid id)
        {
            var dto = await _fcmTopicAppService.GetAsync(new EntityDto<Guid>(id));
            return PartialView("_EditModal", dto);
        }
    }
}
