namespace GildedRoseKata.Service.ItemUpdateRules
{
    public class DefaultItemUpdateRule : IItemUpdateRule
    {
        public string RuleName => "Default";

        public void UpdateItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }
    }
}
