using System;

namespace Test.Exceptions
{
    public abstract class ApiException : Exception
    {
        public ApiException(string message)
            :base(message)
        {

        }


        public abstract int Code { get; }
    }
}
