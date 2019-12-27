using System;
using System.Collections.Generic;

namespace Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate
{
    /// <summary>
    /// Request para la actualizacion flexible
    /// </summary>
    public class FlexibleUpdateRequestDto
    {
        /// <summary>
        /// Construye una instancia de la clase
        /// </summary>
        public FlexibleUpdateRequestDto()
        {
            this.InputFields = new Dictionary<string, string>();
        }

        /// <summary>
        /// Identificador de la orden
        /// </summary>
        public Guid IdWorkOrderFormType { get; set; }

        /// <summary>
        /// Id dentro del sistema
        /// </summary>
        public Guid? IdWorkOrder { get; set; }

        /// <summary>
        /// Id externo
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Function que se ejecutará, <see cref="string.Empty"/> para consumir el servicio del cliente
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Campos con los que se hace el request key = Id del campo, o nombre como lo espera el servicio, value: valor que se envía para la consulta
        /// </summary>
        public Dictionary<string, string> InputFields { get; set; }

        /// <summary>
        /// Nombre del usuario que esta solicitando la actualizacion flexible (el dato no se serializa porque se recupera del identity)
        /// </summary>
        public string Username { get; set; }

        /// <summary> 
        /// Nombre del tipo de orden, ejemplo, cobranza, verificacion, etc (el dato no se serializa porque se recupera del IdWorkOrderFormType)
        /// </summary>
        public string WorkOrderType { get; set; }

        /// <summary>
        /// Nombre del botón que se presiono para solicitar el update.
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Latitude de la última posición desde donde se presionó.
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Longitud de la última posición desde donde se presionó
        /// </summary>
        public float Longitude { get; set; }
    }
}