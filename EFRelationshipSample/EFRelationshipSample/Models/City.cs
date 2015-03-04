using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.Models
{
    
    public class City : EntityData
    {
        public string Name { get; set; }

        public string CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
