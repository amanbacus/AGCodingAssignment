using System;

namespace Helpers
{
    public static class ConsoleHelper
    {
        public static void WriteToConsole(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
        }

        private const string _readPrompt = "console> ";
        public static string ReadFromConsole(string promptMessage = "")
        {
            Console.Write(_readPrompt + promptMessage);
            return Console.ReadLine();
        }
    }
}
