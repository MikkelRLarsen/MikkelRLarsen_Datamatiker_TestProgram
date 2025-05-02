using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Services
{
    public class CreateNumberService : ICreateNumber
    {
        public int CreateNumber()
        {
            Random rng = new Random();
            return rng.Next(1,11);
        }
    }
}
