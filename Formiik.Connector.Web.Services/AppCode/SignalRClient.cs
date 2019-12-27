using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Formiik.Connector.Entities.Engine;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile.Contract;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Logging;
using Formiik.Connector.Processor.MobileProxy;
using Formiik.Connector.Web.Services.AppCode.Config;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace Formiik.Connector.Web.Services.AppCode
{
    public static class SignalRClient
    {
        private const string REQUIREMENT_RECEIVED = "Requisito recibido de engine contenedor ({0}): StatusContainer ({1}), CustomStatusContainer ({2})";
        private const string CANCELLATION_RECEIVED = "Instancia {0} cancelada";
        private const string NO_IMPLEMENT_SERVICE = "Servicio 'IRequirementProcessor' no implementado";
        private const string CONNECTION_SUCCESS ="Conexión exitosa";
        private const string ERROR_CLOSE_CONNECTION ="Error al conectarse";
        private const string CONNECTION_ERROR ="Error de conexión";
        private const string API_KEY_HEADER = "ApiKey";
        private const string JOIN_CHANNEL ="JoinChannel";
        
        private static HubConnection _signalRConnection;

        private static SignalRConfig _config;
        
        //private static IRequirementProcessor _processor;

        public static void SetConfig(SignalRConfig config, IServiceCollection serviceCollection)
        {
            _config = config;
        }

        public static async Task InitSignalRConnection(IOptions<ApiEngineConfiguration> constantes)
        {
            _signalRConnection = new HubConnectionBuilder()
                .WithUrl(_config.Url, options => { options.Headers.Add(API_KEY_HEADER, _config.ApiKey); }
                ).AddJsonProtocol(options =>
                {
                    options.PayloadSerializerSettings.ContractResolver = new DefaultContractResolver();
                })
                .Build();

            _signalRConnection.Closed += async (error) =>
            {
                ApplicationLogger.LogDebug(ERROR_CLOSE_CONNECTION);
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await SignalRStartAsync();
            };

//            _signalRConnection.On<InstanceCreationNotifDto>(_config.InstanceCreationFinishedMethod,
//                (instanceInfo) =>
//                {
//                    ApplicationLogger.LogInfo("InstanceCreationFinishedReceived", instanceInfo.instanceId);
//                });

            _signalRConnection.On<IncomeRequirementInfoDto>(_config.InstanceProcessingFinishedMethod, (notification) =>
            {
                ApplicationLogger.LogInfo(
                                    string.Format(
                                        REQUIREMENT_RECEIVED,
                                        notification.containerId,
                                        notification.statusContainer,
                                        notification.customStatusContainer),
                                    notification.instanceId,
                                    parameters: notification);

                IRequirementProcessor processor = new RequirementProcessor(constantes);
                processor.ProcessRequirementReceived(notification).Start();
               
            });

            _signalRConnection.On<IncomeInstanceCancelledDto>(_config.InstanceCancelledMethod, (notification) =>
            {

                ApplicationLogger.LogInfo(
                                   string.Format(
                                       REQUIREMENT_RECEIVED,
                                       notification.instanceId),
                                   notification.instanceId,
                                   parameters: notification);

                IRequirementProcessor processor = new RequirementProcessor(constantes);
                processor.ProcessInstanceCancellation(notification).Start();
            });

            await SignalRStartAsync();
        }

        private static async Task SignalRStartAsync()
        {
            try
            {
                await _signalRConnection.StartAsync();

                await _signalRConnection.SendAsync(JOIN_CHANNEL, _config.Channel);
                
                ApplicationLogger.LogDebug(CONNECTION_SUCCESS);
            }
            catch
            {
                Console.WriteLine(CONNECTION_ERROR);
                
                await Task.Delay(new Random().Next(0,5) * 1000);
                
                await SignalRStartAsync();
            }
        }

    }
}