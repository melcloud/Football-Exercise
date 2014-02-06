namespace FootballExercise.Application
{
    using FootballExercise.DomainModels.Teams;

    /// <summary>
    /// The HandleCommand interface.
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    public interface IHandleCommand<in TCommand> where TCommand : class
    {
        /// <summary>
        /// Handle command.
        /// </summary>
        /// <remarks>
        /// Command handler Should never return result directly.
        /// Event like GoalDifferenceCalculated should be used for
        /// communication. This is allowed here to simplify dev job.
        /// </remarks>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The team.
        /// </returns>
        Team Handle(TCommand command);
    }
}