using System.ComponentModel.DataAnnotations;
#if !Tests
using Microsoft.WindowsAzure.Mobile.Service;
#else
using AMSToolkit.Model;
#endif
using System.ComponentModel.DataAnnotations.Schema;
using AMSToolkit.Blob;

namespace ManageImagesSample.DataObjects
{
    /// <summary>
    /// Define the Car.
    /// </summary>
    public class Car : EntityData
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the BlobItem.
        /// </summary>
         /// <value>The URL.</value>
#if !Tests
         [NotMapped]
#endif
        public BlobItem BlobItem { get; set; }
    }
}