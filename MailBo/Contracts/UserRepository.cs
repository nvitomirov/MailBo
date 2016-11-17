namespace MailBo.Contracts
{
    public interface UserRepository
    {
        bool Login(string username, string password);
        string GetMessages(string username);
    }
}
