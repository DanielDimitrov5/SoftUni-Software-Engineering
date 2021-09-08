﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public Town()
        {
            Teams = new HashSet<Team>();
        }

        public int TownId { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}