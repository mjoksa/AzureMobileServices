using EFRelationshipSample.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.DataObjects
{
    public class CityDto : EntityData
    {
        public string Name { get; set; }

        public string CountryId { get; set; }

        public CountryDto Country { get; set; }
    }
}
