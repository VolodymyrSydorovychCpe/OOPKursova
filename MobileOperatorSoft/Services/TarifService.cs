using MobileOperatorSoft.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.Services
{
    class TarifService : ServiceSkeleton<Tarif>, ITarifService
    {
        public TarifService(TarifDao tarifDao) : base(tarifDao) { }
    }
}
