namespace FootballExercise.DomainModels.Teams
{
    /// <summary>
    /// The calculate minimum difference of goal command.
    /// </summary>
    public class CalculateMinimumDifferenceOfGoal
    {
        /// <summary>
        /// The file path.
        /// </summary>
        private readonly string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateMinimumDifferenceOfGoal"/> class.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public CalculateMinimumDifferenceOfGoal(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
        }
    }
}