using System;
using System.Collections.Generic;
using System.Linq;
using Emby.Notifications;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Notifications;

namespace MediaInfoKeeper.Common
{
    public sealed class NotificationApi
    {
        private readonly INotificationManager notificationManager;

        public NotificationApi(INotificationManager notificationManager)
        {
            this.notificationManager = notificationManager;
        }

        public void DeepDeleteSendNotification(BaseItem item, HashSet<string> mountPaths)
        {
            if (mountPaths == null || mountPaths.Count == 0)
            {
                return;
            }

            LibraryApi.FetchUsers();

            var paths = mountPaths
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
            if (paths.Length == 0)
            {
                return;
            }

            var users = LibraryApi.AllUsers.Select(e => e.Key);
            foreach (var user in users)
            {
                var request = new NotificationRequest
                {
                    Title = Plugin.PluginName + " - 深度删除",
                    EventId = "deep.delete",
                    User = user,
                    Item = item,
                    Description = string.Format(
                        "Item Name:{0}{1}{0}{0}Item Path:{0}{2}{0}{0}Mount Paths:{0}{3}",
                        Environment.NewLine,
                        item?.Name ?? string.Empty,
                        item?.Path ?? string.Empty,
                        string.Join(Environment.NewLine, paths))
                };

                this.notificationManager.SendNotification(request);
            }
        }
    }
}
