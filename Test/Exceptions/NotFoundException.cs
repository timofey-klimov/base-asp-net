using System;

namespace Test.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(Type type)
            : base($"{type.Name} not found")
        {

        }
        public override int Code => 404;
    }
}
