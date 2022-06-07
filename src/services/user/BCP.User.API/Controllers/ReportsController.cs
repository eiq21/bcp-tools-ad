using BCP.User.API.Domain.Entities;
using BCP.User.API.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BCP.User.API.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IAdUserProvider adUserProvider;

        public ReportsController(IAdUserProvider adUserProvider)
        {
            this.adUserProvider = adUserProvider;
        }
        [HttpGet]
        public async Task<ActionResult> GetAdUserByGroupName([FromQuery] string groupName = null)
        {
            var adUsers = await adUserProvider.FindAdUsersByGroupName(groupName);
            var stringBuilder = AdUser.ToStringBuilder(adUsers,groupName);
            Response.Headers.Add("content-disposition", "attachment; filename=report" + DateTime.Now.Year.ToString() + ".xlsx");
            Response.ContentType = "application/vnd.ms-excel";
            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString()), "application/vnd.ms-excel", $"REPORTE_{groupName.ToUpper()}_" + DateTime.Now.ToString("ddMMyyy") + ".xls");
        }
    }


}
