using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhistProject.Models
{
    public class Card
    {   
        public int number { get; set; }

        public Card card(int number)
        {
            this.number = number;
            if (checkRange(number) == true)
            {
                Card result = card(number);
                return result;
            }
            else
            {
                return null;
            }
            
        }

        protected Boolean checkRange(int number)
        {
            if (this.number <= 14 && this.number >= 2)
                return true;
            return false;
        }

    }
}