namespace Application.Users
{
    public interface IHashPassword
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }
}