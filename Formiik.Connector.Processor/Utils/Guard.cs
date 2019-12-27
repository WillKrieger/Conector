using Formiik.Connector.Entities.CustomExceptions;

namespace Formiik.Connector.Processor.Utils
{
    internal static class Guard
    {
        private const string MISSING_DATA = "Missing data";

        public static void AvoidNulls(object data, string propertyName = "")
        {
            if (data == null)
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ManagedException(MISSING_DATA);
                }
                else
                {
                    throw new ManagedException($"{MISSING_DATA}: '{propertyName}'");
                }
            }
        }

        public static void AvoidStringNullOrEmpty(string value, string propertyName = "")
        {
            if (string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ManagedException(MISSING_DATA);
                }
                else
                {
                    throw new ManagedException($"{MISSING_DATA}: '{propertyName}'");
                }
            }
        }
    }
}