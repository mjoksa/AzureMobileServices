namespace ManageImagesSample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public WebApiConfig _webApiConfig;

        public WebApiApplication()
        {
            _webApiConfig = new WebApiConfig();
        }

        protected void Application_Start()
        {
            _webApiConfig.Initialize();
        }
    }
}