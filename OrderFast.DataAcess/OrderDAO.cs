using OrderFast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderFast.Common;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace OrderFast.DataAcess
{
    public class OrderDAO : IOrderDAO
    {
       
        public int AddOrder(Order O)//to add the new order
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = O.OrderDate
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderBy",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = O.OrderBy
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@TotalBill",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input,
                Value = O.TotalBill
            });


            string sql = "addorder  @OrderDate, @OrderBy, @TotalBill ;";


            return DBCommon.ExecuteNonQuerySql(sql, parameters);

        }

        public int DeleteOrder(int id)// to delete the order by its id
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = "deleteorder " + id + ";";
            return (int)DBCommon.ExecuteNonQuerySql(sql,parameters);
        }

        public List<Order> GetOrder()
        {
            var order_t = DBCommon.GetResultDataTableBySql("getorders;");
            List<Order> ord = new List<Order>();
            for (int i = 0; i < order_t.Rows.Count; i++)
            {
                Order order = new Order();
                order.Id = Convert.ToInt32(order_t.Rows[i]["Id"]);
                order.OrderDate = Convert.ToDateTime(order_t.Rows[i]["OrderDate"]);
                order.OrderBy = Convert.ToString(order_t.Rows[i]["OrderBy"]);
                order.TotalBill = Convert.ToInt32(order_t.Rows[i]["TotalBill"]);
                ord.Add(order);
            }
            return ord;

        }

        public List<Order> GetOrderById(int id)//to get a specific order by its id
        {

            var order_t = DBCommon.GetResultDataTableBySql("getordersbyid "+id+" ;");
            List<Order> ord = new List<Order>();
            for (int i = 0; i < order_t.Rows.Count; i++)
            {
                Order order = new Order();
                order.Id = Convert.ToInt32(order_t.Rows[i]["Id"]);
                order.OrderDate = Convert.ToDateTime(order_t.Rows[i]["OrderDate"]);
                order.OrderBy = Convert.ToString(order_t.Rows[i]["OrderBy"]);
                order.TotalBill = Convert.ToInt32(order_t.Rows[i]["TotalBill"]);
                ord.Add(order);
            }
            return ord;
        }

        public int UpdateOrder(Order O)//update the existing order
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = O.Id
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = O.OrderDate.ToString()
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderBy",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = O.OrderBy
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@TotalBill",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input,
                Value = O.TotalBill
            });


            string sql = "updateorder @Id, @OrderDate, @OrderBy, @TotalBill ;";


            return DBCommon.ExecuteNonQuerySql(sql, parameters);
        }
    }
}
