using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinaCent.Blaze.Authorization;
using VinaCent.Blaze.Controllers;

namespace VinaCent.Blaze.Web.Areas.AdminCP.Controllers
{
    [AbpMvcAuthorize]
    [Area("AdminCP")]
    [Route("admincp/fcm/message-logs")]
    public class FcmMessageLogsController : BlazeControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
