// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MobileCustomer.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The mobile customer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Mobile.Service;

namespace CustomersSampleService.DataObjects
{
    /// <summary>
    /// The mobile customer.
    /// </summary>
#if !PCL
    public class CustomerDto : EntityData
#else
    public class Customer : EntityData
#endif
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}