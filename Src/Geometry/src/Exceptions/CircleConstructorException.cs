using System;

namespace Geometry.Exceptions
{
    public class CircleConstructorException : Exception
    {
        public CircleConstructorException()
        {
        }

        public CircleConstructorException(string message) : base(message)
        {
            
        }
    }
}