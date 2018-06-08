using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex01.ExternalLibs.Instagram
{
    class InstagramStrategy : ISocialStrategy
    {
        public SocialNetworkUser[] GetSocialNetworkUser(string userName)
        {
            List<SocialNetworkUser> socialNetworkUsers = new List<SocialNetworkUser>();

            var users = new InstagramClient().GetSubscribers(userName);
            foreach (var user in users)
            {
                socialNetworkUsers.Add(new SocialNetworkUser { UserName = user.UserName });
            }
            return socialNetworkUsers.ToArray();

        }
    }
}
