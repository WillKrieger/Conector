using System.Collections.Generic;

namespace Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate
{
    public class FlexibleUpdateResponseDto
    {
        public FlexibleUpdateResponseDto()
        {
            this.UpdateFieldsValues = new Dictionary<string, string>();

            this.AfectedFields = new List<FlexibleFieldDto>();

            this.FormiikReservedWords = new List<FlexibleUpdateReservedWordsDto>();
        }

        /// <summary>
        /// Listado de campos de los que debe actualizar el valor Key = KeyForSave, Value = Nuevo valor
        /// </summary>
        public Dictionary<string, string> UpdateFieldsValues { get; set; }

        /// <summary>
        /// Elementos de los que debe modificar el comportamiento (la cantidad de elementos son opcionales, FieldName)
        /// </summary>
        public List<FlexibleFieldDto> AfectedFields { get; set; }

        /// <summary>
        /// Palabras reservadas de Formiik
        /// </summary>
        public List<FlexibleUpdateReservedWordsDto> FormiikReservedWords { get; set; }
    }
}
