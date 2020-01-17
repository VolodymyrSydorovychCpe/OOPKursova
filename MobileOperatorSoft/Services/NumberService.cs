using MobileOperatorSoft.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.Services
{
    class NumberService : ServiceSkeleton<Number> , INumberService
    {
        public NumberService(NumberDao numberDao) : base(numberDao) { }

        public List<Number> GetAllAvailibleNumbers()
        {
            return ReadAll();
        }
    }
}
