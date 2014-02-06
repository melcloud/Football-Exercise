namespace FootballExercise.UnitTests
{
    using System;
    using System.Collections.Immutable;

    using FootballExercise.DomainModels.Teams;

    using Xunit;

    /// <summary>
    /// The minimum goal difference calculator tests.
    /// </summary>
    public class MinimumGoalDifferenceCalculatorTests
    {
        /// <summary>
        /// The can calculate minimum goal test.
        /// </summary>
        [Fact]
        public void CanCalculateMinimumGoals()
        {
            var teams =
                ImmutableList<Team>.Empty.AddRange(
                    new[]
                        {
                            new Team("team1", 4, 6), 
                            new Team("team2", 2, 3), 
                            new Team("team3", 3, 7),
                            new Team("team3", 3, 6)
                        });

            var teamWithMinimumGoal = MinimumGoalDifferenceCalculator.Calculate(teams);

            Assert.Equal("team2", teamWithMinimumGoal.Name);
        }

        /// <summary>
        /// The teams must be provided test.
        /// </summary>
        [Fact]
        public void TeamsMustBeProvided()
        {
            Assert.Throws<InvalidOperationException>(() => MinimumGoalDifferenceCalculator.Calculate(null));
        }
    }
}