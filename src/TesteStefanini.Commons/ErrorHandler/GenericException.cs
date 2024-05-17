using System;

namespace TesteStefanini.Commons.ErrorHandler
{
    public class GenericException : Exception
    {
        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public GenericException() { }

        public GenericException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            ErrorMessage = message;
        }

    }

    public class GenericException<T> : Exception
    {
        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
