using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Breeze.ContextProvider.EF6;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace EFWebApiServices.Models
{
    public class Repository : IRepository
    {
        #region initial implementation, includes accessing of navigation properties of a collection
        //private EFWebApiServicesContext db;

        //public Repository(EFWebApiServicesContext db)
        //{
        //    this.db = db;
        //}

        //public IQueryable<Order> GetAllOrders()
        //{
        //    return this.db.Orders;
        //}

        //public IQueryable<Order> GetAllOrdersWithDetails()
        //{
        //    //return this.db.Orders.Include("OrderDetails");

        //    // using System.Data.Entity
        //    return this.db.Orders.Include(o => o.OrderDetails);
        //}

        //public Order GetOrder(int id)
        //{
        //    return this.db.Orders.Include("OrderDetails.Book").FirstOrDefault(o => o.Id == id);

            
        //    // TO DO: transform using lambda expression for inclusion of book property
        //    //return this.db.Orders.Include(x => x.OrderDetails.Select(d => d.Book)).FirstOrDefault(o => o.Id == id); 

        //}
        #endregion

        //private EFWebApiServicesContext db;

        private readonly EFContextProvider<EFWebApiServicesContext> context = new EFContextProvider<EFWebApiServicesContext>();

        //public Repository(EFWebApiServicesContext db)
        //{
        //    this.db = db;
        //}

        public string MetaData
        {
            get { return this.context.Metadata(); }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return this.context.SaveChanges(saveBundle);
        }

        public IQueryable<Book> Books()
        {
            return this.context.Context.Books;
        }

        public IQueryable<Order> Orders()
        {
            return this.context.Context.Orders;
        }
    }
}