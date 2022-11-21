using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFast.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public string OrderBy { get; set; }  
        
        public int TotalBill { get; set; }   
    }
}
