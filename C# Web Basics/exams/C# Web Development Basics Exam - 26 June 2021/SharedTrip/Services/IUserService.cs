namespace SharedTrip.Services
{
    public interface IUserService
    {
        void Register(string username, string email, string password);

        string GetUserId(string username, string password);

        string GetUsernameById(string Id);

        bool UsernameExists(string username);

        bool EmailExists(string email);
    }
}