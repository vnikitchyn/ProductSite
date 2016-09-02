using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductSite.Controllers
{
    public class ProductController : ApiController
    {
        private ProductContext _db = new ProductContext();
        [HttpGet]
        //public List <Product> Get() { 
        
        //    return _db.Products.ToList<Product>();
        //}
        public Product Get(int id)
        {
            return _db.Products.First(p => p.Id == id);
        }

        public Product Get(int id, string name)
        {
            return _db.Products.First(p => p.Id == id & p.Name == name);
        }

        public JToken Get()
        {
            var slaves = _db.Products.ToArray<Product>();
            JToken json = JsonConvert.SerializeObject(slaves);
            return json;
        }

        public string Post (Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return "ok";
            }
            catch
            {
                return "false";
            }
        }
    }
}
