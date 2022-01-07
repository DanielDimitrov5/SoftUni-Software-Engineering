using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SIS.MvcFramework;

namespace BattleCards.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Role = IdentityRole.User;
            Cards = new HashSet<UserCard>();
        }

        public ICollection<UserCard> Cards { get; set; }
    }
}
