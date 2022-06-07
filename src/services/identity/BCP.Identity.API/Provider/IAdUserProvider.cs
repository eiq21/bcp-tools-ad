using System.Security.Principal;
using BCP.Identity.API.Domain.Entities;

namespace BCP.Identity.API.Provider
{
    public interface IAdUserProvider
    {
        AdUser CurrentUser { get; set; }
        bool Initialized { get; set; }
        Task Create(HttpContext context, IConfiguration config);
        Task<AdUser> GetAdUser(IIdentity identity);
        Task<AdUser> GetAdUser(string samAccountName);
        Task<AdUser> GetAdUser(Guid guid);
        Task<List<AdUser>> GetDomainUsers();
        Task<List<AdUser>> FindDomainUser(string search);
    }
}