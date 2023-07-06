using DataAccessLayer;
using Models;
using SalesOrderExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class Order_Manager
    {
        public void AddOrder(Order order, string cname, string sname)
        {
            try
            {
                DataAccess data = new DataAccess();
                data.AddOrder(order, cname, sname);

            }
            catch(InvalidOrderAmountException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }

            catch(InvalidCustomerNameException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }

            catch (InvalidSalesPersonNameException ex)
            {
                Console.WriteLine(ex.Message);   
                ErrorLogger.LogError(ex);
            }

            catch (NoOrdersFoundException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public List<Order> DisplayOrder(string spName)
        {
            DataAccess data = new DataAccess();
            List<Order> orders = new List<Order>();

            try
            {
                orders = data.GetAllOrder(spName);

            }

            catch (InvalidOrderAmountException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }

            catch (InvalidCustomerNameException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }

            catch (InvalidSalesPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }

            catch (NoOrdersFoundException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return orders;
        }
    }
}
