using System.Collections.Generic;

namespace Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate
{   
    public class FlexibleFieldDto
    {
        public FlexibleFieldDto()
        {
            this.Settings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Crea una instancia de la clase
        /// </summary>
        /// <param name="name">Nombre del campo</param>
        public FlexibleFieldDto(string name)
        {
            this.Name = name;
            this.Settings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Identificador del campo (FieldName)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Settings para el campo
        /// </summary>
        public Dictionary<string, string> Settings { get; set; }
    }
}
