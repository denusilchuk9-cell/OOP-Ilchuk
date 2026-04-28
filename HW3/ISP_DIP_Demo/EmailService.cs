namespace DIP_Demo
{
    public class EmailService
    {
        private readonly ILogger _logger;

        public EmailService(ILogger logger)
        {
            _logger = logger;
        }

        public void SendEmail(string to)
        {
            _logger.Log($"Sending email to: {to}");
        }
    }
}