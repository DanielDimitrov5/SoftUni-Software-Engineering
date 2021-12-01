﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        public string ProductKey { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        public Card Card { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; }
    }
    //•	Id – integer, Primary Key
    //•	Type – enumeration of type PurchaseType, with possible values(“Retail”, “Digital”) (required) 
    //•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes(ex. “ABCD-EFGH-1J3L”) (required)
    //•	Date – Date(required)
    //•	CardId – integer, foreign key(required)
    //•	Card – the purchase’s card(required)
    //•	GameId – integer, foreign key(required)
    //•	Game – the purchase’s game(required)

}