// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDto.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The CustomerDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if PCL
using AMSToolkit.Model;
#else
using Microsoft.WindowsAzure.Mobile.Service;
#endif

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