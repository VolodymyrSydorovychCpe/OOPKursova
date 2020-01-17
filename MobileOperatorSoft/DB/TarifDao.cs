using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.DB
{
    class TarifDao : DaoSceleton<Tarif>
    {
        public TarifDao(IStorage storage) : base(storage) { }
    }
}
