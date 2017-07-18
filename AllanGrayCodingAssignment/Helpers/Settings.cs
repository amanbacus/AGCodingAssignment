using System;
using System.Configuration;

namespace Helpers
{
    public static class Settings
    {
        public static string SourceFileLocation
        {
            get
            {
                return ConfigurationManager.AppSettings["SourceFileLocation"].ToString();
            }
        }

        public static int ConsoleWidth
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["ConsoleWidth"].ToString());
            }
        }

        public static int ConsoleHeight
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["ConsoleHeight"].ToString());
            }
        }
        
        public static string UserFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["UserFileName"].ToString().ToLower();
            }
        }

        public static string TweetFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["TweetFileName"].ToString().ToLower();
            }
        }
    }
}
