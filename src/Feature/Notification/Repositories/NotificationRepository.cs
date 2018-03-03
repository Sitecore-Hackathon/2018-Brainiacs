using Notification.Core.Extensions;
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
        private Guid datasourceId;
        public Guid DataSourceId
        {
            get
            {
                return GetDatasource() != null ? GetDatasource().ID.Guid : Guid.Empty;
            }
            set
            {
                datasourceId = value;
            }
        }
        public Item GetDatasource()
        {
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (dataSource != null)
            {
                var item = Sitecore.Context.Database.GetItem(dataSource);
                if (item != null)
                {
                    DataSourceId = item.ID.Guid;
                    return item;
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
                    user.Id = item.ID.Guid;
                    user.FirstName = item.GetItemFieldValueString("FirstName");
                    user.LastName = item.GetItemFieldValueString("LastName");
                    user.Email = item.GetItemFieldValueString("Email");
                    user.FireBaseRegistrationId = item.GetItemFieldValueString("FireBaseRegistrationId");
                    user.ProfileImageUrl = item.GetItemFieldValueString("ProfileImageUrl");
                    user.DeviceType = item.GetItemFieldValueString("DeviceType");
                    user.Group = item.GetItemFieldValueString("Group");

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
                    user.Id = item.ID.Guid;
                    user.FirstName = item.GetItemFieldValueString("FirstName");
                    user.LastName = item.GetItemFieldValueString("LastName");
                    user.Email = item.GetItemFieldValueString("Email");
                    user.FireBaseRegistrationId = item.GetItemFieldValueString("FireBaseRegistrationId");
                    user.ProfileImageUrl = item.GetItemFieldValueString("ProfileImageUrl");
                    user.DeviceType = item.GetItemFieldValueString("DeviceType");
                    user.Group = item.GetItemFieldValueString("Group");

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