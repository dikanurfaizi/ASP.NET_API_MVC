using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        // GET: Suppliers
        SupplierRepository repository = new SupplierRepository();
        public IHttpActionResult Post(Supplier supplier)
        {
            if (repository.Create(supplier) == 1)
            {
                return Ok("Supplier data has been saved");
            }
            else
            {
                return BadRequest("Supplier data cannot be stored");
            }
        }

        public IHttpActionResult Delete(int Id)
        {
            if (repository.Delete(Id) == 1)
            {
                return Ok("Supplier data has been deleted");
            }
            else
            {
                return BadRequest("Supplier data cannot be deleted because ID cannot be found");
            }
        }

        public IHttpActionResult Put(Supplier supplier, int Id)
        {
            if (repository.Update(supplier, Id) == 1)
            {
                return Ok("Supplier data has been updated");
            }
            else
            {
                return BadRequest("Supplier data cannot be updated because ID cannot be found");
            }
        }

        public IEnumerable<Supplier> Get()
        {
            if (repository.Get().Count() > 0)
            {
                return repository.Get();
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Supplier>> Get(int Id)
        {
            return repository.Get(Id);
        }
    }
}
