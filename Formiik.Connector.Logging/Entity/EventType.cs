namespace Formiik.Connector.Logging.Entity
{
    public enum EventType
    {
        /// <summary>
        /// Error de sistema
        /// </summary>
        Error = 1,

        /// <summary>
        /// Prosibles errores
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Seguimiento de operaciones
        /// </summary>
        Operation = 3,

        /// <summary>
        /// Eventos con información importante para almancenar
        /// </summary>
        Info = 4,
        
        /// <summary>
        /// Debug events
        /// </summary>
        Debug = 5
    }
}
