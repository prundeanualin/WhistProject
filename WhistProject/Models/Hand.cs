using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhistProject.Models
{
    public class Hand
    {
        List<Player> players;
        public int typeOfHand;
        public Boolean complete;
        public int rotateNumber = 0;
        public int rotateForOneRound = 0;
        /**
         * there is need for a method which flushes the deck
         * and then cards are given to player corresponding the typeOfHand
         */
        public Hand(List<Player> players, int typeOfHand)
        {
            this.players = players;
            this.typeOfHand = typeOfHand;
        }
        public void doOneRound()
        {
            int capacity = this.players.Capacity;
            for (int i = 0; i< capacity; i++)
            {
                //wait for player to drop card (needs to be implemented)
                // i'm thinking to use the deck class
                /// rotateforoneround gives player the access to drop card.
                rotateForOneRound++;
                if (rotateForOneRound == capacity)
                    rotateNumber++;
            }
            //in this method we should also determine who lost and who won 
            //as well a method where user proposes how many hands will do
        }
        public void playHand()
        {
            for(int i =0; i<typeOfHand; i++)
            {
                if (this.rotateNumber == this.typeOfHand)
                    this.complete = true;
                doOneRound();
            }
            //concretization of the playability of a hand
        }
        //checks if hand is compeleted.
        public Boolean isCompleted()
        {
            if (this.rotateNumber == this.typeOfHand)
                return true;
            return false;
        }
            
    }
}