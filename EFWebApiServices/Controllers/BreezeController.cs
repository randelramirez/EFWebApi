using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Breeze.WebApi2;
using EFWebApiServices.Models;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace EFWebApiServices.Controllers
{

    [BreezeController]
    public class BreezeController : ApiController
    {
        private readonly IRepository repository;

        public BreezeController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public string Metadata()
        {
            return this.repository.MetaData;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return this.repository.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Book> Books()
        {
            return this.repository.Books();
        }

        [HttpGet]
        public IQueryable<Order> Orders()
        {
            return this.repository.Orders();
        }
    }
}