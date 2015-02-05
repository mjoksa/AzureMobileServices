using System.Data.Entity.Migrations;
using System.Web.Http;
using AzureMobileService.Migrations;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Config;

namespace AzureMobileService
{
    /// <summary>
    /// Define the WebApiConfig.
    /// </summary>
    public class WebApiConfig : IBootstrapper
    {
        /// <summary>
        /// Defines the entry point for the application. It is the responsibility of this entry point
        /// to call <see cref="T:Microsoft.WindowsAzure.Mobile.Service.ServiceConfig" /> which will start the configuration of the application.
        /// </summary>
        public void Initialize()
        {
            // Use this class to set configuration options for your mobile service
            var options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            var config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var migrator = new DbMigrator(new Configuration());
            migrator.Update();

            // to re-target to a especific migration version uses
            //migrator.Update("<migration name>");
        }
    }
}

