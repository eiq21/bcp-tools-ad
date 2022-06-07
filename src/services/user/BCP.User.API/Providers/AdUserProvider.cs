using BCP.User.API.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using System.DirectoryServices.AccountManagement;

namespace BCP.User.API.Providers
{
    public class AdUserProvider : IAdUserProvider
    {
        public Task<List<AdUser>> FindAdUsersByGroupName(string groupName)
        {
            return Task.Run(() =>
            {
                var context = new PrincipalContext(ContextType.Domain, "credito.bcp.com.pe");
                using (var searcher = new PrincipalSearcher())
                {
                    var groupPrincipal = new GroupPrincipal(context, groupName);
                    searcher.QueryFilter = groupPrincipal;
                    var group = searcher.FindOne() as GroupPrincipal;
                    if (group == null)
                        throw new Exception("Group is not found");
                    
                    var users = new List<AdUser>();
                    foreach (var g in group.GetMembers())
                    {
                        var userPrincipal = g as UserPrincipal;
                        if(userPrincipal ==  null || string.IsNullOrEmpty(userPrincipal.Name))
                            continue;

                        users.Add(AdUser.MapToAdUser(userPrincipal));

                    }
                    return users;
                }                
            });
        }

        public Task<AdUser> GetAdUserByMatricula(string matricula)
        {
            return Task.Run(() =>
            {
                try
                {

                    PrincipalContext context = new PrincipalContext(ContextType.Domain, "credito.bcp.com.pe");
                    UserPrincipal principal = new UserPrincipal(context);
                    if (context is null)
                        return new AdUser();

                    principal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, matricula);

                    return AdUser.MapToAdUser(principal);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving AD User", ex);
                }
            });
        }

    }
}
