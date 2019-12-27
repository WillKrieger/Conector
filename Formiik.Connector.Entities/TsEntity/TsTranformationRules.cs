using Microsoft.WindowsAzure.Storage.Table;

namespace Formiik.Connector.Entities.TsEntity
{
    public class TsTranformationRules : TableEntity
    {
        #region Properties

        public string Field
        {
            get => RowKey;
            set => RowKey = value;
        }
        
        /// <summary>
        /// Xslt expression for transformation
        /// </summary>
        public string TransformExpression
        {
            get; set;
        }

        /// <summary>
        /// True if result is array of objects, false if is an object
        /// </summary>
        public bool ResultIsArray { get; set; }

        /// <summary>
        /// Rule Type
        /// </summary>
        public int RuleType { get; set; }


        public string TabFormEdit
        {
            get; set;
        }

        public string DefinicionName
        {
            get; set;
        }

        #endregion
    }
}
