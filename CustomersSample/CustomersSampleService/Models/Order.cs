// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the Order type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace CustomersSampleService.Models
{
    /// <summary>
    /// The order.
    /// </summary>
    public class Order  : EntityData
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
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}