using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Service;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests.ServiceTests
{
    public class BackstagePassItemUpdateRuleTests
    {
        [Test]
        public void RuleNameIsBackstagePass()
        {
            var sut = new BackstagePassItemUpdateRule();
            sut.RuleName.Should().Be("Backstage passes to a TAFKAL80ETC concert");
        }

        [Test]
        public void QualityDoesntExceed50()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 };

            var sut = new BackstagePassItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(50);
        }

        [TestCase(10, 10, 12)]
        [TestCase(8, 8, 10)]
        public void QualityIncreaseBy2WhenSellinLTE10Days(int sellIn, int initialQuality, int expectedQuality)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = initialQuality };

            var sut = new BackstagePassItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(expectedQuality);
        }

        [TestCase(5, 12, 15)]
        [TestCase(2, 9, 12)]
        public void QualityIncreaseBy3WhenSellinLTE5Days(int sellIn, int initialQuality, int expectedQuality)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = initialQuality };
            var sut = new BackstagePassItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(expectedQuality);
        }

        [Test]
        public void WhenSellin0QualityGoesToZero()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            items[0].Quality.Should().Be(0);
        }

    }
}
