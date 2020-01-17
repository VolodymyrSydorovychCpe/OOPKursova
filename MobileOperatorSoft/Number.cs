using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft
{
    class Number : IEntity
    {
        private int number;
        public int MobileNumber
        {
            get { return number; }
        }

        private bool isAvailible;
        public bool IsAvailible
        {
            get { return isAvailible; }
            set { isAvailible = value; }
        }

        public Number(int number)
        {
            this.number = number;
            isAvailible = true;
        }

        public int GetId()
        {
           return number;
        }

        public override string ToString()
        {
            return number.ToString();
        }
    }
}
