namespace DIP_Demo
{
    public class UserService
    {
        private readonly ILogger _logger;

        public UserService(ILogger logger)
        {
            _logger = logger;
        }

        public void RegisterUser(string username)
        {
            _logger.Log($"Registering user: {username}");
        }
    }
}