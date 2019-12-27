using System;

namespace Formiik.Connector.Entities.CustomExceptions
{
    /// <summary>
    /// Raise when engine not confirm some operation
    /// </summary>
    public class MissingConfirmEngineEx : Exception
    {
        public MissingConfirmEngineEx(string message) : base(message)
        {
        }
    }
}