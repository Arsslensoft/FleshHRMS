using System.Linq;

namespace PHRMS.Utils
{
    /// <summary>
    ///     Provides the extension method for implementations of the IQueryable interface.
    /// </summary>
    public static class DbExtensions
    {
        /// <summary>
        ///     Forces entities to be loaded locally from the IQueryable instance.
        /// </summary>
        /// <param name="source">An instance of the IQueryable interface from which to load entities.</param>
        public static void Load(this IQueryable source)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
            }
        }
    }
}