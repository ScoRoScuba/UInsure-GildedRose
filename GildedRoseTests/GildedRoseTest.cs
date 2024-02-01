using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;
using FluentAssertions;
namespace GildedRoseTests;

public class GildedRoseTest
{
    [TestCase("foo", 0, -1)]
    [TestCase("Sulfuras, Hand of Ragnaros", 0, 0)]
    public void Item_SellInShouldDecrease(string itemName, int initialSellin, int expectedSellIn)
    {
        var items = new List<Item> { new Item { Name = itemName, SellIn = initialSellin, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();
       
        items[0].SellIn.Should().Be(expectedSellIn);
    }

    [Test]
    public void Item_WhenZeroQuality_QualityuDoesNotChange()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(0);
    }

    [Test]
    public void WHenItemQualityGreaterThan0_QualitySHouldDecrease()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 1 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(0);
    }

}