namespace UserSingleton2.Models.Service
{
    public interface IUserSession
    {
        string GetSessionId();
        void SetSessionId(string sessionId);
    }
}
