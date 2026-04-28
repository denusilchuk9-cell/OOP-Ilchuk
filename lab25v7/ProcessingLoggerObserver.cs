namespace lab25
{
    public class ProcessingLoggerObserver
    {
        public void OnDataProcessed(string processedData)
        {
            LoggerManager.Instance.Log($"Data processed: {processedData}");
        }
    }
}