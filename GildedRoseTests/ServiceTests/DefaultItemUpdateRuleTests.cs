using FluentAssertions;
using GildedRoseKata;
using NUnit.Framework;
using GildedRoseKata.Service.ItemUpdateRules;

namespace GildedRoseTests.ServiceTests
{
    public class DefaultItemUpdateRuleTests
    {
        [Test]
        public void RuleNameIsDefault()
        {
            var sut = new DefaultItemUpdateRule();
            sut.RuleName.Should().Be("Default");
        }

        [TestCase("foo", 0, -1)]
        [TestCase("foo1", 2, 1)]
        public void SellInShouldDecrease(string itemName, int initialSellin, int expectedSellIn)
        {
            var item = new Item { Name = itemName, SellIn = initialSellin, Quality = 0 };

            var sut = new DefaultItemUpdateRule();

            sut.UpdateItem(item);

            item.SellIn.Should().Be(expectedSellIn);
        }

        [Test]
        public void WhenZeroQuality_QualityuDoesNotChange()
        {
            var item = new Item { Name = "foo", SellIn = 0, Quality = 0 };
            var sut = new DefaultItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(0);
        }

        [TestCase("foo", 1, 0)]
        [TestCase("foo1", 2, 1)]
        public void WHenItemSellInDateValid_QualityShouldDecrease(string itemName, int initialQuality, int expectedQuality)
        {
            var item = new Item { Name = itemName, SellIn = 2, Quality = initialQuality };
            var sut = new DefaultItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(expectedQuality);
        }

        [TestCase("foo", 4, 2)]
        [TestCase("foo1", 2, 0)]
        public void WHenItemSellInDatePassed_QualityShouldDecreaseTwiceAsFast(string itemName, int initialQuality, int expectedQuality)
        {
            var item = new Item { Name = itemName, SellIn = 0, Quality = initialQuality };
            var sut = new DefaultItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(expectedQuality);
        }

        [Test]
        public void WHenItemSellInDatePassed_QualityDoesntGoNegative()
        {
            var item = new Item { Name = "foo", SellIn = 0, Quality = 1 };
            var sut = new DefaultItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(0);
        }
    }
}
