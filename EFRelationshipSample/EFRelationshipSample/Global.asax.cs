namespace EFRelationshipSample
{
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
        /// The application the start.
        /// </summary>
        protected void Application_Start()
        {
            _webApiConfig.Initialize();
        }
    }
}