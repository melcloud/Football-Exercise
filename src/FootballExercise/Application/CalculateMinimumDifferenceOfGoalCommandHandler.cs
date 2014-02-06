namespace FootballExercise.Application
{
    using FootballExercise.DomainModels.Teams;
    using FootballExercise.Infrastructure;

    /// <summary>
    /// The calculate minimum difference of goal command handler.
    /// </summary>
    public class CalculateMinimumDifferenceOfGoalCommandHandler : IHandleCommand<CalculateMinimumDifferenceOfGoal>
    {
        /// <summary>
        /// The team repository.
        /// </summary>
        private readonly ITeamRepository teamRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateMinimumDifferenceOfGoalCommandHandler"/> class.
        /// </summary>
        /// <param name="teamRepository">
        /// The team repository.
        /// </param>
        public CalculateMinimumDifferenceOfGoalCommandHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        /// <summary>
        /// Coordinate command to domain service.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// Return the team.
        /// </returns>
        public Team Handle(CalculateMinimumDifferenceOfGoal command)
        {
            return MinimumGoalDifferenceCalculator.Calculate(this.teamRepository.GetAll(command.FilePath));
        }
    }
}