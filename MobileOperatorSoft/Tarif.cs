using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft
{
    class Tarif : IEntity
    {
        private int id;

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int amountOfFreeMinutes;
        public int AmountOfFreeMinutes
        {
            get
            {
                return amountOfFreeMinutes;
            }
            set
            {
                amountOfFreeMinutes = value;
            }
        }

        private int amountOfFreeMegabitesOfInternet;
        public int AmountOfFreeMegabitesOfInternet
        {
            get
            {
                return amountOfFreeMegabitesOfInternet;
            }
            set
            {
                amountOfFreeMegabitesOfInternet = value;
            }
        }

        private double costOfMinute;
        public double CostOfMinute
        {
            get
            {
                return costOfMinute;
            }
            set
            {
                costOfMinute = value;
            }
        }

        private double costOfMegaBite;
        public double CostOfMegaBite
        {
            get
            {
                return costOfMegaBite;
            }
            set
            {
                costOfMegaBite = value;
            }
        }

        public Tarif(int id, string name, int amountOfFreeMinutes, 
            int amountOfFreeMegabitesOfInternet, double costOfMinute, double costOfMegaBite)
        {
            this.id = id;
            this.name = name;
            this.amountOfFreeMinutes = amountOfFreeMinutes;
            this.amountOfFreeMegabitesOfInternet = amountOfFreeMegabitesOfInternet;
            this.costOfMinute = costOfMinute;
            this.costOfMegaBite = costOfMegaBite;
        }

        public int GetId()
        {
            return id;
        }
        
        public override string ToString()
        {
            return "ID: " + id + "; "
                + "name: " + name + "; "
                + "amountOfFreeMinutes: " + amountOfFreeMinutes + ";"
                + "amountOfFreeMegabitesOfInternet: " + amountOfFreeMegabitesOfInternet + ";"
                + "costOfMinute: " + costOfMinute + ";"
                + "costOfMegaBite: " + costOfMegaBite + ";";
        }
    }    
}
