using System.Threading.Tasks;
using Formiik.Connector.Entities.TsEntity;
using Formiik.Connector.Web.Services.AppCode;
using Formiik.Connector.Web.Services.AppCode.Config;
using Formiik.Connector.Web.Services.CustomExtenssions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using  System.Threading;
using Formiik.Connector.Entities.Engine;

namespace Formiik.Connector.Web.Services
{
    public class Startup
    {
        private const string APP_INFO_CONFIG = "AppInfo";
        
        private const string ENGINE_CONFIG_KEY = "ConfigEngine:SignalRConnection";
        
        private const string ENGINE_API_CONFIG_KEY = "ConfigEngine:Api";
        
        private const string APP_CONFIG_FILE = "appsettings.json";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(APP_CONFIG_FILE, optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // configure workorder processor
            services.ConfigureFormiikProcessors();
            
            // configure flexibleupdate processor
            services.ConfigurePlatformProcessor();
                            
            services.Configure<AppInfo>(Configuration.GetSection(APP_INFO_CONFIG));
            
            services.Configure<ApiEngineConfiguration>(Configuration.GetSection(ENGINE_API_CONFIG_KEY));
            
            IConfigurationSection signalRConfigSection = Configuration.GetSection(ENGINE_CONFIG_KEY);

            SignalRConfig conf = signalRConfigSection.Get<SignalRConfig>();
           
            SignalRClient.SetConfig(conf, services);
            
            IConfigurationSection apiConfigSection = Configuration.GetSection(ENGINE_API_CONFIG_KEY);
    
            ApiEngineConfiguration confApi = apiConfigSection.Get<ApiEngineConfiguration>();
        
            IOptions<ApiEngineConfiguration> optionsX = Options.Create(confApi);
            
#if !DEBUG  
            Task.Run(() => SignalRClient.InitSignalRConnection(optionsX));
#endif  
        }
 


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.ConfigureCustomExceptionMiddleware();
            
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseHsts();
//            }

            app.UseHttpsRedirection();
            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
        }
    }
}