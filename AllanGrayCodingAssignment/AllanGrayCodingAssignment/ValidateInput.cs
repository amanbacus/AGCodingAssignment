using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace AllanGrayCodingAssignment
{
    internal static class ValidateInput
    {
        internal static void ValidateCommandLineArguments(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("Invalid number of arguments.");
            }

            if (args[0].ToLower() != Settings.UserFileName)
            {
                throw new ArgumentException("An invalid user filename has been provided.");
            }

            if (args[1].ToLower() != Settings.TweetFileName)
            {
                throw new ArgumentException("An invalid tweet filename has been provided.");
            }

            if (!Directory.Exists(Settings.SourceFileLocation))
            {
                throw new ArgumentException(String.Format("Directory ({0}) does not exist", Settings.SourceFileLocation));
            }

            var files = Directory.GetFiles(Settings.SourceFileLocation).ToList();
            StringBuilder missingFiles = new StringBuilder();
            args.ToList().ForEach(a => {
                if (!files.Any(f => Path.GetFileName(f) == a))
                {
                    missingFiles.AppendLine(String.Format("{0} does not exist in directory {1}", a, Settings.SourceFileLocation));
                }
            });

            if (missingFiles.Length > 0)
            {
                throw new ArgumentException(missingFiles.ToString());
            }
        }
    }
}
