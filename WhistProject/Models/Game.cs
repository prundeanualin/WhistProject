using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhistProject.Models
{
    public class Game
    {
        public Hand hand;
        public int counter;
        public int numberOfOnes;
        public int numberOfEights;
        public int nrOfHandsPlayed;
        public int expectedToPlay;
        public List<Player> players;
        public Game(List<string> names)
        {
            this.players = new List<Player>();
            for(int i = 0;i < names.Count ; i++)
            {
                players.Add(new Player(names[i]));
            }
        }
        public int getSize(List<Player> players)
        {
            this.players = players;
            return players.Capacity;
        }
        public void startGame()
        {
            //pretty straight forward logic of the whist game algorithm
            // based on hands already implemented
            // rest of magic happens in class hand
            numberOfEights = this.players.Capacity;
            numberOfOnes = this.players.Capacity * 2;
            expectedToPlay = numberOfEights + numberOfOnes + 12;
            for(int i=0; i< numberOfOnes/2;i++)
            {
                this.hand = new Hand(players, 1);
                this.hand.playHand();
                nrOfHandsPlayed++;
            }
            for(int i = 2; i<=7; i++)
            {
                this.hand = new Hand(players, i);
                this.hand.playHand();
                nrOfHandsPlayed++;
            }
            for(int i=0; i< numberOfEights; i++)
            {
                this.hand = new Hand(players, 8);
                this.hand.playHand();
                nrOfHandsPlayed++;
            }
            for(int i= 7; i>=2; i--)
            {
                this.hand = new Hand(players, i);
                this.hand.playHand();
                nrOfHandsPlayed++;
            }
            for(int i=0; i<numberOfOnes/2;i++)
            {
                this.hand = new Hand(players, 1);
                this.hand.playHand();
                nrOfHandsPlayed++;
            }
            if (isCompleted())
                gameCompleted();
           
        }
        public Boolean isCompleted()
        {
            if (nrOfHandsPlayed == expectedToPlay)
                return true;
            return false;
        }
        public void gameCompleted()
        {
            /**
             * this should contain the implementation of the engine which ends the game
             * and takes you back to lobby
             * in this method there should also be an update of the users score
             */
             
        }
        public void updateScores()
        {
            for(int i = 0; i< this.players.Capacity; i++)
            {
                //for each player(i) update the score + ingame score
            }
        }    
   
    }
}