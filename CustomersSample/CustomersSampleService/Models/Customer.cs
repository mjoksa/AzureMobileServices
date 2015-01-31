// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the Customer type. Cool :) Just testing, if I am able to commit changes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace CustomersSampleService.Models
{
    /// <summary>
    /// The customer.
    /// </summary>
    public class Customer : EntityData
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public virtual ICollection<Order> Orders { get; set; }
    }
}