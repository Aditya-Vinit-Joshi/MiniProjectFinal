using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess dao = new DataAccess();

            int choice;
            do
            {

                Console.WriteLine("1. Add Orders\n2. Display Orders\n3.Exit");
                Console.WriteLine("Enter the choice");
                choice = int.Parse(Console.ReadLine());

                Order_Manager orderManager = new Order_Manager();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("================== Add Order Form =================");

                        Order order = new Order();

                        string cname, spname;
                        order.order_date = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
                        Console.WriteLine("Enter Order Amount:");
                        order.Amount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Customer Name:");
                        cname = Console.ReadLine();
                        Console.WriteLine("Enter Sales Person Name:");
                        spname = Console.ReadLine();

                        

                        Console.WriteLine("Add Order?(Y/N)");
                        string confirm = Console.ReadLine();
                        if (confirm == "Y")
                        {
                            orderManager.AddOrder(order, cname, spname);
                            Console.WriteLine("Order Details Added Successfully");
                        }
                        else
                        {
                            break;
                        }





                        /*   try
                           {

                               OrderManager orderManager = new OrderManager();
                               orderManager.AddOrder(order);

                               Console.WriteLine("Add Order?(Y/N)");
                               string confirm = Console.ReadLine();
                               if (confirm == "Y")
                               {
                                   dao.AddOrder(order, cname, spname);
                                   Console.WriteLine("Order Details Added Successfully");
                               }
                               else
                               {
                                   break;
                               }
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
                           finally
                           {

                           }*/
                        break;

                    case 2:

                        Console.WriteLine("================== Display Orders =================");
                        Console.Write("Enter SalesPerson Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Display?(Y/N)");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            var lstorders = orderManager.DisplayOrder(name);
                            foreach (var e in lstorders)
                            {
                                Console.WriteLine($"{e.order_date}\t{e.Order_id}\t{e.Amount}\t{e.cust_id}\t{e.salesperson_id}");
                            }
                        }
                        else
                        {
                            break;
                        }


                    /* try
                     {
                         Console.WriteLine("================== Display Orders =================");
                         Console.Write("Enter SalesPerson Name:");
                         string name = Console.ReadLine();
                         Console.WriteLine("Display?(Y/N)");
                         string confirm = Console.ReadLine();
                         if (confirm == "Y")
                         {
                             var lstorders = dao.DisplayDetails(name);
                             foreach (var e in lstorders)
                             {
                                 Console.WriteLine($"{e.order_date}\t{e.Order_id}\t{e.Amount}\t{e.cust_id}\t{e.salesperson_id}");
                             }
                         }
                         else
                         {
                             break;
                         }
                     }*/
                    /*catch (InvalidSalesPersonNameException ex)
                    {
                        Console.WriteLine(ex.Message);
                        ErrorLogger.LogError(ex);
                    }
                    catch (NoOrdersFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        ErrorLogger.LogError(ex);
                    }
                    */
                    break;
                    default:
                        break;
                }
            } while (choice != 3);
        }
    }
    }

