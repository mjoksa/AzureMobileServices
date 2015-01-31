// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AzureMobileService.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The azure mobile service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.WindowsAzure.MobileServices;

namespace CustomersSample
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

            CustomersService = new MobileServiceClient("http://customersample.azure-mobile.net/", "WfSPqJCRgYXCyQycqMTTUWPtpNvOfg19")
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
