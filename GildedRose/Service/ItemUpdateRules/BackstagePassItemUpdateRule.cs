using GildedRoseKata.Service;

namespace GildedRoseKata.Service
{
    public class BackstagePassItemUpdateRule : IItemUpdateRule
    {
        public string RuleName => "Backstage passes to a TAFKAL80ETC concert";

        public void UpdateItem(Item item)
        {
            if (item.Quality < 50)  
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }
    }
}
