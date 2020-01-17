using MobileOperatorSoft.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft
{
    class Fasade
    {
        private INumberService numberService;
        private IClientService clientService;
        private ITarifService tarifService;

        public Fasade (INumberService numberService, IClientService clientService, ITarifService tarifService)
        {
            this.numberService = numberService;
            this.clientService = clientService;
            this.tarifService = tarifService;
        }

        public List<Number> GetAllAvailibleNumbers()
        {
            return numberService.GetAllAvailibleNumbers();
        }

        public List<Tarif> GetAllTarifs()
        {
            return tarifService.ReadAll();
        }

        public bool RegisterClient(int number, int tarifId)
        {
            Tarif tarif = tarifService.Read(tarifId);
            if (tarif == null)
            {
                return false;
            }
            Number numberEntity = numberService.Read(number);
            if (numberEntity == null || !numberEntity.IsAvailible)
            {
                return false;
            }
            return clientService.Create(new Client(numberEntity, tarif)) > 0;
        }

        public bool ChangeClientTarif(int number, int tarifId)
        {
            Tarif tarif = tarifService.Read(tarifId);
            if (tarif == null)
            {
                return false;
            }
            Number numberEntity = numberService.Read(number);
            if (numberEntity == null || !numberEntity.IsAvailible)
            {
                return false;
            }
            Client client = clientService.Read(number);
            if (client == null)
            {
                return false;
            }
            client.Tarif = tarif;
            return clientService.Update(client.GetId(), client);
        }

        public Client ShowClientInformation(int number)
        {
            return clientService.Read(number);
        }
        
        public bool PutMoneyOnClientBalanse(int number, double money)
        {
            Client client = clientService.Read(number);
            if (client == null)
            {
                return false;
            }

            return client.PutMoneyOnBalans(money);
        }
    }
}
