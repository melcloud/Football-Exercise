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
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// All lines in the file or empty collection.
        /// </returns>
        IEnumerable<string> GetAllLines(string filePath);
    }
}