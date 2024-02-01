using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;
using FluentAssertions;
namespace GildedRoseTests;

public class GildedRoseTest
{
    [TestCase("foo", 0, -1)]
    [TestCase("foo1", 2, 1)]
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

    [TestCase("foo", 1, 0)]
    [TestCase("foo1", 2, 1)]
    public void WHenItemSellInDateValid_QualityShouldDecrease(string itemName, int initialQuality, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = itemName, SellIn = 2, Quality = initialQuality } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [TestCase("foo", 4, 2)]
    [TestCase("foo1", 2, 0)]
    public void WHenItemSellInDatePassed_QualityShouldDecreaseTwiceAsFast(string itemName, int initialQuality, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = initialQuality } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    public void WhenItemSulfuras_DoesNotUpdate()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].SellIn.Should().Be(10);
        items[0].Quality.Should().Be(10);
    }
}