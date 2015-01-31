// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerControllerTest.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the CustomerControllerTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using CustomersSample;
using CustomersSampleService.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace CustomersSampleService.Tests
{
    /// <summary>
    /// Defines the test for Mobile Customer.
    /// </summary>
    [TestClass]
    public class CustomerControllerTest
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
                var table = AzureMobileService.CustomersService.GetTable<Customer>();
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
                var table = AzureMobileService.CustomersService.GetTable<Customer>();
                var items = await table.ToListAsync();
                Assert.IsNotNull(items);
                Customer item = null;
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
        /// Test delete customer
        /// </summary>
        [TestMethod]
        public async Task DeleteCustomerAsync()
        {
            // this depend on the application requirements
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CustomersService.GetTable<Customer>();
                const string name = "Test";
                var customer = new Customer
                {
                    Name = name
                };
                await table.InsertAsync(customer);

                //confirm the information received
                Assert.IsNotNull(customer.Id);
                Assert.IsNotNull(customer.Name);
                Assert.AreEqual(customer.Name, name);
                Assert.IsNotNull(customer.UpdatedAt);
                Assert.IsNotNull(customer.CreatedAt);

                await table.DeleteAsync(customer);

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
        /// Test insert customer
        /// </summary>
        [TestMethod]
        public async Task InsertCustomerAsync()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                var table = AzureMobileService.CustomersService.GetTable<Customer>();
                const string name = "Test";
                var customer = new Customer
                {
                    Name = name
                };
                await table.InsertAsync(customer);

                //confirm the information received
                Assert.IsNotNull(customer.Id);
                Assert.IsNotNull(customer.Name);
                Assert.AreEqual(customer.Name, name);
                Assert.IsNotNull(customer.UpdatedAt);
                Assert.IsNotNull(customer.CreatedAt);

                //confirm the item from database is the same
                var itemFormDatabase = await table.LookupAsync(customer.Id);

                Assert.IsNotNull(itemFormDatabase.Id);
                Assert.IsNotNull(itemFormDatabase.Name);
                Assert.AreEqual(itemFormDatabase.Name, name);
                Assert.IsNotNull(itemFormDatabase.UpdatedAt);
                Assert.IsNotNull(itemFormDatabase.CreatedAt);
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

        [TestMethod]
        public async Task TryToInsertCustomerAsync()
        {
            try
            {
                var table = AzureMobileService.CustomersService.GetTable<Customer>();
                const string name = "Test";
                // name is required and it must fails
                // the validation is in the controller
                var customer = new Customer();
                await table.InsertAsync(customer);
            }
            catch (MobileServiceInvalidOperationException mobileServiceInvalidOperationException)
            {
                Assert.AreEqual(mobileServiceInvalidOperationException.Response.StatusCode, HttpStatusCode.BadRequest);
            }
        }
    }
}
