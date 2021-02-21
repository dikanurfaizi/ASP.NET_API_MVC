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
    public class SuppliersController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44354/API/")
        };
        // GET: Suppliers
        public ActionResult Index()
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
            return View(suppliers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Suppliers", supplier).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IEnumerable<Supplier> suppliers = null;
            var responseTalk = client.GetAsync("Suppliers");
            responseTalk.Wait();
            var result = responseTalk.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }
            return View(suppliers.FirstOrDefault(s => s.SupplierID == id));
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier, int id)
        {
            HttpResponseMessage response = client.PutAsJsonAsync<Supplier>("Suppliers/" + id, supplier).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IEnumerable<Supplier> suppliers = null;
            var responseTalk = client.GetAsync("Suppliers");
            responseTalk.Wait();
            var result = responseTalk.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }
            return View(suppliers.FirstOrDefault(s => s.SupplierID == id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Supplier supplier)
        {
            var deleteTask = client.DeleteAsync("Suppliers/" + id.ToString());
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
            HttpResponseMessage response = await client.GetAsync("Suppliers");
            var data = await response.Content.ReadAsAsync<IList<Supplier>>();
            var supplier = data.FirstOrDefault(s => s.SupplierID == id);
            return View(supplier);
        }
    }
}