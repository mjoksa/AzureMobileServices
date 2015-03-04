using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.DataObjects
{
    public class EventDto : EntityData
    {
        public string Title { get; set; }

        public virtual ICollection<SpeakerDto> Speakers { get; set; }
    }
}
