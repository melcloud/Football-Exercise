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
        /// The file path.
        /// </summary>
        private readonly string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadCsvFile"/> class.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public ReadCsvFile(string filePath)
        {
            // TODO: use guard library
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path must be provided.", filePath);
            }

            this.filePath = filePath;
        }

        /// <summary>
        /// Get all lines in a file.
        /// </summary>
        /// <returns>
        /// The lines in a file.
        /// </returns>
        public IEnumerable<string> GetAllLines()
        {
            if (!this.FileExist())
            {
                throw new FileNotFoundException("No file found.", this.filePath);
            }

            var lines = File.ReadAllLines(this.filePath);

            return lines.Skip(1);
        }

        /// <summary>
        /// The file exist.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected virtual bool FileExist()
        {
            return File.Exists(this.filePath);
        }
    }
}