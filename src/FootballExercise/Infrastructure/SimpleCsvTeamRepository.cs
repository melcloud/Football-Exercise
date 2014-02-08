namespace FootballExercise.Infrastructure
{
    using System;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;

    using FootballExercise.DomainModels.Teams;

    /// <summary>
    /// The simple CSV team repository.
    /// </summary>
    public class SimpleCsvTeamRepository : ITeamRepository
    {
        /// <summary>
        /// The delimiter.
        /// </summary>
        private const char Delimiter = ',';

        /// <summary>
        /// The read file.
        /// </summary>
        private readonly Func<string, IReadFile> readFileFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCsvTeamRepository"/> class.
        /// </summary>
        /// <param name="readFileFactory">
        /// The read file factory.
        /// </param>
        public SimpleCsvTeamRepository(Func<string, IReadFile> readFileFactory)
        {
            // TODO: Change to use Guard library
            if (readFileFactory == null)
            {
                throw new ArgumentNullException("readFileFactory");
            }

            this.readFileFactory = readFileFactory;
        }

        /// <summary>
        /// Get all teams.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <remarks>
        /// Assumption: Team CSV file format doesn't change, always have 9 columns
        /// Assumption: Any of the column doesn't contain comma
        /// Assumption: Team CSV file is small enough to be loaded to memory
        /// Assumption: Team CSV file first row contains header.
        /// </remarks>
        /// <returns>
        /// An immutable list of team.
        /// </returns>
        public IImmutableList<Team> GetAll(string filePath)
        {
            var readFile = this.readFileFactory(filePath);

            var teamDataLines = readFile.GetAllLines().Select(
                (v, index) =>
                    {
                        var teamData = v.Split(Delimiter);
                        var lineNumber = index + 1;
                        if (teamData.Length < 9)
                        {
                            Trace.TraceWarning("Incorrect team data format on line {0}", lineNumber);
                            return null;
                        }

                        int forGoal, againstGoal;

                        if (!int.TryParse(teamData[5], out forGoal))
                        {
                            Trace.TraceWarning("For goal on line {0} is not an integer", lineNumber);
                            return null;
                        }

                        if (!int.TryParse(teamData[7], out againstGoal))
                        {
                            Trace.TraceWarning("Against goal on line {0} is not an integer", lineNumber);
                            return null;
                        }

                        return new Team(GetTeamName(teamData[0]), forGoal, againstGoal);
                    }).Where(team => team != null);

            return ImmutableList<Team>.Empty.AddRange(teamDataLines);
        }

        /// <summary>
        /// Get team name without index number.
        /// </summary>
        /// <param name="columnValue">
        /// The column value.
        /// </param>
        /// <returns>
        /// The team name without index number.
        /// </returns>
        protected virtual string GetTeamName(string columnValue)
        {
            if (!string.IsNullOrWhiteSpace(columnValue))
            {
                return Regex.Replace(columnValue, "^\\d+. ", string.Empty, RegexOptions.Singleline);
            }

            return columnValue;
        }
    }
}