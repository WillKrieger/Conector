using System.Collections.Generic;
using System.Text;

namespace Formiik.Connector.Entities.Engine.Dto
{
    public class GenericErrorApiEngineResDto : GenericApiEngineResDto
    {
        public string error { get; set; }

        public Dictionary<string, string> ErrorList { get; set; }

        public override string ToString()
        {
            StringBuilder errorSummary = new StringBuilder();

            if (ErrorList != null)
            {
                foreach (var item in ErrorList)
                {
                    errorSummary.AppendLine($"{item.Key}:{item.Value}");
                }
            }
            else
            {
                errorSummary.Append(error);
            }

            return errorSummary.ToString();
        }
    }
}