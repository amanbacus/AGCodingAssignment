using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTweets
{
    public class User
    {
        #region Properties

        public string UserName { get; set; }

        public List<string> FollowedUsers { get; set; }

        #endregion

        #region Constructors

        public User()
        {
            FollowedUsers = new List<string>();
        }

        #endregion

        #region Methods

        public void AddFollowedUser(string followedUser)
        {
            if (!FollowedUsers.Contains(followedUser.Trim()))
            {
                FollowedUsers.Add(followedUser.Trim());
            }            
        }

        #endregion

    }

}
