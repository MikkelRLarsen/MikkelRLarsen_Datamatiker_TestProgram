using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Services
{
    public class CounterService : ICounterService
    {
        private readonly ICreateNumber _createNumberService;

        public CounterService(ICreateNumber createNumberService)
        {
            _createNumberService = createNumberService;
        }

        public int GetNumber()
        {
           return _createNumberService.CreateNumber();
        }
    }
}
