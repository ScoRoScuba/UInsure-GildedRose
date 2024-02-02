using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [TestCase("foo", 0, 0, -1,0)]
    [TestCase("foo1", 2,0, 1, 0)]
    [TestCase("foo2", 2, 2, 1, 1)]
    [TestCase("foo2", 0, 4, -1, 2)]
    [TestCase("foo2", 0, 0, -1, 0)]
    [TestCase("Sulfuras, Hand of Ragnaros", 23, 33, 23, 33)]
    [TestCase("Aged Brie", 10, 40, 9, 41)]
    [TestCase("Aged Brie", 10, 50, 9, 50)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 50, 9, 50)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 10, 9, 12)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 8, 8, 7, 10)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 4, 12, 3, 15)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 3, 9, 2, 12)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 50, -1, 0)]
    [TestCase("Conjured", 10, 50, 9, 48)]
    [TestCase("Conjured", 0, 50, -1, 46)]
    public void ItemShouldUpdateToExpectedValues(string itemName, int initialSellin, int initialQuality, int expectedSellIn, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = itemName, SellIn = initialSellin, Quality = initialQuality } };
        var app = new GildedRose(items);

        app.UpdateQuality();
       
        items[0].SellIn.Should().Be(expectedSellIn);
        items[0].Quality.Should().Be(expectedQuality);
    }

}