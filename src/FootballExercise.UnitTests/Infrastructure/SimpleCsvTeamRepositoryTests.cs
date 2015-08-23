namespace FootballExercise.UnitTests.Infrastructure
{
    using System.Linq;

    using FootballExercise.Infrastructure;

    using NSubstitute;

    using Xunit;

    /// <summary>
    /// The parse team data tests.
    /// </summary>
    public class SimpleCsvTeamRepositoryTests
    {
        /// <summary>
        /// The can parse team data when format is correct test.
        /// </summary>
        [Fact]
        public void CanGetTeamWhenFormatIsCorrect()
        {
            var fileReader = Substitute.For<IReadFile>();

            fileReader.GetAllLines().Returns(new[] { "Team, P, W, L, D, 1, -, 2, Pts" });

            var teamRepository = new SimpleCsvTeamRepository(str => fileReader);

            var teams = teamRepository.GetAll("test");

            Assert.NotNull(teams);
            Assert.Equal(1, teams.Count);
            Assert.Equal("Team", teams.Single().Name);
            Assert.Equal(1, teams.Single().CalculateGoalDifference());
        }

        /// <summary>
        /// The numeric index in team name will be removed.
        /// </summary>
        [Fact]
        public void NumericIndexInTeamNameWillBeRemoved()
        {
            var fileReader = Substitute.For<IReadFile>();

            fileReader.GetAllLines().Returns(new[] { "1. Team, P, W, L, D, 1, -, 2, Pts", "Team, P, W, L, D, 1, -, A, Pts" });

            var teamRepository = new SimpleCsvTeamRepository(str => fileReader);

            var teams = teamRepository.GetAll("test");

            Assert.NotNull(teams);
            Assert.Equal(1, teams.Count);
            Assert.Equal("Team", teams.Single().Name);
        }

        /// <summary>
        /// The skip line with incorrect column number test.
        /// </summary>
        [Fact]
        public void SkipLineWithIncorrectColumnNumber()
        {
            var fileReader = Substitute.For<IReadFile>();

            fileReader.GetAllLines().Returns(new[] { "Team, P, W, L, D, 1, -, 2, Pts", "Team2, L, D, 2, -, 2, Pts" });

            var teamRepository = new SimpleCsvTeamRepository(str => fileReader);

            var teams = teamRepository.GetAll("test");

            Assert.NotNull(teams);
            Assert.Equal(1, teams.Count);
            Assert.Equal("Team", teams.Single().Name);
            Assert.Equal(1, teams.Single().CalculateGoalDifference());
        }

        /// <summary>
        /// The skip line with incorrect for goal test.
        /// </summary>
        [Fact]
        public void SkipLineWithIncorrecForGoal()
        {
            var fileReader = Substitute.For<IReadFile>();

            fileReader.GetAllLines()
                .ReturnsForAnyArgs(new[] { "Team, P, W, L, D, 1, -, 2, Pts", "Team, P, W, L, D, F, -, 2, Pts" });

            var teamRepository = new SimpleCsvTeamRepository(str => fileReader);

            var teams = teamRepository.GetAll("test");

            Assert.NotNull(teams);
            Assert.Equal(1, teams.Count);
            Assert.Equal("Team", teams.Single().Name);
            Assert.Equal(1, teams.Single().CalculateGoalDifference());
        }

        /// <summary>
        /// The skip line with incorrect against goal test.
        /// </summary>
        [Fact]
        public void SkipLineWithIncorrecAgainstGoal()
        {
            var fileReader = Substitute.For<IReadFile>();

            fileReader.GetAllLines()
                .ReturnsForAnyArgs(new[] { "Team, P, W, L, D, 1, -, 2, Pts", "Team, P, W, L, D, 1, -, A, Pts" });

            var teamRepository = new SimpleCsvTeamRepository(str => fileReader);

            var teams = teamRepository.GetAll("test");

            Assert.NotNull(teams);
            Assert.Equal(1, teams.Count);
            Assert.Equal("Team", teams.Single().Name);
            Assert.Equal(1, teams.Single().CalculateGoalDifference());
        }
    }
}