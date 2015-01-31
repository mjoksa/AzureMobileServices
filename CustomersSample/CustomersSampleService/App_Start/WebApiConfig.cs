// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The web api config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Net.Http.Formatting;
using System.Web.Http;
using AutoMapper;
using CustomersSampleService.DataObjects;
using CustomersSampleService.Migrations;
using CustomersSampleService.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Config;

namespace CustomersSampleService
{
    /// <summary>
    /// The web api config.
    /// </summary>
    public class WebApiConfig : IBootstrapper
    {
        /// <summary>
        /// Defines the entry point for the application. It is the responsibility of this entry point
        /// to call <see cref="T:Microsoft.WindowsAzure.Mobile.Service.ServiceConfig" /> which will start the configuration of the application.
        /// </summary>
        public void Initialize()
        {
            // Use this class to set configuration options for your mobile service
            var options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            var config = ServiceConfig.Initialize(new ConfigBuilder(options));
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            AutoMapperDefinition();
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }

        /// <summary>
        /// Automatics the mapper definition.
        /// </summary>
        private static void AutoMapperDefinition()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderDto, Order>();
                cfg.CreateMap<Order, OrderDto>()
                    .ForMember(dto => dto.CustomerName, map => map.MapFrom(tbl => tbl.Customer.Name));

                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<Customer, CustomerDto>();

                cfg.CreateMap<ICollection<Order>, List<OrderDto>>();
                cfg.CreateMap<List<OrderDto>, ICollection<Order>>();
                cfg.CreateMap<ICollection<Customer>, List<CustomerDto>>();
                cfg.CreateMap<List<CustomerDto>, ICollection<Customer>>();
            });
        }
    }
}