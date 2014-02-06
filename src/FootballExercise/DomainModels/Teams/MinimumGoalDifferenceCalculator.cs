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

            Team winnerTeam = null;
            int? currentDifference = null;

            foreach (var team in teams)
            {
                var difference = team.CalculateGoalDifference();

                if (difference == 0)
                {
                    return team;
                }

                if (currentDifference.HasValue)
                {
                    if (difference < currentDifference.Value)
                    {
                        winnerTeam = team;
                        currentDifference = difference;
                    }
                }
                else
                {
                    winnerTeam = team;
                    currentDifference = difference;
                }
            }

            return winnerTeam;
        }
    }
}