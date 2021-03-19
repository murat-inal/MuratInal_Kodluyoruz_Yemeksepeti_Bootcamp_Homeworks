using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperProject.Models
{
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderQty { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
