using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EFRelationshipSample.Models
{
    public class User : EntityData
    {
        public string Name { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public virtual ICollection<User> UnFriends { get; set; }
    }
}
