using Microsoft.WindowsAzure.MobileServices;
namespace ManageImagesSample.Pcl
{
    /// <summary>
    /// The azure mobile service.
    /// </summary>
    public static class AzureMobileService
    {
        /// <summary>
        /// Initializes static members of the <see cref="AzureMobileService"/> class. 
        /// </summary>
        static AzureMobileService()
        {
            //CustomersService = new MobileServiceClient("http://localhost:53669/")
            //{
            //    SerializerSettings = new MobileServiceJsonSerializerSettings()
            //    {
            //        CamelCasePropertyNames = true
            //    }
            //};

            CustomersService = new MobileServiceClient("", "")
            {
                SerializerSettings = new MobileServiceJsonSerializerSettings()
                {
                    CamelCasePropertyNames = true
                }
            };
        }

        /// <summary>
        /// Gets or sets the customers service.
        /// </summary>
        /// <value>
        /// The customers service.
        /// </value>
        public static MobileServiceClient CustomersService { get; set; }
    }
}
