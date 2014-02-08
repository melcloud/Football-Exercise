namespace FootballExercise.IntegrationTests
{
    using FootballExercise.Application;
    using FootballExercise.DomainModels.Teams;
    using FootballExercise.Infrastructure;

    using Xunit;

    /// <summary>
    /// The football exercise tests.
    /// </summary>
    public class FootballExerciseTests
    {
        /// <summary>
        /// The team aston villa should have the minimum difference of goal.
        /// </summary>
        [Fact]
        public void TeamAstonVillaShouldHaveTheMinimumDifferenceOfGoal()
        {
            var teamRepository = new SimpleCsvTeamRepository(str => new ReadCsvFile(str));

            var commandHandler = new CalculateMinimumDifferenceOfGoalCommandHandler(teamRepository);

            Team team = null;

            Assert.DoesNotThrow(
                () => team = commandHandler.Handle(new CalculateMinimumDifferenceOfGoal("football.csv")));

            Assert.NotNull(team);
            Assert.Equal("Aston_Villa", team.Name);
            Assert.Equal(1, team.CalculateGoalDifference());
        }
    }
}