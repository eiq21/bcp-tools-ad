namespace BCP.User.API.Providers
{
    public interface IAdGroupProvider
    {
        Task<List<string>> GetAdGroupByMatricula(string enroll);
    }
}
