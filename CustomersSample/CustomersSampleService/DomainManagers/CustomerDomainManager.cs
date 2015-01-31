// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDomainManager.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The mobile customer domain manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    /// The mobile customer domain manager.
    /// </summary>
    public class CustomerDomainManager : MappedEntityDomainManager<CustomerDto, Customer>
    {
        private CustomersContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDomainManager"/> class.
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
        public CustomerDomainManager(CustomersContext context, HttpRequestMessage request, ApiServices services)
            : base(context, request, services)
        {
            Request = request;
            this._context = context;
        }

        /// <summary>
        /// The lookup.
        /// </summary>
        /// <param name="id">
        /// The mobile customer id.
        /// </param>
        /// <returns>
        /// The <see cref="SingleResult"/>.
        /// </returns>
        public override SingleResult<CustomerDto> Lookup(string id)
        {
            return LookupEntity(c => c.Id == id);
        }

        /// <summary>
        /// The insert async.
        /// </summary>
        /// <param name="mobileCustomer">
        /// The mobile customer.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override async Task<CustomerDto> InsertAsync(CustomerDto mobileCustomer)
        {
            return await base.InsertAsync(mobileCustomer);
        }

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="id">
        /// The mobile customer id.
        /// </param>
        /// <param name="patch">
        /// The patch.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1603:DocumentationMustContainValidXml", Justification = "Reviewed. Suppression is OK here.")]
        public override async Task<CustomerDto> UpdateAsync(string id, Delta<CustomerDto> patch)
        {
            return await base.UpdateEntityAsync(patch,id);
        }

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="id">
        /// The mobile customer id.
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