using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhistProject.Models
{
    public class Player
    {
        [StringLength(30, MinimumLength = 4)]
        [Required]
        public string username { get; set; }
        public List<string> chat { get; set; }
        public string msg;

        public Player(String username)
        {
            this.username = username;
        }

        public Player()
        {
            chat = new List<string>();
        }

        public void AddMessage(string msg)
        {
            chat.Add(msg);
        }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            return player != null &&
                   username == player.username;
        }
    }
}