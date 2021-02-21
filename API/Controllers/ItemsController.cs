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
    public class ItemsController : ApiController
    {
        ItemRepository repository = new ItemRepository();
        public IHttpActionResult Post(Item item)
        {
            if (repository.Create(item) == 1)
            {
                return Ok("Item data has been saved");
            }
            else
            {
                return Ok("Item data cannot be storeed");
            }
        }

        public IHttpActionResult Delete(int Id)
        {
            if (repository.Delete(Id) != 0)
            {
                return Ok("Item data has been deleted");
            }
            else
            {
                return Ok("Item data cannot be deleted because ID cannot be found");
            }
        }

        public IHttpActionResult Put(Item item, int Id)
        {
            if (repository.Update(item, Id) != 0)
            {
                return Ok("Item data has been updated");
            }
            else
            {
                return Ok("Item data cannot be updated");
            }
        }

        public IEnumerable<ViewModel> Get()
        {
            if(repository.Get().Count() > 0)
            {
                return repository.Get();
            }
            else
            {
                return null;
            }
            
        }

        public Task<IEnumerable<ViewModel>> Get(int Id)
        {
            return repository.Get(Id);
        }
    }
}
