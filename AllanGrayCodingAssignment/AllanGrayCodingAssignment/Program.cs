using System;
using System.IO;
using Helpers;

namespace AllanGrayCodingAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            SetupConsole();

            try
            {
                ValidateInput.ValidateCommandLineArguments(args);

                new ProcessTweets.Process()
                {
                    UserFile = Path.Combine(Settings.SourceFileLocation, args[0]),
                    TweetFile = Path.Combine(Settings.SourceFileLocation, args[1])
                }.ProcessFiles();
            }
            catch (ArgumentException ex)
            {
                ConsoleHelper.WriteToConsole(ex.Message);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteToConsole(ex.Message);
            }
            finally
            {
                ConsoleHelper.WriteToConsole("Press enter to continue...");
                var consoleInput = ConsoleHelper.ReadFromConsole();
            }
        }

        private static void SetupConsole()
        {
            Console.Title = "Allan Gray Coding Assignment";
            Console.WindowWidth = Settings.ConsoleWidth;
            Console.WindowHeight = Settings.ConsoleHeight;
        }
    }
}
