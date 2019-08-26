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
        [StringLength(30, MinimumLength = 4)]
        [Required]
        public string username { get; set; }

        public Player(String username)
        {
            this.username = username;
        }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            return player != null &&
                   username == player.username;

        }
    }
}