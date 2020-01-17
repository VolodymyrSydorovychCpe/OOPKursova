using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.DB
{
    class ClientDao : DaoSceleton<Client>
    {
        public ClientDao(IStorage storage) : base(storage) { }
    }
}
