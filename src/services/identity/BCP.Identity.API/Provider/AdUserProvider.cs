using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using BCP.Identity.API.Domain.Entities;
using BCP.Identity.API.Extensions;

namespace BCP.Identity.API.Provider
{
    public class AdUserProvider : IAdUserProvider
    {
        public AdUser CurrentUser { get; set ; }
        public bool Initialized { get; set; }

        public async Task Create(HttpContext context, IConfiguration config)
        {
            CurrentUser = await GetAdUser(context.User.Identity);
            Initialized = true;
        }

        public Task<List<AdUser>> FindDomainUser(string search)
        {
            return Task.Run(() =>
            {
                PrincipalContext context = new PrincipalContext(ContextType.Domain, "credito.bcp.com.pe");
                UserPrincipal principal = new UserPrincipal(context);
                principal.SamAccountName = $"*{search}*";
                principal.Enabled = true;
                PrincipalSearcher searcher = new PrincipalSearcher(principal);

                var users = searcher
                   .FindAll()
                   .AsQueryable()
                   .Cast<UserPrincipal>()
                   .FilterUsers()
                   .SelectAdUsers()
                   .OrderBy(x => x.Surname)
                   .ToList();

                return users;
            });
        }

        public Task<AdUser> GetAdUser(IIdentity identity)
        {
            return Task.Run(() =>
            {
                try
                {
                    PrincipalContext context = new PrincipalContext(ContextType.Domain, "credito.bcp.com.pe");
                    UserPrincipal principal = new UserPrincipal(context);

                    if (context != null)
                        principal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, identity.Name);

                    return AdUser.MapToAdUser(principal);

                }
                catch (System.Exception ex)
                {
                    throw new Exception("Error retrieving Ad User", ex);
                }
            });
        }

        public Task<AdUser> GetAdUser(string samAccountName)
        {
            return Task.Run(() =>
             {
                 try
                 {
                     PrincipalContext context = new PrincipalContext(ContextType.Domain, "credito.bcp.com.pe");
                     UserPrincipal principal = new UserPrincipal(context);

                     if (context != null)
                     {
                         principal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, samAccountName);
                     }

                     return AdUser.MapToAdUser(principal);
                 }
                 catch (Exception ex)
                 {
                     throw new Exception("Error retrieving AD User", ex);
                 }
             });
        }

        public Task<AdUser> GetAdUser(Guid guid)
        {
             return Task.Run(() =>
            {
                try
                {
                    PrincipalContext context = new PrincipalContext(ContextType.Domain, "credito.bcp.com.pe");
                    UserPrincipal principal = new UserPrincipal(context);
                     
                    if (context != null)
                    {
                        principal = UserPrincipal.FindByIdentity(context, IdentityType.Guid, guid.ToString());
                    }
                     
                    return AdUser.MapToAdUser(principal);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving AD User", ex);
                }
            });
        }

        public Task<List<AdUser>> GetDomainUsers()
        {
           return Task.Run(() =>
            {
                PrincipalContext context = new PrincipalContext(ContextType.Domain, "credito.bcp.com.pe");
                UserPrincipal principal = new UserPrincipal(context);
                principal.UserPrincipalName = "*@*";
                principal.Enabled = true;
                PrincipalSearcher searcher = new PrincipalSearcher(principal);
                 
                var users = searcher
                    .FindAll()
                    .AsQueryable()
                    .Cast<UserPrincipal>()
                    .FilterUsers()
                    .SelectAdUsers()
                    .OrderBy(x => x.Surname)
                    .ToList();
                     
                return users;
            });
        }
    }
}