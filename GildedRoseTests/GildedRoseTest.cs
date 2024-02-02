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

    [Test]
    public void WHenItemSellInDatePassed_QualityDoesntGoNegative()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 1 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(0);
    }

    [Test]
    public void WhenItemSulfuras_DoesNotUpdate()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].SellIn.Should().Be(10);
        items[0].Quality.Should().Be(10);
    }

    [Test]
    public void AgedBrie_QualityIncrease() 
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 40 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(41);
    }

    [TestCase("Aged Brie")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert")]
    public void AgedBrie_QualityDoesntExceed50(string itemName)
    {
        var items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = 50 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(50);
    }

    [TestCase(10, 10, 12)]
    [TestCase(8, 8, 10)]
    public void BackstagePasses_QualityIncreaseBy2WhenSellinLTE10Days(int sellIn, int initialQuality, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = initialQuality} };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [TestCase(5, 12, 15)]
    [TestCase(2, 9, 12)]
    public void BackstagePasses_QualityIncreaseBy3WhenSellinLTE5Days(int sellIn, int initialQuality, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = initialQuality } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Test]
    public void BackstagePasses_WhenSellin0QualityGoesToZero()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(0);
    }

    [TestCase(10, 50, 48)]
    [TestCase(0, 50, 46)]
    public void Conjured_QualityDecreasesTwiceAsFast(int sellIn, int initialQuality, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Conjured", SellIn = sellIn, Quality = initialQuality } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);

    }
}