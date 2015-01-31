using System.Data.Entity;

namespace CustomersSampleService.Extensions
{
    /// <summary>
    /// Define the DbContextExtensions.
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// Exists the specified identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if item with the id provided exists, <c>false</c> otherwise.</returns>
        public static bool Exist<T>(this DbContext context, string id) where T : class
        {
            return context.Set<T>().Find(id) != null;
        }
    }
}