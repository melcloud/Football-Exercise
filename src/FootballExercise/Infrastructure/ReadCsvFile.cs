namespace FootballExercise.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The read CSV files.
    /// </summary>
    public class ReadCsvFile : IReadFile
    {
        /// <summary>
        /// Get all lines in a file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// The lines in a file.
        /// </returns>
        public IEnumerable<string> GetAllLines(string filePath)
        {
            // TODO: use guard library
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path must be provided.", filePath);
            }

            if (!this.FileExist(filePath))
            {
                throw new InvalidOperationException("No file found.");
            }

            var lines = File.ReadAllLines(filePath);

            return lines.Skip(1);
        }

        /// <summary>
        /// The file exist.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected virtual bool FileExist(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}