using System;
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
    /// Class OrderController.
    /// </summary>
    public class OrderController : TableController<OrderDto>
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
            DomainManager = new OrderDomainManager(_context, Request, Services);
        }

        // GET tables/Order
        /// <summary>
        /// Gets all order dto.
        /// </summary>
        /// <returns>IQueryable&lt;OrderDto&gt;.</returns>
        public IQueryable<OrderDto> GetAllOrderDto()
        {
            return Query(); 
        }

        // GET tables/Order/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Gets the order dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SingleResult&lt;OrderDto&gt;.</returns>
        public SingleResult<OrderDto> GetOrderDto(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Order/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Patches the order dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="patch">The patch.</param>
        /// <returns>Task&lt;OrderDto&gt;.</returns>
        /// <exception cref="System.ArgumentException">The customer not exist.</exception>
        public Task<OrderDto> PatchOrderDto(string id, Delta<OrderDto> patch)
        {
            if (!_context.Exist<Order>(id))
            {
                throw new ArgumentException("The customer not exist.");
            }
            return UpdateAsync(id, patch);
        }

        // POST tables/Order
        /// <summary>
        /// Posts the order dto.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        public async Task<IHttpActionResult> PostOrderDto(OrderDto item)
        {
            OrderDto current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Order/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Deletes the order dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentException">The customer not exist.</exception>
        public Task DeleteOrderDto(string id)
        {
            if (!_context.Exist<Order>(id))
            {
                throw new ArgumentException("The customer not exist.");
            }
             return DeleteAsync(id);
        }

    }
}