using Notification.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notification.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public Guid DataSourceId
        {
            get
            {
                return GetDatasource() != null ? GetDatasource().ID.Guid : Guid.Empty;
            }
        }
        public Item GetDatasource()
        {
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (dataSource != null)
            {
                var items = Sitecore.Context.Database.GetItem(dataSource);
                if (items != null)
                {
                    return items;
                }
            }
            return null;
        }

        public List<User> GetUsers()
        {
            Item source = GetDatasource();
            List<User> Items = new List<User>();
            if (source != null && source.Children != null && source.Children.Any())
            {
                foreach (Item item in source.Children)
                {
                    User user = new User();

                    Items.Add(user);
                }

                return Items;
            }
            return Items;
        }
        public List<User> GetUser(ID id)
        {
            Item source = Sitecore.Context.Database.GetItem(id);
            List<User> Items = new List<User>();
            if (source != null && source.Children != null && source.Children.Any())
            {

                foreach (Item item in source.Children)
                {
                    User user = new User();

                    Items.Add(user);
                }

                return Items;
            }
            return Items;
        }
        public string GetRenderingParameter(string field)
        {
            if (!string.IsNullOrWhiteSpace(field))
            {
                return RenderingContext.Current.Rendering.Parameters[field];
            }
            return string.Empty;
        }
    }
}