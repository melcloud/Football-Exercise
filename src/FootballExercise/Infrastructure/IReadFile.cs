namespace FootballExercise.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// The ReadTextFiles interface.
    /// </summary>
    public interface IReadFile
    {
        /// <summary>
        /// Get all lines of the file. 
        /// </summary>
        /// <returns>
        /// All lines in the file or empty collection.
        /// </returns>
        IEnumerable<string> GetAllLines();
    }
}