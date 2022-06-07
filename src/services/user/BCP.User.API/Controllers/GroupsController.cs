using BCP.User.API.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCP.User.API.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IAdGroupProvider adGroupProvider;
        public GroupsController(IAdGroupProvider adGroupProvider)
        {
            this.adGroupProvider = adGroupProvider;
        }

        [HttpGet("users/{matricula}")]
        public async Task<List<string>> GetAdGroupByMatricula([FromRoute] string? matricula = null) => await adGroupProvider.GetAdGroupByMatricula(matricula);
    }
}
