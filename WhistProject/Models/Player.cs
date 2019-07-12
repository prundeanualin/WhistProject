using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhistProject.Models
{
    public class Player
    {
        public String username { get; set; }
        public int score { get; set; }

        public Player(String username, int score)
        {
            this.username = username;
            this.score = score;
        }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            return player != null &&
                   username == player.username &&
                   score == player.score;
        }
    }
}