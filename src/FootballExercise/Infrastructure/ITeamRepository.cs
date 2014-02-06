namespace FootballExercise.Infrastructure
{
    using System.Collections.Immutable;

    using FootballExercise.DomainModels.Teams;

    /// <summary>
    /// The ParseTeamData interface.
    /// </summary>
    public interface ITeamRepository
    {
        /// <summary>
        /// Get all teams.
        /// </summary>
        /// <returns>
        /// An immutable list of team.
        /// </returns>
        IImmutableList<Team> GetAll(string filePath);
    }
}