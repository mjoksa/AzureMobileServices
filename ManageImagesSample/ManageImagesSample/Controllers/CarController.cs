using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using AMSToolkit.Blob;
using AMSToolkit.Extensions;
using Microsoft.WindowsAzure.Mobile.Service;
using ManageImagesSample.DataObjects;
using ManageImagesSample.Models;

namespace ManageImagesSample.Controllers
{
    /// <summary>
    /// Class CarController.
    /// </summary>
    public class CarController : TableController<Car>
    {
        private MobileServiceContext _context;
        private const string Message = "Could not retrieve storage account settings.";

        /// <summary>
        /// Initializes the <see cref="T:System.Web.Http.ApiController" /> instance with the specified controllerContext.
        /// </summary>
        /// <param name="controllerContext">The <see cref="T:System.Web.Http.Controllers.HttpControllerContext" /> object that is used for the initialization.</param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Car>(_context, Request, Services);
        }

        // GET tables/Car
        /// <summary>
        /// Gets all cars.
        /// </summary>
        /// <returns>IQueryable&lt;Car&gt;.</returns>
        public IQueryable<Car> GetAllCars()
        {
            return Query();
        }

        // GET tables/Car/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Gets the cars.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SingleResult&lt;Car&gt;.</returns>
        public SingleResult<Car> GetCar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("The car not exist.");
            }
            if (!_context.Exist<Car>(id))
            {
                throw new ArgumentException("The car not exist.");
            }
            return Lookup(id);
        }

        // PATCH tables/Car/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Patches the cars.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="patch">The patch.</param>
        /// <returns>Task&lt;Car&gt;.</returns>
        public async Task<Car> PatchCar(string id, Delta<Car> patch)
        {
            var item = patch.GetEntity();
            if (!_context.Exist<Car>(id))
            {
                throw new ArgumentException("The customer not exist.");
            }
            if (string.IsNullOrEmpty(item.Name))
            {
                throw new ArgumentException("Your data is not correct.");
            }
            BlobItem blobItem = null;
            var urlToDelete = item.Url;
            string storageAccountName = string.Empty;
            string storageAccountKey = string.Empty;

            // the ImageName helps to know that a new image will be uploaded
            // this way, the last image will be delete and a new one will be created
            // the url is not reuse to avoid issue when apps has images in cache
            if (item.BlobItem != null && !string.IsNullOrEmpty(item.BlobItem.ImageName))
            {
                if (!(Services.Settings.TryGetValue("STORAGE_ACCOUNT_NAME", out storageAccountName) | Services.Settings.TryGetValue("STORAGE_ACCOUNT_ACCESS_KEY", out storageAccountKey)))
                {
                    throw new NullReferenceException(Message);
                }
                blobItem = await BlobItemManager.DefineAsync("CarPhoto", storageAccountName, storageAccountKey);
                blobItem.ImageName = item.BlobItem.ImageName;
                item.Url = blobItem.ImageUrl;
            }

            var current = await UpdateAsync(id, patch);
            if (string.IsNullOrEmpty(urlToDelete))
            {
                BlobItemManager.DeleteAsync(urlToDelete, storageAccountName, storageAccountKey);
            }
            current.BlobItem = blobItem;
            return current;
        }

        // POST tables/Car
        /// <summary>
        /// Posts the cars.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        public async Task<IHttpActionResult> PostCar(Car item)
        {
            // In this case is considered a imagem will be uploaded, each time a car is created
            if (string.IsNullOrEmpty(item.Name))
            {
                return BadRequest("Your data is not correct.");
            }
            string storageAccountName;
            string storageAccountKey;

            // Try to get the Azure storage account token from app settings.  
            if (!(Services.Settings.TryGetValue("STORAGE_ACCOUNT_NAME", out storageAccountName) | Services.Settings.TryGetValue("STORAGE_ACCOUNT_ACCESS_KEY", out storageAccountKey)))
            {
                throw new NullReferenceException(Message);
            }
            
            var blobItem = await BlobItemManager.DefineAsync("CarPhoto", storageAccountName, storageAccountKey);
            item.Url = blobItem.ImageUrl;
            var current = await InsertAsync(item);
            current.BlobItem = blobItem;
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Car/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Deletes the cars.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        public Task DeleteCar(string id)
        {
            if (!_context.Exist<Car>(id))
            {
                throw new ArgumentException("The customer not exist.");
            }
            return DeleteAsync(id);
        }
    }
}