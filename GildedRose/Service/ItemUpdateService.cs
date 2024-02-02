using System;
using System.Linq;

namespace GildedRoseKata.Service
{
    public class ItemUpdateService : IItemUpdateService
    {
        private readonly IItemUpdateRule[] _itemUpdateRules;
        private readonly IItemUpdateRule _defaultRule;

        public ItemUpdateService(IItemUpdateRule[] itemUpdateRules)
        {
            _itemUpdateRules = itemUpdateRules;

            _defaultRule = _itemUpdateRules.SingleOrDefault(i => i.RuleName == "Default");
        }

        public void UpdateItem(Item item)
        {
            var itemRule = _itemUpdateRules.SingleOrDefault(i => i.RuleName == item.Name) ?? _defaultRule;
            if (itemRule == null)
            {
                throw new Exception();
            }

            itemRule.UpdateItem(item);
        }
    }
}
