using Models;
using SalesOrderExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccess : IDataAceess
    {
        public void AddOrder(Order order, string cname, string sname)
        {
            var dbCtx = new TrialEntities();

            // Order Exception Cases

            if (order.Amount <= 0)
            {
                throw new InvalidOrderAmountException("Invalid amount, must be greater than 0");
            }

            /*  DateTime dDate;
            if (DateTime.TryParse(order.order_date.ToString(), out dDate))
            {
                String.Format("{0:dd/MM/yyyy}", dDate);
                Console.WriteLine("Invalid");
            }*/
            var rst4 = dbCtx.Customers.Where(c => c.Name == cname).ToList();

            if (rst4.Count() == 0)
            {
                throw new InvalidCustomerNameException("Customer name does not exist");
            }

            var rst5 = dbCtx.SalesPersons.Where(s => s.Name == sname).ToList();

            if (rst5.Count() == 0)
            {
                throw new InvalidSalesPersonNameException("Sales person name does not exist");
            }



            order.salesperson_id = dbCtx.SalesPersons
                                     .Where(e => e.Name == sname)
                                     .Select(o => o.ID).FirstOrDefault();

            order.cust_id = dbCtx.Customers
                .Where(e => e.Name == cname)
                .Select(o => o.ID).FirstOrDefault();

            dbCtx.Orders.Add(order);


            dbCtx.SaveChanges();
        }

        public List<Order> GetAllOrder(string name)
        {
            var dbCtx = new TrialEntities();
            var id = dbCtx.SalesPersons
                                     .Where(e => e.Name == name).OrderBy(o => o.ID)
                                     .Select(o => o.ID).FirstOrDefault();
            var id2 = dbCtx.Orders
                                     .Where(e => e.salesperson_id == id).ToList();
            var id1 = dbCtx.SalesPersons
                                     .Where(e => e.Name == name);
            if (id1.Count() == 0)
            {
                throw new NoOrdersFoundException("Sales person name does not exist");

            }
            if (id2.Count() == 0)
            {
                throw new NoOrdersFoundException("No orders found for this sales person");
            }
            else
            {
                var result = dbCtx.Orders.Where(e => e.salesperson_id == id).ToList();
                return result;
            }
        }

        

    }
}
