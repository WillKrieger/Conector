namespace Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate
{
    /// <summary>
    /// Palabras reservadas de formiik para el flexible update
    /// </summary>
    public class FlexibleUpdateReservedWordsDto
    {

        public FlexibleUpdateReservedWordsDto()
        {
        }

        public FlexibleUpdateReservedWordsDto(string key, string value)
        {
            ReservedWord = key;
            Value = value;
        }
        
        /// <summary>
        /// Identificador de la palabra reservada
        /// </summary>
        public string ReservedWord { get; set; }

        /// <summary>
        /// Valor de la palabra reservada
        /// </summary>
        public string Value { get; set; }
    }
}
