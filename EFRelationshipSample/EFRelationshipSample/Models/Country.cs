using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace EFRelationshipSample.Models
{
    [JsonObject(IsReference = true)] 
    public class Country: EntityData
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
