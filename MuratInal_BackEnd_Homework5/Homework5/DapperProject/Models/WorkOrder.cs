using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperProject.Models
{
    public class WorkOrder
    {
        public int WorkOrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderQty { get; set; }
    }
}
