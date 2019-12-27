using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Formiik.Connector.Logging.Entity;
using Formiik.Connector.Logging.Persistance;

namespace Formiik.Connector.Logging
{
    public static class ApplicationLogger
    {
        public static string LogInfo(
            string message, 
            string externalId, 
            string transactionId = "",
            string formiikClientId = "",
            params object[] parameters)
        {
            var infoEvent = new TSApplicationEvent(EventType.Info.ToString(), message)
            {
                ExternalId = externalId,
                FormiikClientId = formiikClientId,
                TransactionId = transactionId,
                
            };

            try
            {
                Task.Factory.StartNew(() => WriteApplicationEvent(infoEvent, parameters));
            }
            catch
            {

            }

            return infoEvent.EventId;
        }

        public static string LogOperation(
            string message,
            string externalId,
            string transactionId = "",
            string formiikClientId = "",
            params object[] parameters)
        {
            var operationEvent = new TSApplicationEvent(EventType.Operation.ToString(), message)
            {
                ExternalId = externalId,
                FormiikClientId = formiikClientId,
                TransactionId = transactionId,
            };

            try
            {
                Task.Factory.StartNew(() => WriteApplicationEvent(operationEvent, parameters));
            }
            catch
            {

            }

            return operationEvent.EventId; throw new NotImplementedException();
        }

        public static string LogError(
            string externalId, 
            string message, 
            Exception exception, 
            string transactionId = "",
            string formiikClientId = "",
            params object[] parameters)
        {
            var errorEvent = new TSApplicationEvent(EventType.Error.ToString(), message)
            {
                ExternalId = externalId,
                FormiikClientId = formiikClientId,
                TransactionId = transactionId,
            };

            var aditionalData = new StringBuilder();

            var nivelError = 0;

            LoggerUtilities.GetDataFromException(exception, ref nivelError, ref aditionalData);

            errorEvent.StackTrace = aditionalData.ToString();

            try
            {
                Task.Factory.StartNew(() => WriteApplicationEvent(errorEvent, parameters));
            }
            catch
            {

            }
            return errorEvent.EventId;
        }

        public static string LogWarning(
            string message, 
            string externalId, 
            string transactionId = "",
            string formiikClientId = "",
            params object[] parameters)
        {

            var warningEvent = new TSApplicationEvent(EventType.Warning.ToString(), message)
            {
                ExternalId = externalId,
                FormiikClientId = formiikClientId,
                TransactionId = transactionId,
            };

            try
            {
                Task.Factory.StartNew(() => WriteApplicationEvent(warningEvent, parameters));
            }
            catch
            {

            }

            return warningEvent.EventId;
        }
        
        public static string LogDebug(
            string message, 
            string externalId = "", 
            string transactionId = "",
            string formiikClientId = "",
            params object[] parameters)
        {

            var warningEvent = new TSApplicationEvent(EventType.Debug.ToString(), message)
            {
                ExternalId = externalId,
                FormiikClientId = formiikClientId,
                TransactionId = transactionId,
            };

            try
            {
                Task.Factory.StartNew(() => WriteApplicationEvent(warningEvent, parameters));
            }
            catch
            {

            }

            return warningEvent.EventId;
        }

        private static void WriteApplicationEvent(TSApplicationEvent applicationEvent, params object[] parameters)
        {
            try
            {
                if (parameters != null)
                {
                    applicationEvent.FunctionParameters = LoggerUtilities.SerializeParameters(parameters);
                }

                IEventLogRepository repository = new EventLogRepository();
                repository.WriteEvent(applicationEvent);

            }
            catch (Exception exception)
            {
                var fatalEx = exception;
            }
        }
    }
}