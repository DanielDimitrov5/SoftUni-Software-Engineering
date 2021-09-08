namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        [Required]
        public string Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}