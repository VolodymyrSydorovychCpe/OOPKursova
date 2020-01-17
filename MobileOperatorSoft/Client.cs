using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft
{
    class Client : IEntity
    {
        private Number number;
        private Tarif tarif;
        public Tarif Tarif
        {
            get { return tarif; }
            set { tarif = value; }
        }

        private int spentFreeMinutes;
        private int spentFreeMegabitesOfInternet;
        private double balans;

        public Client(Number number, Tarif tarif)
        {
            this.number = number;
            this.tarif = tarif;
        }

        public int GetId()
        {
           return number.GetId();
        }

        public Boolean PutMoneyOnBalans (double amountOfMoney)
        {
            balans += amountOfMoney;
            return true;
        }

        public void SpendMinutes(int amountOfMinutes)
        {
            if (spentFreeMinutes + amountOfMinutes <= tarif.AmountOfFreeMinutes)
            {
                spentFreeMinutes += amountOfMinutes;
            } else
            {
                balans -= tarif.CostOfMinute * amountOfMinutes;
            }
        }
        
        public void SpendInternet(int amountOfMegabites)
        {
            if (spentFreeMegabitesOfInternet + amountOfMegabites <= tarif.AmountOfFreeMegabitesOfInternet)
            {
                spentFreeMegabitesOfInternet += amountOfMegabites;
            } else
            {
                balans -= tarif.CostOfMegaBite * amountOfMegabites;
            }
        }

        public bool IsClientAbleToGetNextMinute()
        {
            return tarif.AmountOfFreeMinutes - spentFreeMinutes > 0 || balans - tarif.CostOfMinute > 0;
        }

        public Boolean IsClientAbleToGetNextMegabiteOfInternet()
        {
            return tarif.AmountOfFreeMegabitesOfInternet - spentFreeMegabitesOfInternet > 0 ||
                balans - spentFreeMegabitesOfInternet > 0;
        }

        public override string ToString()
        {
            return number.ToString() + tarif.ToString() + " balance: " + balans.ToString() + "$;";
        }
    }
}
