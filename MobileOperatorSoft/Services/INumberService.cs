using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.Services
{
    interface INumberService : IService<Number>
    {
        List<Number> GetAllAvailibleNumbers();
    }
}
