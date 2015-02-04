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

            CarsService = new MobileServiceClient("https://manageimagessample.azure-mobile.net/", "InmhgTMcMfDuthrSVmFhXGhWFvHuqP68")
            {
                SerializerSettings = new MobileServiceJsonSerializerSettings()
                {
                    CamelCasePropertyNames = true
                }
            };
        }

        /// <summary>
        /// Gets or sets the cars service.
        /// </summary>
        /// <value>
        /// The customers service.
        /// </value>
        public static MobileServiceClient CarsService { get; set; }
    }
}
