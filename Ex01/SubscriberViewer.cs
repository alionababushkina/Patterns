using System;
using Patterns.Ex01.ExternalLibs.Instagram;
using Patterns.Ex01.ExternalLibs.Twitter;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.Ex01
{
    public class SubscriberViewer
    {
        public Dictionary<SocialNetwork, ISocialStrategy> strategies;

        public SubscriberViewer(IDictionary<SocialNetwork, ISocialStrategy> strategies) => 
            this.strategies = strategies.ToDictionary(k=>k.Key, k=>k.Value);

        /// <summary>
        /// Возвращает список подписчиков пользователя из соц.сети.
        /// TODO: необходимо изменить этот метод по условиям задачи
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="networkType"></param>
        /// <returns></returns>
        /// 
        public SocialNetworkUser[] GetSubscribers(String userName, SocialNetwork networkType)
        {
            return strategies[networkType].GetSocialNetworkUser(userName);
        }

        public void AddStrategies()
        {
            strategies.Add(SocialNetwork.Instagram, new InstagramStrategy());
            strategies.Add(SocialNetwork.Twitter, new TwitterStrategy());
        }

        public void Main()
        {
            AddStrategies();
            GetSubscribers("userName", SocialNetwork.Twitter);

        }

    }
}