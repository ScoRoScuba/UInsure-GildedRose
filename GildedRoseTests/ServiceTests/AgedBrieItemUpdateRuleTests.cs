using FluentAssertions;
using GildedRoseKata;
using NUnit.Framework;
using GildedRoseKata.Service.ItemUpdateRules;

namespace GildedRoseTests.ServiceTests
{
    public class AgedBrieItemUpdateRuleTests
    {
        [Test]
        public void QualityRule_RuleNameIsAgedBrie()
        {
            var sut = new AgedBrieItemUpdateRule();
            sut.RuleName.Should().Be("Aged Brie");
        }

        [Test]
        public void QualityRule_QualityIncrease()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 40 };

            var sut = new AgedBrieItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(41);
        }

        [Test]
        public void AgedBrie_QualityDoesntExceed50()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 };

            var sut = new AgedBrieItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(50);
        }

    }
}
