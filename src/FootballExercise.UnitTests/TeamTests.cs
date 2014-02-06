namespace FootballExercise.UnitTests
{
    using FootballExercise.DomainModels.Teams;

    using Xunit;

    /// <summary>
    /// The team tests.
    /// </summary>
    public class TeamTests
    {
        /// <summary>
        /// The can calculate goal different test
        /// </summary>
        [Fact]
        public void CanCalculateGoalDifference()
        {
            var team = new Team("team", 1, 2);

            Assert.Equal(1, team.CalculateGoalDifference());
        }
    }
}