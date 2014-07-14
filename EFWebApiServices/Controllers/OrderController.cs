//using EFWebApiServices.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace EFWebApiServices.Controllers
//{
//    public class OrderController : ApiController
//    {
//        private IRepository repository;

//        public OrderController(IRepository repository)
//        {
//            this.repository = repository; 
//        }

//        public IQueryable<Order> Get()
//        {
//            return this.repository.GetAllOrders();
//        }

//        public IQueryable<Order> Get(bool includeDetails)
//        {
//            IQueryable<Order> query;
//            if (includeDetails)
//            {
//                query = this.repository.GetAllOrdersWithDetails();
//            }
//            else
//            {
//                query = this.repository.GetAllOrders();
//            }
//            return query;
//        }

//        public Order Get(int id)
//        {
//            return this.repository.GetOrder(id);
//        }
//    }
//}
