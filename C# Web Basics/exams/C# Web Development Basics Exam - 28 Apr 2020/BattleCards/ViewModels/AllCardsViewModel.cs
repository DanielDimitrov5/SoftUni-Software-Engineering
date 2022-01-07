using System.Collections.Generic;

namespace BattleCards.ViewModels
{
    public class AllCardsViewModel
    {
        public IEnumerable<CardsViewModel> Cards { get; set; }
    }
}