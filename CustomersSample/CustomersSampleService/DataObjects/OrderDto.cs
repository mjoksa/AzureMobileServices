// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderDto.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the OrderDto type.
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
    /// The mobile order.
    /// </summary>
#if !PCL
    public class OrderDto : EntityData
#else
    public class Order : EntityData
#endif
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether completed.
        /// </summary>
        /// <value>
        /// The completed.
        /// </value>
        public bool Completed { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>
        /// The customer id.
        /// </value>
        public string CustomerId { get; set; }
        
        /// <summary>
        /// Gets or sets the mobile customer name.
        /// </summary>
        /// <value>
        /// The mobile customer name.
        /// </value>
        public string CustomerName { get; set; }
    }
}