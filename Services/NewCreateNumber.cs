using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Services
{
    public class NewCreateNumber : ICreateNumber
    {
        public int CreateNumber()
        {
            return 10;
        }
    }
}
