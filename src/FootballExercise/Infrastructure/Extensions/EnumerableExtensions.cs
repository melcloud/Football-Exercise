namespace FootballExercise.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">
        /// The IEnumerable type.
        /// </typeparam>
        /// <param name="enumerable">
        /// The enumerable, which may be null or empty.
        /// </param>
        /// <returns>
        /// <c>true</c> if the IEnumerable is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}