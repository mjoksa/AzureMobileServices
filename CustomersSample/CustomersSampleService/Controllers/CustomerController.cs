using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using CustomersSampleService.DataObjects;
using CustomersSampleService.DomainManagers;
using CustomersSampleService.Extensions;
using CustomersSampleService.Models;

namespace CustomersSampleService.Controllers
{
    /// <summary>
    /// Class CustomerController.
    /// </summary>
    public class CustomerController : TableController<CustomerDto>
    {
        /// <summary>
        /// The _context
        /// </summary>
        private ExistingContext _context;

        /// <summary>
        /// Initializes the <see cref="T:System.Web.Http.ApiController" /> instance with the specified controllerContext.
        /// </summary>
        /// <param name="controllerContext">The <see cref="T:System.Web.Http.Controllers.HttpControllerContext" /> object that is used for the initialization.</param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new ExistingContext();
            DomainManager = new CustomerDomainManager(_context, Request, Services);
        }

        // GET tables/Customer
        /// <summary>
        /// Gets all customer dto.
        /// </summary>
        /// <returns>IQueryable&lt;CustomerDto&gt;.</returns>
        public IQueryable<CustomerDto> GetAllCustomerDto()
        {
           return Query();
        }

        // GET tables/Customer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Gets the customer dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SingleResult&lt;CustomerDto&gt;.</returns>
        public SingleResult<CustomerDto> GetCustomerDto(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Customer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Patches the customer dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="patch">The patch.</param>
        /// <returns>Task&lt;CustomerDto&gt;.</returns>
        /// <exception cref="System.ArgumentException">
        /// The customer not exist.
        /// or
        /// Your data is not correct.
        /// </exception>
        public Task<CustomerDto> PatchCustomerDto(string id, Delta<CustomerDto> patch)
        {
            var item = patch.GetEntity();
            if (!_context.Exist<Customer>(id))
            {
                throw new ArgumentException("The customer not exist.");
            }
            if (string.IsNullOrEmpty(item.Name))
            {
                throw new ArgumentException("Your data is not correct.");
            }
             return UpdateAsync(id, patch);
        }

        // POST tables/Customer
        /// <summary>
        /// Posts the customer dto.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        public async Task<IHttpActionResult> PostCustomerDto(CustomerDto item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                return BadRequest("Your data is not correct.");
            }
            CustomerDto current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Customer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Deletes the customer dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentException">The customer not exist.</exception>
        public Task DeleteCustomerDto(string id)
        {
            if (!_context.Exist<Customer>(id))
            {
                throw new ArgumentException("The customer not exist.");
            }
            return DeleteAsync(id);
        }
    }
}