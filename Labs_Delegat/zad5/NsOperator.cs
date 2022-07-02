using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    enum Category
    {
        News = 1,
        Weather,
        Sport,
        Events,
        Humor
    }
    class NsOperator
    {
        private delegate void MethodAdd(string msg);
        private event MethodAdd SubscribeNews;
        private event MethodAdd SubscribeWeather;
        private event MethodAdd SubscribeSport;
        private event MethodAdd SubscribeEvents;
        private event MethodAdd SubscribeHumor;
        public void SubscribeTo(Category id, Sub item)
        {
            switch (id)
            {
                case Category.News:
                    SubscribeNews += item.AddNews;
                    break;
                case Category.Weather:
                    SubscribeWeather += item.AddNews;
                    break;
                case Category.Sport:
                    SubscribeSport += item.AddNews;
                    break;
                case Category.Events:
                    SubscribeEvents += item.AddNews;
                    break;
                case Category.Humor:
                    SubscribeHumor += item.AddNews;
                    break;
                default:
                    break;
            }
        }

        public void SubscribeFrom(Category id, Sub item)
        {
            switch (id)
            {
                case Category.News:
                    SubscribeNews -= item.AddNews;
                    break;
                case Category.Weather:
                    SubscribeWeather -= item.AddNews;
                    break;
                case Category.Sport:
                    SubscribeSport -= item.AddNews;
                    break;
                case Category.Events:
                    SubscribeEvents -= item.AddNews;
                    break;
                case Category.Humor:
                    SubscribeHumor -= item.AddNews;
                    break;
                default:
                    break;
            }
        }

        public void AddNews(Category id, string msg)
        {
            switch (id)
            {
                case Category.News:
                    if (SubscribeNews != null)
                        SubscribeNews(msg);
                    break;
                case Category.Weather:
                    if (SubscribeWeather != null)
                        SubscribeWeather(msg);
                    break;
                case Category.Sport:
                    if (SubscribeSport != null)
                        SubscribeSport(msg);
                    break;
                case Category.Events:
                    if (SubscribeEvents != null)
                        SubscribeEvents(msg);
                    break;
                case Category.Humor:
                    if (SubscribeHumor != null)
                        SubscribeHumor(msg);
                    break;
                default:
                    break;
            }
        }
    }
}
