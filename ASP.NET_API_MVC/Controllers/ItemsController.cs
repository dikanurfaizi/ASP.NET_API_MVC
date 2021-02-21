using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_API_MVC.Controllers
{
    public class ItemsController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44354/API/")
        };
        // GET: Items
        public ActionResult Index()
        {
            IEnumerable<ViewModel> items = null; //Model
            var responseTask = client.GetAsync("Items"); //Controller
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ViewModel>>();
                readTask.Wait();
                items = readTask.Result;
            }
            return View(items);
        }

        public ActionResult Create()
        {
            GetSupplierList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Items", item).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            GetSupplierList();
            IEnumerable<Item> items = null;
            var responseTalk = client.GetAsync("Items");
            responseTalk.Wait();
            var result = responseTalk.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Item>>();
                readTask.Wait();
                items = readTask.Result;
            }
            return View(items.FirstOrDefault(s => s.ItemId == id));
        }

        [HttpPost]
        public ActionResult Edit(Item item, int id)
        {
            HttpResponseMessage response = client.PutAsJsonAsync<Item>("Items/" + id, item).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IEnumerable<ViewModel> items = null;
            var responseTalk = client.GetAsync("Items");
            responseTalk.Wait();
            var result = responseTalk.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ViewModel>>();
                readTask.Wait();
                items = readTask.Result;
            }
            return View(items.FirstOrDefault(s => s.ItemId == id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Item item)
        {
            var deleteTask = client.DeleteAsync("Items/" + id.ToString());
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync("Items");
            var data = await response.Content.ReadAsAsync<IList<ViewModel>>();
            var item = data.FirstOrDefault(s => s.ItemId == id);
            return View(item);
        }

        public ActionResult GetSupplierList()
        {
            IEnumerable<Supplier> suppliers = null; //Model
            var responseTask = client.GetAsync("Suppliers"); //Controller
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }
            ViewBag.SuppliersList = new SelectList(suppliers, "SupplierID", "SupplierName");
            return View();
        }
    }
}