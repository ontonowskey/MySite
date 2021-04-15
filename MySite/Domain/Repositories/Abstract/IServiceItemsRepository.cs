using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySite.Domain.Entities;

namespace MySite.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
    }
}
