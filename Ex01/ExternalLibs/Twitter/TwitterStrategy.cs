using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex01.ExternalLibs.Twitter
{
    class TwitterStrategy : ISocialStrategy
    {
        public SocialNetworkUser[] GetSocialNetworkUser(string userName)
        {
            List<SocialNetworkUser> socialNetworkUsers = new List<SocialNetworkUser>();

            long userId = new TwitterClient().GetUserIdByName(userName);
            var tusers = new TwitterClient().GetSubscribers(userId);

            foreach (var user in tusers)
            {
                socialNetworkUsers.Add(new SocialNetworkUser { UserName = user.UserId.ToString() });
            }
            return socialNetworkUsers.ToArray();
        }
    }
}
