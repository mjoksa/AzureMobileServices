using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace EFRelationshipSample.Models
{
    public class User : EntityData
    {
        public string Name { get; set; }

        [IgnoreDataMember] 
        [JsonIgnore]
        public string MyPropertyForDbOnly { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public virtual ICollection<User> UnFriends { get; set; }
    }
}
