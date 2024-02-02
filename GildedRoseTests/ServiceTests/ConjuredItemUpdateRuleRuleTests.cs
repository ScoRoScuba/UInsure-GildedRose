using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Service.ItemUpdateRules;
using NUnit.Framework;

namespace GildedRoseTests.ServiceTests
{
    public class ConjuredItemUpdateRuleRuleTests
    {
        [Test]
        public void RuleNameIsConjured()
        {
            var sut = new ConjuredItemUpdateRule();
            sut.RuleName.Should().Be("Conjured");
        }

        [TestCase(10, 50, 48)]
        [TestCase(0, 50, 46)]
        public void QualityDecreasesTwiceAsFast(int sellIn, int initialQuality, int expectedQuality)
        {
            var item = new Item { Name = "Conjured", SellIn = sellIn, Quality = initialQuality };

            var sut = new ConjuredItemUpdateRule();

            sut.UpdateItem(item);

            item.Quality.Should().Be(expectedQuality);
        }
    }
}
