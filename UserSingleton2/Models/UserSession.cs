using UserSingleton2.Models.Service;

namespace UserSingleton2.Models
{
    public class UserSession : IUserSession
    {
        private static UserSession _instance;
        private static readonly object _lock = new object();
        private string _sessionId;

        private UserSession() { }
        public static UserSession Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserSession();
                    }
                    return _instance;
                }
            }
        }
        public string GetSessionId()
        {
            return _sessionId;
        }

        public void SetSessionId(string sessionId)
        {
            _sessionId = sessionId;
        }
    }
}
