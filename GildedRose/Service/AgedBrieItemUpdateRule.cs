using GildedRoseKata.Service;

namespace GildedRoseKata.Service
{
    public class AgedBrieItemUpdateRule : IItemUpdateRule
    {
        public string RuleName => "Aged Brie";

        public void UpdateItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }
}
