namespace MailBo.Contracts
{
    public interface UserRepository
    {
        string Login(string username, string password);
        string GetMessages(string sessionID);
    }
}
