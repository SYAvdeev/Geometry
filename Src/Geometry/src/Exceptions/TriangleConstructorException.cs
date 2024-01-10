using System;

namespace Geometry.Exceptions
{
    public class TriangleConstructorException : Exception
    {
        public TriangleConstructorException()
        {
        }

        public TriangleConstructorException(string message) : base(message)
        {
        }
    }
}