using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.DataObjects
{
    public class UserDto : EntityData
    {
        public string Name { get; set; }

        public virtual ICollection<UserDto> Friends { get; set; }

        public virtual ICollection<UserDto> UnFriends { get; set; }
    }
}
