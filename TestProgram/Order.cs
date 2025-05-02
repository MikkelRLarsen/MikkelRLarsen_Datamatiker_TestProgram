using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgram.Interfaces;

namespace TestProgram
{



    internal class Order  : IComparable<Order>
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public int CompareTo(Order? other)
        {
            if (other == null || other.ID < this.ID) return 1;
            if (other.ID == this.ID) return 0;
            return -1;
        }


        public Order(int iD, string status, DateTime orderDate)
        {
            ID = iD;
            Status = status;
            OrderDate = orderDate;
        }



    }
}
