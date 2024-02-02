using System.Collections.Generic;
using GildedRoseKata.Service;
using GildedRoseKata.Service.ItemUpdateRules;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    // this is not ideal, y=would prefer to inject, however to make allowances for keeping class unchanged, these are created on CTOR
    private readonly IItemUpdateService _itemUpdateService = new ItemUpdateService(new IItemUpdateRule[]
    {
        new DefaultItemUpdateRule(),
        new AgedBrieItemUpdateRule(),
        new BackstagePassItemUpdateRule(),
        new SulfurasItemUpdateRule(),
        new ConjuredItemUpdateRule()
    });

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach( var item in _items) 
        {
            _itemUpdateService.UpdateItem(item);
        }
    }
}