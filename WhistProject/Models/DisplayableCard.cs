using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhistProject.Models
{
    public class DisplayableCard
    {
        public Card card{get; set;}
        public const String letterCards = "JQKA";
        public DisplayableCard displayableCard(Card card)
        {
            this.card = card;
            String convertedCard = convertFromIntToString(card);
            DisplayableCard displayable = convertedCard;
            return displayable;
        }
        public String convertFromIntToString(Card card)
        {
            String result = "";
            this.card = card;
            if(card.number <=10)
            {
                result = card.number.ToString();
            }
            else
            {
                switch(card.number)
                {
                    case 11:
                        result = "J";
                        break;
                    case 12:
                        result = "Q";
                        break;
                    case 13:
                        result = "K";
                        break;
                    case 14:
                        result = "A";
                        break;
                }
            }
            return result;
        }

        public static implicit operator DisplayableCard(string v)
        {
            throw new NotImplementedException();
        }
    }
}