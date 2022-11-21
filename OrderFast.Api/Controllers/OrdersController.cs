using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFast.DataAcess;
using OrderFast.Models;
using System.Data.SqlClient;

namespace OrderFast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
          IOrderDAO orderDA = new OrderDAO();


        [HttpPost]
        [Route("AddOrder")]
        public int AddOrder(Order O)
        {
            return orderDA.AddOrder(O);
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public int  UpdateOrder(Order O)
        {
            return orderDA.UpdateOrder(O);
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public int DeleteOrder(int id)
        {
            return orderDA.DeleteOrder(id);
        }

        [HttpGet]
        [Route("GetOrderById/{id}")]
        public List<Order> GetOrderById(int id)
        {
            return orderDA.GetOrderById(id);
        }

        [HttpGet]
        [Route("GetOrder")]
        public List<Order> Get()
        {
            return orderDA.GetOrder();
        }





    }
}
