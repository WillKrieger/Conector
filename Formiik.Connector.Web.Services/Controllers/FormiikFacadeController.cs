using System.Threading.Tasks;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile.Contract;
using Formiik.Connector.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Formiik.Connector.Web.Services.Controllers
{
    /// <summary>
    /// Receive all request from Engine
    /// </summary>
    [Route("api/v1.0/formiik/[action]")]
    public class FormiikFacadeController : Controller
    {
        private readonly IRequirementProcessor _processor;

        public FormiikFacadeController(IRequirementProcessor requirementProcessor)
        {
            _processor = requirementProcessor;
        }
        
        /// <summary>
        /// Receive all notifications about requirements complete
        /// </summary>
        /// <param name="request">Requirements</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RequirementProcessingFinished([FromBody] IncomeRequirementInfoDto request)
        {
            if(request != null)
            {
                await _processor.ProcessRequirementReceived(request);

                return Ok();
            }

            return BadRequest();
        }
        
        /// <summary>
        /// Receive all notifications about instance creation
        /// </summary>
        /// <param name="request">Requirements</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InstanceCreationFinished([FromBody] InstanceCreationNotifDto request)
        {
            /// TODO: GMA Implement process
            /// Manejar error de duplicado, siempre regresar un 200 o 500 para errores internos, agregarlos a la doc.
            ApplicationLogger.LogInfo("Requerimiento completo", request.instanceId, parameters: request);

            return Ok();
        }
    }
}