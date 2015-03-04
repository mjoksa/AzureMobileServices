using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.DataObjects
{
    public class SpeakerDto: EntityData
    {
        public string Name { get; set; }

        public virtual ICollection<EventDto> Events { get; set; }
    }
}
