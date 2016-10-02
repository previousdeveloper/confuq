using System;

namespace Client
{
    public class GithubKeyNotFoundException : Exception
    {
        public GithubKeyNotFoundException() : base()

        {

        }
        public GithubKeyNotFoundException(String message) : base(message)
        {

        }

        public GithubKeyNotFoundException(String message, Exception innerException) : base(message, innerException)
        {

        }
    }
}