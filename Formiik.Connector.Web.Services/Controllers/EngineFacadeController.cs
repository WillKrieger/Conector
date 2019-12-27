using System.Threading.Tasks;
using Formiik.Connector.Entities.Engine.Contract;
using Formiik.Connector.Entities.Mobile.Dto.FlexibleUpdate;
using Formiik.Connector.Web.Services.CustomExtenssions;
using Microsoft.AspNetCore.Mvc;

namespace Formiik.Connector.Web.Services.Controllers
{
    /// <summary>
    /// Recibe todas las peticiones provenientes de formiik
    /// </summary>
    [Route("api/v1.0/platform/[action]")]
    public class EngineFacadeController : Controller
    {
        private readonly IFlexibleUpdateProcessor _flexibleUpdateProcessor;
        private readonly IResponsesProcessor _responsesProcessor;
        
        public EngineFacadeController(IFlexibleUpdateProcessor flexibleUpdateProcessor, IResponsesProcessor responsesProcessor)
        {
            _flexibleUpdateProcessor = flexibleUpdateProcessor;
            _responsesProcessor = responsesProcessor;
        }
       
        /// <summary>
        /// Process flexibgit le udpate requests see: https://formiik.atlassian.net/wiki/spaces/FD/pages/40239197/FlexibleUpdateWorkOrder+-+Actualizaci+n+de+rdenes+P2P
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> FlexibleUpdateWorkOrder()
        {
            var request = await Request.GetRawBodyAsync<FlexibleUpdateRequestDto>();
            var incomeHeaders = Request.GetHeaders();

            FlexibleUpdateResponseDto response =  await _flexibleUpdateProcessor.SendRequestToPlatform(incomeHeaders, request);

            return Ok(response);
        }
        
//        [HttpPost]
//        public async Task<IActionResult> GetUpdateWaitProcess()
//        {
//            var request = await Request.GetRawBodyAsync<FlexibleUpdateRequest>();
//            var incomeHeaders = Request.GetHeaders();
//
//            FlexibleUpdateResponse response = await _flexibleUpdateProcessor.SendRequestToPlatform(incomeHeaders, request);
//
//            return Ok(response);
//        }
        
        /// <summary>
        /// Resuelve las solititude de recepción de respuestas 
        /// </summary>
        /// <param name="body">
        /// XML de respuesta, ver: https://formiik.atlassian.net/wiki/spaces/FD/pages/40796233/Env+o+de+Respuesta+a+Cliente
        /// </param>
        /// <returns>string vacío</returns>
        [HttpPost]
        public async Task<IActionResult> SendWorkOrderToClient()
        {
            var xmlResponse = await Request.GetRawBodyAsync();
            var incomeHeaders = Request.GetHeaders();

            string errorDetails = await _responsesProcessor.ProcessResponse(incomeHeaders, xmlResponse);
            
            if (string.IsNullOrEmpty(errorDetails))
            {
                return Ok();    
            }
            
            return BadRequest(errorDetails);
        }
    }
}