using BCP.User.API.Domain.Entities;
using System.DirectoryServices.AccountManagement;

namespace BCP.User.API.Providers
{
    public class AdGroupProvider : IAdGroupProvider
    {
        public  Task<List<string>> GetAdGroupByMatricula(string matricula)
        {
                return Task.Run(() =>
                {
                    try
                    {
                        PrincipalContext context = new PrincipalContext(ContextType.Domain, "credito.bcp.com.pe");
                        UserPrincipal principal = new UserPrincipal(context);
                        if (context is null)
                            return new List<string>();

                        principal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, matricula);

                        var groupsAuthorization = principal.GetAuthorizationGroups();

                        var groupsResult = new List<string>();

                        foreach (var group in groupsAuthorization)
                            groupsResult.Add(group.ToString());

                        return groupsResult.OrderBy(element => element[0]).ToList();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving AD User", ex);
                    }
                
            });
        }
    }
}
