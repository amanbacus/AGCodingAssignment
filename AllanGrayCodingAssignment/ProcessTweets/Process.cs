using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Helpers;

namespace ProcessTweets
{
    public class Process : IProcess
    {
        #region Properties
        
        public string TweetFile { get; set; }
        public string UserFile { get; set; }

        private static List<User> UniqueUsers { get; set; }

        #endregion

        #region Constructors

        public Process()
        {
            UniqueUsers = new List<User>();
        }

        #endregion

        #region Public Methods

        public void ProcessFiles()
        {
            ProcessUserFile();

            if (UniqueUsers.IsNullOrEmpty())
            {
                ConsoleHelper.WriteToConsole("There are no users to process.");
            }
            else
            {
                ProcessTweetFile(UniqueUsers);
            }
        }

        #endregion

        #region IProcessTweet Members

        public void ProcessUserFile()
        { 
            using (StreamReader reader = new StreamReader(UserFile, Encoding.ASCII))
            {
                string userLine = null;

                while ((userLine = reader.ReadLine()) != null)
                {
                    List<string> allUsers = UserHelper.GetAllUsersInLine(userLine);

                    AddUniqueUsers(allUsers);

                    ProcessUniqueUsers(userLine, allUsers[0]);
                }
            }
        }

        public void ProcessTweetFile(List<User> users)
        {
            foreach (var user in users.OrderBy(a => a.UserName))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(user.UserName);

                using (StreamReader reader = new StreamReader(TweetFile, Encoding.ASCII))
                {
                    string tweetLine = string.Empty;

                    while ((tweetLine = reader.ReadLine()) != null)
                    {
                        var tweet = TweetHelper.SplitTweetLine(tweetLine);
                        var tweetHandle = tweet[0];
                        
                        if (tweetHandle == user.UserName || user.FollowedUsers.Contains(tweetHandle))
                        {
                            var tweetText = new string(tweet[1].Take(140).ToArray());
                            sb.AppendFormat("\t@{0}: {1}\n", tweetHandle, tweetText);
                        }
                    }
                }

                ConsoleHelper.WriteToConsole(sb.ToString());
            }
        }

        #endregion

        #region Private Methods

        private static void AddUniqueUsers(List<string> allUsers)
        {
            allUsers.ForEach(user =>
            {
                if (!UniqueUsers.Any(u => u.UserName == user))
                {
                    UniqueUsers.Add(new User { UserName = user });
                }
            });
        }

        private static void ProcessUniqueUsers(string userLine, string userKey)
        {
            foreach (var user in UniqueUsers)
            {
                if (user.UserName == userKey)
                {
                    List<string> followedUsers = UserHelper.GetFollowedUsers(userLine, userKey);

                    foreach (var followedUser in followedUsers)
                    {
                        user.AddFollowedUser(followedUser);
                    }
                }
            }
        }
        
        #endregion
    }
}
