using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerService.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime EndLoginTime { get; set; }
        public bool IsOnline { get; set; }
    }
}
