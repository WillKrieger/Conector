using System;
using Formiik.Connector.Entities.Engine.Contract;
using Formiik.Connector.Entities.Mobile.Contract;
using Formiik.Connector.Processor.EngineProxy;
using Formiik.Connector.Processor.MobileProxy;
using Formiik.Connector.Web.Services.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Formiik.Connector.Web.Services.CustomExtenssions
{
    public static class WebAppExtensions
    {
        /// <summary>
        /// Error handler
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        /// <summary>
        /// Configure all processors 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureFormiikProcessors(this IServiceCollection services)
        {
            services.AddTransient<IRequirementProcessor, RequirementProcessor>();
        }

        /// <summary>
        /// Platform configuration processors
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigurePlatformProcessor(this IServiceCollection services)
        {
            services.AddTransient<IFlexibleUpdateProcessor, FlexibleUpdateProcessor>();
            services.AddTransient<IResponsesProcessor, ResponsesProcessor>();
        }
       
    }
}