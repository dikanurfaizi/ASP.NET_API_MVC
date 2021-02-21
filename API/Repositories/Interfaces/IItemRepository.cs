using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface IItemRepository
    {
        IEnumerable<ViewModel> Get();
        Task<IEnumerable<ViewModel>> Get(int ItemId);
        int Create(Item item);
        int Update(Item item, int ItemId);
        int Delete(int ItemId);
    }
}
