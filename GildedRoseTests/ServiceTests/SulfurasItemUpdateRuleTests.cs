using FluentAssertions;
using GildedRoseKata;
using NUnit.Framework;
using GildedRoseKata.Service.ItemUpdateRules;

namespace GildedRoseTests.ServiceTests
{
    public class SulfurasItemUpdateRuleTests
    {
        [Test]
        public void RuleNameIsAgedBrie()
        {
            var sut = new SulfurasItemUpdateRule();
            sut.RuleName.Should().Be("Sulfuras, Hand of Ragnaros");
        }

        [Test]
        public void QualityDoesntChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 40 };

            var sut = new SulfurasItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(40);
        }

        [Test]
        public void SellInyDoesntChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 50 };

            var sut = new SulfurasItemUpdateRule();

            sut.UpdateItem(item);

            item.SellIn.Should().Be(10);
        }

    }
}
