using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhistProject.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }

        public Player(string username, string email)
        {
            this.username = username;
            this.email = email;
        }

        public Player()
        {

        }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            return player != null &&
                   username == player.username;

        }
    }
}