using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.DataObjects
{
    public class CountryDto : EntityData
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }

        public virtual ICollection<CityDto> Cities { get; set; }
    }
}
