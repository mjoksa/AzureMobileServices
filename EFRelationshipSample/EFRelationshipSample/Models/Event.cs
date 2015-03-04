using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.Models
{
    public class Event : EntityData
    {
        public string Title { get; set; }

        public virtual ICollection<Speaker> Speakers { get; set; }
    }
}
