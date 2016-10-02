using System.IO;
using System.Net;
using Common.Exception;
using Common.Interface;

namespace Common
{
    public class FileReader : IFileReader
    {
        private readonly IUrlBuilder _builder;

        public FileReader(IUrlBuilder builder)
        {
            _builder = builder;
        }

        public string Read()
        {
            string result = null;

            string url = _builder.Build();

            if (string.IsNullOrEmpty(url))
            {
                throw new FileUrlException();
            }

            try
            {
                result = new WebClient().DownloadString(url);
            }
            catch (FileUrlException ex)
            {

                throw ex;
            }

            return result;
        }
    }
}