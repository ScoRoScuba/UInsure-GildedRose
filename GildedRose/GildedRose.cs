using System.Collections.Generic;
using GildedRoseKata.Service;
using GildedRoseKata.Service.ItemUpdateRules;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach( var item in _items) 
        {
            if (item.Name == "Conjured")
            { 
                new ConjuredItemUpdateRule().UpdateItem(item);
                continue;
            }

            if (item.Name == "Aged Brie")
            {
                new AgedBrieItemUpdateRule().UpdateItem(item);
                continue;
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                new BackstagePassItemUpdateRule().UpdateItem(item);
                continue;
                
            }

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                new SulfurasItemUpdateRule().UpdateItem(item);
                continue;
            }

            new DefaultItemUpdateRule().UpdateItem(item);
        }
    }
}