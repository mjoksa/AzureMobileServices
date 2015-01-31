// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderControllerTest.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Define the test for Mobile Order.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CustomersSample;
using CustomersSampleService.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.MobileServices;

namespace CustomersSampleService.Tests
{
    /// <summary>
    /// Define the test for Mobile Order.
    /// </summary>
    [TestClass]
    public class OrderControllerTest
    {
        private const string ItemValue = "TV";
        private const string ItemValueUpdate = "TV - Update";
        private const int Quantity = 10;

        /// <summary>
        /// Gets all.
        /// </summary>
        [TestMethod]
        public async Task GetAllAsync()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CustomersService.GetTable<Order>();
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
        /// Gets the by id.
        /// </summary>
        [TestMethod]
        public async Task GetById()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CustomersService.GetTable<Customer>();
                var items = await table.ToListAsync();
                Customer item = null;
                if (items.Any())
                {
                    item = await table.LookupAsync(items.First().Id);

                    Assert.IsNotNull(items);
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
        /// Insert, lookup, update, delete and lookup an order.
        /// </summary>
        [TestMethod]
        public async Task Insert_Lookup_Update_Delete_Lookup_Order()
        {
            MobileServiceInvalidOperationException exception = null;
            string content;
            try
            {
                var table = AzureMobileService.CustomersService.GetTable<Order>();
                var customersTable = AzureMobileService.CustomersService.GetTable<Customer>();
                var customers = await customersTable.ToListAsync();
                var customer = customers.First();

                var item = new Order
                {
                    Quantity = Quantity,
                    Item = ItemValue,
                    CustomerId = customer.Id,
                    CustomerName = customer.Name,
                };
                await table.InsertAsync(item);
                Assert.IsNotNull(item);
                Assert.AreEqual(item.Item, ItemValue);
                Assert.AreEqual(item.Quantity, Quantity);
                var lookupItem = await table.LookupAsync(item.Id);
                Assert.IsNotNull(lookupItem);

                item.Item = ItemValueUpdate;
                await table.UpdateAsync(item);
                Assert.IsNotNull(item);
                Assert.AreEqual(item.Item, ItemValueUpdate);
                Assert.AreEqual(item.Quantity, Quantity);
                var id = item.Id;
                await table.DeleteAsync(item);
                try
                {
                    item = await table.LookupAsync(id);
                }
                catch (MobileServiceInvalidOperationException ex)
                {
                    Assert.IsTrue(ex.Response.StatusCode == HttpStatusCode.NotFound);
                }
            }
            catch (MobileServiceInvalidOperationException mobileServiceInvalidOperationException)
            {
                exception = mobileServiceInvalidOperationException;
            }
            if (exception != null)
            {
                content = await exception.Response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                Assert.Fail(content);
            }
        }
    }
}
