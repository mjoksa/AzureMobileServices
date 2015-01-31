using System;
using Microsoft.WindowsAzure.MobileServices;

namespace Microsoft.WindowsAzure.Mobile.Service
{
    public class EntityData
    {   
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [Version]
        public byte[] Version { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [CreatedAt]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
