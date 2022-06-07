using BCP.User.API.Domain.Entities;

namespace BCP.User.API.Providers
{
    public interface IAdUserProvider
    {
        Task<AdUser> GetAdUserByMatricula(string matricula);
        Task<List<AdUser>> FindAdUsersByGroupName(string groupName);
    }
}
