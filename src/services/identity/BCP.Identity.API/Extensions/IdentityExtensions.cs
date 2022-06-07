using System.DirectoryServices.AccountManagement;
using BCP.Identity.API.Domain.Entities;

namespace BCP.Identity.API.Extensions
{
    public static class IdentityExtensions
    {
        public static IQueryable<UserPrincipal> FilterUsers(this IQueryable<UserPrincipal> principals) => principals.Where(user => user.Guid.HasValue);

        public static IQueryable<AdUser> SelectAdUsers(this IQueryable<UserPrincipal> principals) =>
         principals.Select(user => AdUser.MapToAdUser(user));
    }
}