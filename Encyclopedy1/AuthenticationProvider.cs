namespace Encyclopedy1
{
    using Models;

    /// <summary>
    /// Singleton class of logged user.
    /// </summary>
    public class AuthenticationProvider
    {
        private static AuthenticationProvider _instance;

        private AuthenticationProvider()
        {
        }

        public User LoggedUser { get; set; }
        /// <summary>
        /// Returns the instance of logined user.
        /// </summary>
        /// <returns></returns>
        public static AuthenticationProvider GetInstance()
        {
            return _instance ?? (_instance = new AuthenticationProvider());
        }
    }
}