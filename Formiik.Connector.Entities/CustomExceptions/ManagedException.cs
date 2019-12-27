using System;

namespace Formiik.Connector.Entities.CustomExceptions
{
    /// <summary>
    /// Special exception to bubble errors
    /// </summary>
    public class ManagedException : Exception
    {
        public ManagedException(string message) : base(message)
        {
        }
    }
}