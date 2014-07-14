using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
namespace EFWebApiServices.Models
{
    public interface IRepository
    {
        //IQueryable<Order> GetAllOrders();
        //IQueryable<Order> GetAllOrdersWithDetails();
        //Order GetOrder(int id);

        string MetaData { get; }

        SaveResult SaveChanges(JObject saveBundle);

        IQueryable<Book> Books();

        IQueryable<Order> Orders();
    }
}
