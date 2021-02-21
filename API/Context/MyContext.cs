using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("ASP.NET_API_MVC") { }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}