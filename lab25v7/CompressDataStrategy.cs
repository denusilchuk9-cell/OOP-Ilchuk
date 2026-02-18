namespace lab25
{
    public class CompressDataStrategy : IDataProcessorStrategy
    {
        public string ProcessData(string data)
        {
            if (data.Length > 10)
            {
                return $"[COMPRESSED] {data.Substring(0, 5)}...{data.Substring(data.Length - 5)}";
            }
            return $"[COMPRESSED] {data}";
        }
    }
}