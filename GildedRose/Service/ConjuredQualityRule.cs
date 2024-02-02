namespace GildedRoseKata.Service
{
    public class ConjuredQualityRule
    {
        public readonly string RuleName = "Conjured";

        public void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= item.SellIn > 0 ? 2 : 4;
            }

            item.SellIn--;
        }
    }
}
