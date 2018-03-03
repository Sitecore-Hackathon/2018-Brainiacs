using Notification.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;

namespace Notification.Repositories
{
    public interface INotificationRepository
    {
        Guid DataSourceId { get; }
        Item GetDatasource();
        List<User> GetUser(ID id);
        List<User> GetUsers();
        string GetRenderingParameter(string field);
    }
}
