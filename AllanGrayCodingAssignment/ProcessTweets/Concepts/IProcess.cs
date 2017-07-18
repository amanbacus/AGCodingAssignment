using System.Collections.Generic;

namespace ProcessTweets
{
    interface IProcess
    {
        void ProcessUserFile();
        void ProcessTweetFile(List<User> users);
    }
}
