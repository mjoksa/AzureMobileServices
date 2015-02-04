using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AMSToolkit.Blob;
using ManageImagesSample.DataObjects;
using ManageImagesSample.Pcl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.MobileServices;

namespace ManageImagesSample.Tests
{
    /// <summary>
    /// Defines the test for Mobile Car.
    /// </summary>
    [TestClass]
    public class CarControllerTest
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        [TestMethod]
        public async Task GetAllAsync()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CarsService.GetTable<Car>();
                var items = await table.ToListAsync();

                Assert.IsNotNull(items);
            }
            catch (MobileServiceInvalidOperationException mobileServiceInvalidOperationException)
            {
                exception = mobileServiceInvalidOperationException;
            }
            if (exception != null)
            {
                var content = await exception.Response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                Assert.Fail(content);
            }
            Assert.IsNull(exception);
        }

        /// <summary>
        /// Gets the by.
        /// </summary>
        [TestMethod]
        public async Task GetByAsync()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CarsService.GetTable<Car>();
                var items = await table.ToListAsync();
                Assert.IsNotNull(items);
                Car item = null;
                if (items.Any())
                {
                    item = await table.LookupAsync(items.First().Id);
                    Assert.IsNotNull(item);
                }
                else
                {
                    Assert.IsNotNull(items);
                    Assert.IsNull(item);
                }
            }
            catch (MobileServiceInvalidOperationException mobileServiceInvalidOperationException)
            {
                exception = mobileServiceInvalidOperationException;
            }
            if (exception != null)
            {
                var content = await exception.Response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                Assert.Fail(content);
            }
            Assert.IsNull(exception);
        }

        /// <summary>
        /// Test delete Car
        /// </summary>
        [TestMethod]
        public async Task DeleteCarAsync()
        {
            // this depend on the application requirements
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CarsService.GetTable<Car>();
                const string name = "Test";
                var car = new Car
                {
                    Name = name
                };
                await table.InsertAsync(car);

                //confirm the information received
                Assert.IsNotNull(car.Name);
                Assert.IsNotNull(car.BlobItem);
                Assert.IsNotNull(car.BlobItem.ContainerName);
                Assert.IsNotNull(car.BlobItem.ImageGuid);
                Assert.IsNull(car.BlobItem.ImageName);
                Assert.IsNotNull(car.BlobItem.SasQueryString);
                Assert.IsNotNull(car.BlobItem.ImageUrl);
                Assert.AreEqual(car.Name, name);
                Assert.IsNotNull(car.UpdatedAt);
                Assert.IsNotNull(car.CreatedAt);

                await table.DeleteAsync(car);

            }
            catch (MobileServiceInvalidOperationException mobileServiceInvalidOperationException)
            {
                exception = mobileServiceInvalidOperationException;
            }
            if (exception != null)
            {
                var content = await exception.Response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                Assert.Fail(content);
            }
        }

        /// <summary>
        /// Test insert Car
        /// </summary>
        [TestMethod]
        public async Task InsertCarAsync()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CarsService.GetTable<Car>();
                const string name = "Test";
                var car = new Car
                {
                    Name = name
                };
                await table.InsertAsync(car);

                //confirm the information received
                Assert.IsNotNull(car.Id);
                Assert.IsNotNull(car.Name);
                Assert.IsNotNull(car.Url);
                Assert.IsNotNull(car.BlobItem);
                Assert.IsNotNull(car.BlobItem.ContainerName);
                Assert.IsNotNull(car.BlobItem.ImageGuid);
                Assert.IsNull(car.BlobItem.ImageName);
                Assert.IsNotNull(car.BlobItem.SasQueryString);
                Assert.IsNotNull(car.BlobItem.ImageUrl);
                Assert.AreEqual(car.Name, name);
                Assert.IsNotNull(car.UpdatedAt);
                Assert.IsNotNull(car.CreatedAt);

                //confirm the item from database is the same
                car = await table.LookupAsync(car.Id);

                Assert.IsNotNull(car.Id);
                Assert.IsNotNull(car.Name);
                Assert.IsNotNull(car.Url);
                Assert.IsNull(car.BlobItem);
                Assert.IsNotNull(car.UpdatedAt);
                Assert.IsNotNull(car.CreatedAt);
                Assert.AreEqual(car.Name, name);
                Assert.IsNotNull(car.UpdatedAt);
                Assert.IsNotNull(car.CreatedAt);
            }
            catch (MobileServiceInvalidOperationException mobileServiceInvalidOperationException)
            {
                exception = mobileServiceInvalidOperationException;
            }
            if (exception != null)
            {
                var content = await exception.Response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                Assert.Fail(content);
            }
            Assert.IsNull(exception);
        }
        /// <summary>
        /// update car as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task UpdateCarAsync()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CarsService.GetTable<Car>();
                var cars = await table.ToListAsync();
                Assert.IsNotNull(cars);
                Assert.AreNotEqual(cars.Count, 0);

                var car = cars.First();
                const string imageName = "test.png";
                car.BlobItem = new BlobItem {ImageName = imageName};
                await table.UpdateAsync(car);

                //confirm the information received
                Assert.IsNotNull(car.Id);
                Assert.IsNotNull(car.Name);
                Assert.IsNotNull(car.Url);
                Assert.IsNotNull(car.BlobItem);
                Assert.IsNotNull(car.BlobItem.ContainerName);
                Assert.IsNotNull(car.BlobItem.ImageGuid);
                Assert.IsNotNull(car.BlobItem.ImageName);
                Assert.AreEqual(car.BlobItem.ImageName, imageName);
                Assert.IsNotNull(car.BlobItem.SasQueryString);
                Assert.IsNotNull(car.BlobItem.ImageUrl);
                Assert.IsNotNull(car.UpdatedAt);
                Assert.IsNotNull(car.CreatedAt);

                //confirm the item from database is the same
                car = await table.LookupAsync(car.Id);

                Assert.IsNotNull(car.Id);
                Assert.IsNotNull(car.Name);
                Assert.IsNotNull(car.Url);
                Assert.IsNull(car.BlobItem);
                Assert.IsNotNull(car.UpdatedAt);
                Assert.IsNotNull(car.CreatedAt);
            }
            catch (MobileServiceInvalidOperationException mobileServiceInvalidOperationException)
            {
                exception = mobileServiceInvalidOperationException;
            }
            if (exception != null)
            {
                var content = await exception.Response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                Assert.Fail(content);
            }
            Assert.IsNull(exception);
        }

        /// <summary>
        /// try to insert car as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task TryToInsertCarAsync()
        {
            try
            {
                var table = AzureMobileService.CarsService.GetTable<Car>();
                var car = new Car();
                await table.InsertAsync(car);
            }
            catch (MobileServiceInvalidOperationException mobileServiceInvalidOperationException)
            {
                Assert.AreEqual(mobileServiceInvalidOperationException.Response.StatusCode, HttpStatusCode.BadRequest);
            }
        }
    }
}
