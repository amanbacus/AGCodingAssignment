using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTweets
{
    internal static class TweetHelper
    {
        internal static string[] SplitTweetLine(string tweetLine)
        {
            return tweetLine.Split(new string[] { "> " }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
