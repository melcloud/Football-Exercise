namespace FootballExercise.DomainModels.Teams
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    using FootballExercise.Infrastructure.Extensions;

    /// <summary>
    /// The minimum goal difference calculator.
    /// </summary>
    /// <remarks>
    /// Calculates the differences between for and against goals by
    /// getting the absolute value of for goal - against goal.
    /// </remarks>
    public class MinimumGoalDifferenceCalculator
    {
        /// <summary>
        /// Calculate goal difference based on team.
        /// </summary>
        /// <param name="teams">
        /// A collection of team.
        /// </param>
        /// <returns>
        /// The goal difference.
        /// </returns>
        public static Team Calculate(IImmutableList<Team> teams)
        {
            if (teams.IsNullOrEmpty())
            {
                throw new InvalidOperationException("No teams found.");
            }

            if (teams.Count == 1)
            {
                return teams.Single();
            }

            return teams.OrderBy(team => team.CalculateGoalDifference()).First();
        }
    }
}