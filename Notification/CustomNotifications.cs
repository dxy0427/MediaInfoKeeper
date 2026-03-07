using System.Collections.Generic;
using Emby.Notifications;
using MediaBrowser.Controller;

namespace MediaInfoKeeper.Notification
{
    public class CustomNotifications : INotificationTypeFactory
    {
        public CustomNotifications(IServerApplicationHost appHost)
        {
        }

        public List<NotificationTypeInfo> GetNotificationTypes(string language)
        {
            return new List<NotificationTypeInfo>
            {
                new NotificationTypeInfo
                {
                    Id = "deep.delete",
                    Name = "深度删除",
                    CategoryId = "mediainfo.keeper",
                    CategoryName = Plugin.PluginName
                }
            };
        }
    }
}
