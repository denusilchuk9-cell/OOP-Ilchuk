using System;
using System.Text;

namespace lab25
{
    public class EncryptDataStrategy : IDataProcessorStrategy
    {
        public string ProcessData(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            string encrypted = Convert.ToBase64String(bytes);
            return $"[ENCRYPTED] {encrypted}";
        }
    }
}