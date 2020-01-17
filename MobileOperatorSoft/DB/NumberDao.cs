using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.DB
{
    class NumberDao : DaoSceleton<Number>
    {
        public NumberDao(IStorage storage) : base(storage) { }
    }
}
