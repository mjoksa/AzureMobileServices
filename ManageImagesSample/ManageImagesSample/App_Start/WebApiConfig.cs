using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Net.Http.Formatting;
using System.Web.Http;
using AutoMapper;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Config;
using ManageImagesSample.Migrations;

namespace ManageImagesSample
{
    /// <summary>
    /// The web api config.
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
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}