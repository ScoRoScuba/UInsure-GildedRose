namespace GildedRoseKata.Service.ItemUpdateRules
{
    public class ConjuredItemUpdateRule : IItemUpdateRule
    {
        public string RuleName => "Conjured";

        public void UpdateItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= item.SellIn > 0 ? 2 : 4;
            }

            item.SellIn--;
        }
    }
}
