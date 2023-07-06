using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataAceess
    {
        void AddOrder(Order order, string cname, string sname);

        List<Order> GetAllOrder(string name);
        

    }

}
