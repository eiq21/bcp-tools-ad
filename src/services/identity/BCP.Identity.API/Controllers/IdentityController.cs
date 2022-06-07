using BCP.Identity.API.Domain.Entities;
using BCP.Identity.API.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Identity.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/identities")]
    public class IdentityController : ControllerBase
    {
        private readonly IAdUserProvider userProvider;

        public IdentityController(IAdUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        [HttpGet("[action]")]
        public async Task<List<AdUser>> GetDomainUsers() => await userProvider.GetDomainUsers();

        [HttpGet("[action]/{search}")]
        public async Task<List<AdUser>> FindDomainUser([FromRoute] string search) => await userProvider.FindDomainUser(search);

        [HttpGet("[action]")]
        public AdUser GetCurrentUser() => userProvider.CurrentUser;
    }
}