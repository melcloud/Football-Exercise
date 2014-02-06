namespace FootballExercise.DomainModels.Teams
{
    using System;

    /// <summary>
    /// The team.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The for goal.
        /// </summary>
        private readonly int forGoal;

        /// <summary>
        /// The against goal.
        /// </summary>
        private readonly int againstGoal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="forGoal">
        /// The for goal.
        /// </param>
        /// <param name="againstGoal">
        /// The against goal.
        /// </param>
        public Team(string name, int forGoal, int againstGoal)
        {
            // TODO: Change to use Guard library
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "Team name must be provided");
            }

            if (forGoal < 0)
            {
                throw new ArgumentOutOfRangeException("forGoal", "for goal must be greater than or equal to 0");
            }

            if (againstGoal < 0)
            {
                throw new ArgumentOutOfRangeException("againstGoal", "against goal must be greater than or equal to 0");
            }

            this.name = name;
            this.forGoal = forGoal;
            this.againstGoal = againstGoal;
        }

        /// <summary>
        /// Gets the team name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Calculate difference between for goal and against goal.
        /// </summary>
        /// <remarks>
        /// The goal difference is calculated by difference = absolute value of (for goal - against goal).
        /// </remarks>
        /// <returns>
        /// Return the goal difference.
        /// </returns>
        public int CalculateGoalDifference()
        {
            return Math.Abs(this.forGoal - this.againstGoal);
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "Team " + this.Name;
        }
    }
}