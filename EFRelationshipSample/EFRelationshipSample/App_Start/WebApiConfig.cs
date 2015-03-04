using System.Data.Entity.Migrations;
using System.Net.Http.Formatting;
using System.Web.Http;
using AutoMapper;
using EFRelationshipSample.DataObjects;
using EFRelationshipSample.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Config;
using EFRelationshipSample.Migrations;

namespace EFRelationshipSample
{
    public  class WebApiConfig : IBootstrapper
    {
        public void Initialize()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            //Read more about it
            // http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization#handling_circular_object_references
            // to prevent cycle references
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
          
            // this is the default and by default is used Json.net
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            
            AutoMapperConfig();

            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }

        private static void AutoMapperConfig()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>().ReverseMap();

                cfg.CreateMap<Country, CountryDto>();
                cfg.CreateMap<Country, CountryDto>().ReverseMap();

                cfg.CreateMap<City, CityDto>();
                cfg.CreateMap<CityDto, City>().ReverseMap();

                cfg.CreateMap<Event, EventDto>();
                cfg.CreateMap<EventDto, Event>().ReverseMap();

                cfg.CreateMap<Speaker, SpeakerDto>();
                cfg.CreateMap<SpeakerDto, Speaker>().ReverseMap();
          });

            // we should use this method to valid the maps created
            Mapper.AssertConfigurationIsValid();
        }
    }
}

