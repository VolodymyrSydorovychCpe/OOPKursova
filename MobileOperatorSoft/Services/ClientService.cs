using MobileOperatorSoft.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.Services
{
    class ClientService : ServiceSkeleton<Client>, IClientService
    {
        public ClientService(ClientDao clientDao) : base(clientDao) { }

        public bool SpendNextMinute(int clientId)
        {
            Client client = Read(clientId);
            if (client.IsClientAbleToGetNextMinute())
            {
                client.SpendMinutes(1);
                return true;
            } else
            {
                return false;
            }
        }

        public bool SpendNextMegabite(int clientId)
        {
            Client client = Read(clientId);
            if (client.IsClientAbleToGetNextMegabiteOfInternet())
            {
                client.SpendInternet(1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
