namespace FootballExercise
{
    using System;

    using FootballExercise.Application;
    using FootballExercise.DomainModels.Teams;
    using FootballExercise.Infrastructure;
    using FootballExercise.Infrastructure.Extensions;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point.
        /// </summary>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            if (args.IsNullOrEmpty())
            {
                Console.WriteLine("Please provide file path as first argument.");
                return;
            }

            var filePath = args != null ? args[0] : string.Empty;

            var teamRepository = new SimpleCsvTeamRepository(str => new ReadCsvFile(str));

            var commandHandler = new CalculateMinimumDifferenceOfGoalCommandHandler(teamRepository);

            var team = commandHandler.Handle(new CalculateMinimumDifferenceOfGoal(filePath));

            Console.WriteLine("Team with minimum difference between for and against goal is {0}", team);
        }

        /// <summary>
        /// The current domain on unhandled exception.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="unhandledExceptionEventArgs">
        /// The unhandled exception event args.
        /// </param>
        private static void CurrentDomainOnUnhandledException(
            object sender,
            UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var exception = unhandledExceptionEventArgs.ExceptionObject as Exception;

            var message = "Unknown error occurred.";

            if (exception != null)
            {
                message = exception.Message;
            }

            Console.WriteLine("Error: {0}", message);
            Environment.Exit(1);
        }
    }
}