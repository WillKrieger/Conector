using System;

namespace Formiik.Connector.Entities.CustomExceptions
{
    public class InvalidInputDataException : Exception
    {
        public InvalidInputDataException(string message) : base(message)
        {
        }
    }
}