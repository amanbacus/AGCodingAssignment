using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTweets
{
    internal static class UserHelper
    {
        internal static List<string> GetAllUsersInLine(string userLine)
        {
            return userLine.Split(new string[] { " follows ", ", " },
                                    StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        internal static List<string> GetFollowedUsers(string userLine, string userKey)
        {
            return userLine.Split(new string[] { String.Format("{0} follows ", userKey), "," },
                StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
