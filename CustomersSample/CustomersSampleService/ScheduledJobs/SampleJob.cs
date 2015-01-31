// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleJob.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The sample job.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;

namespace CustomersSampleService.ScheduledJobs
{
    // A simple scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/sample".

    /// <summary>
    /// The sample job.
    /// </summary>
    public class SampleJob : ScheduledJob
    {
        /// <summary>
        /// The execute async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override Task ExecuteAsync()
        {
            Services.Log.Info("Hello from scheduled job!");
            return Task.FromResult(true);
        }
    }
}