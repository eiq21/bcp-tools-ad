using BCP.User.API.Domain.Entities;
using BCP.User.API.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCP.User.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAdUserProvider adUserPrivider;

        public UsersController(IAdUserProvider adUserPrivider)
        {
            this.adUserPrivider = adUserPrivider;
        }

        [HttpGet("{matricula}")]
        public async Task<AdUser> GetAdUserByMatricula([FromRoute] string? matricula = null) => await adUserPrivider.GetAdUserByMatricula(matricula);

        [HttpGet("groups/{groupName}")]
        public async Task<IEnumerable<AdUser>> GetUsersByGroupName([FromRoute] string? groupName = null) => await adUserPrivider.FindAdUsersByGroupName(groupName);
    }
}
