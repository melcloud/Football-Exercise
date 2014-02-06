namespace FootballExercise.UnitTests.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;

    using FootballExercise.Infrastructure.Extensions;

    using Xunit;

    /// <summary>
    /// The enumerable extension tests.
    /// </summary>
    public class EnumerableExtensionTests
    {
        /// <summary>
        /// Returns true for empty enumerable test.
        /// </summary>
        [Fact]
        public void ReturnsTrueForEmptyEnumerable()
        {
            var list = Enumerable.Empty<string>();

            Assert.True(list.IsNullOrEmpty());
        }

        /// <summary>
        /// Returns true for null enumerable test.
        /// </summary>
        [Fact]
        public void ReturnsTrueForNullEnumerable()
        {
            IEnumerable<string> test = null;

            Assert.True(test.IsNullOrEmpty());
        }

        /// <summary>
        /// Returns false for not null nor empty enumerable test.
        /// </summary>
        [Fact]
        public void ReturnsFalseForNotNullNorEmptyEnumerable()
        {
            IEnumerable<string> test = new[] { "test" };

            Assert.False(test.IsNullOrEmpty());
        }
    }
}