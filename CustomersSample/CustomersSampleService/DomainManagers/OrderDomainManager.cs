// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderDomainManager.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the MobileOrderDomainManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using CustomersSampleService.DataObjects;
using CustomersSampleService.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace CustomersSampleService.DomainManagers
{
    /// <summary>
    /// The mobile order domain manager.
    /// </summary>
    public class OrderDomainManager : MappedEntityDomainManager<OrderDto, Order>
    {
        private CustomersContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDomainManager"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="services">
        /// The services.
        /// </param>
        public OrderDomainManager(CustomersContext context, HttpRequestMessage request, ApiServices services)
            : base(context, request, services)
        {
            Request = request;
            this._context = context;
        }

        /// <summary>
        /// Sets the original version.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="version">The version.</param>
        protected override void SetOriginalVersion(Order model, byte[] version)
        {
            _context.Entry(model).OriginalValues["Version"] = version;
        }

        /// <summary>
        /// The lookup.
        /// </summary>
        /// <param name="id">
        /// The mobile order id.
        /// </param>
        /// <returns>
        /// The <see cref="SingleResult"/>.
        /// </returns>
        public override SingleResult<OrderDto> Lookup(string id)
        {
            return LookupEntity(o => o.Id == id);
        }
        
        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="mobileOrder">The mobile order.</param>
        /// <returns>The Mobile Order.</returns>
        public override async Task<OrderDto> InsertAsync(OrderDto mobileOrder)
        {
            return await base.InsertAsync(mobileOrder);
        }

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="id">
        /// The mobile order id.
        /// </param>
        /// <param name="patch">
        /// The patch.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// The exception <exception cref="HttpResponseException">.
        /// </exception>
        public override async Task<OrderDto> UpdateAsync(string id, Delta<OrderDto> patch)
        {
            return await base.UpdateEntityAsync(patch, id);
        }
        
        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="id">
        /// The mobile order id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override async Task<bool> DeleteAsync(string id)
        {
            return await DeleteItemAsync(id);
        }
    }
}