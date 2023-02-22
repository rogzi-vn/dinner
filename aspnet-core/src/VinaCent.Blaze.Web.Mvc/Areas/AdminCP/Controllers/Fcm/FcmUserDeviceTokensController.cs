using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VinaCent.Blaze.Controllers;
using VinaCent.Blaze.FirebaseCloudMessage.FcmUserDeviceTokens;

namespace VinaCent.Blaze.Web.Areas.AdminCP.Controllers.Fcm
{
    [AbpMvcAuthorize]
    [Area("AdminCP")]
    [Route("admincp/fcm/user-device-tokens")]
    public class FcmUserDeviceTokensController : BlazeControllerBase
    {
        private readonly IFcmUserDeviceTokenAppService _fcmUserDeviceTokenAppService;

        public FcmUserDeviceTokensController(IFcmUserDeviceTokenAppService fcmUserDeviceTokenAppService)
        {
            _fcmUserDeviceTokenAppService = fcmUserDeviceTokenAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("edit-modal")]
        public async Task<ActionResult> EditModal(Guid id)
        {
            var dto = await _fcmUserDeviceTokenAppService.GetAsync(new EntityDto<Guid>(id));
            return PartialView("_EditModal", dto);
        }
    }
}
