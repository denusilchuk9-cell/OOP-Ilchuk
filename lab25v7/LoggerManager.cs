namespace lab25
{
    public class LoggerManager
    {
        private static LoggerManager _instance;
        private ILoggerFactory _factory;
        private ILogger _logger;

        private LoggerManager() { }

        public static LoggerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoggerManager();
                }
                return _instance;
            }
        }

        public void SetLoggerFactory(ILoggerFactory factory)
        {
            _factory = factory;
            _logger = _factory.CreateLogger();
        }

        public void Log(string message)
        {
            _logger?.Log(message);
        }
    }
}