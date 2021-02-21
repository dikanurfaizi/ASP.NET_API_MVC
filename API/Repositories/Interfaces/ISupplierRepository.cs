using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface ISupplierRepository
    {
        IEnumerable<Supplier> Get();
        Task<IEnumerable<Supplier>> Get(int Id);
        int Create(Supplier supplier);
        int Update(Supplier supplier, int Id);
        int Delete(int Id);
    }
}
