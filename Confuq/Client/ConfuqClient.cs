using System;
using Client.Interface;

namespace Client
{
    public class ConfuqClient : IConfuqClient
    {
        public T Get<T>(T key)
        {
            string value = null;
            

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}