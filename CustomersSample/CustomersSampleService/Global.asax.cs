// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the WebApiApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CustomersSampleService
{
    /// <summary>
    /// The web api application.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The _web API configuration
        /// </summary>
        private readonly WebApiConfig _webApiConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiApplication"/> class.
        /// </summary>
        public WebApiApplication()
        {
            _webApiConfig = new WebApiConfig();
        }

        /// <summary>
        /// Application_s the start.
        /// </summary>
        protected void Application_Start()
        {
            _webApiConfig.Initialize();
        }
    }
}