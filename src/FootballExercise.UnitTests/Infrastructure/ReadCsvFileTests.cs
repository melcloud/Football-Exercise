﻿namespace FootballExercise.UnitTests.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using FootballExercise.Infrastructure;

    using Xunit;
    using Xunit.Extensions;

    /// <summary>
    /// The read CSV file tests.
    /// </summary>
    public class ReadCsvFileTests
    {
        /// <summary>
        /// The file path must be provided test.
        /// </summary>
        /// <param name="filePath">
        /// The invalid file Path.
        /// </param>
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void FilePathMustBeProvided(string filePath)
        {
            Assert.Throws<ArgumentException>(() => new ReadCsvFile(filePath));
        }

        /// <summary>
        /// The file must exist for reading.
        /// </summary>
        [Fact]
        public void FileMustExistForReading()
        {
            const string FileName = "nonExistingFile.csv";

            var readInvalidCsvFile = new ReadCsvFile(FileName);
            var exception = Record.Exception(() => readInvalidCsvFile.GetAllLines());

            Assert.IsType<FileNotFoundException>(exception);
            Assert.Equal(FileName, ((FileNotFoundException)exception).FileName);
        }

        /// <summary>
        /// The can read csv file test.
        /// </summary>
        [Fact]
        public void CanReadCsvFile()
        {
            var readCsvFile = new ReadCsvFile("test.csv");

            IEnumerable<string> lines = null;

            Assert.DoesNotThrow(() => lines = readCsvFile.GetAllLines());

            Assert.NotEmpty(lines);
        }

        /// <summary>
        /// The always skip first header row test.
        /// </summary>
        [Fact]
        public void AlwaysSkipFirstHeaderRow()
        {
            var readCsvFile = new ReadCsvFile("test.csv");

            IEnumerable<string> lines = null;

            Assert.DoesNotThrow(() => lines = readCsvFile.GetAllLines());

            Assert.Equal(1, lines.Count());
        }
    }
}