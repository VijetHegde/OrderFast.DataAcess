using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderFast.Models;
using OrderFast.Common;

namespace OrderFast.DataAcess
{
    public interface IOrderDAO
    {
        List<Order> GetOrder();//to get all the orders 
        int AddOrder(Order O);//to add the new order
        int UpdateOrder(Order O);//update the existing order
        List<Order> GetOrderById(int id);//to get a specific order by its id
        int DeleteOrder(int id);// to delete the order by its id


    }
}
