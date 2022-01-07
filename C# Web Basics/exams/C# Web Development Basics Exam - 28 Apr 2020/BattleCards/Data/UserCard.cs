namespace BattleCards.Models
{
    public class UserCard
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CardId { get; set; }

        public virtual Card Card { get; set; }
    }
}