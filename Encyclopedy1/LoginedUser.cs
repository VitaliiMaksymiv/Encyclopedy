namespace Encyclopedy
{
    class LoginedUser
    {
        public User User {get; set; }
        private LoginedUser()
        {
        }
        private static LoginedUser _instance;
        public static LoginedUser GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoginedUser();
            }
            return _instance;
        }
    }
}