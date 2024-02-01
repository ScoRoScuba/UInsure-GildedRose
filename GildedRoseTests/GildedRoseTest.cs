using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;
using FluentAssertions;
namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Item_SellInShouldDecrease()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Name.Should().Be("foo");
        items[0].SellIn.Should().Be(-1);
    }


}