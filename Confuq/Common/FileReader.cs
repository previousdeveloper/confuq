using System.IO;
using System.Net;
using Common.Exception;
using Common.Interface;

namespace Common
{
    public class FileReader : IFileReader
    {
        public string Read(string url)
        {
            string result = null;

            if (string.IsNullOrEmpty(url))
            {
                throw new FileUrlException();
            }

            try
            {
                result = new WebClient().DownloadString(url);
            }
            catch (FileNotFoundException ex)
            {

                throw ex;
            }

            return result;
        }
    }
}