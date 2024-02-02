
namespace GildedRoseKata.Service
{
    public interface IItemUpdateRule
    {
        string RuleName { get; }

        void UpdateItem(Item item);
    }
}
