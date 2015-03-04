using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.Models
{
    public class Speaker: EntityData
    {
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
