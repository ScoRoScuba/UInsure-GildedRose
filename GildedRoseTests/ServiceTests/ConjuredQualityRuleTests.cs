using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Service;
using NUnit.Framework;

namespace GildedRoseTests.ServiceTests
{
    public class ConjuredQualityRuleTests
    {
        [Test]
        public void ConjuredQualityRule_RuleNameIsConjured()
        {
            var sut = new ConjuredQualityRule();
            sut.RuleName.Should().Be("Conjured");
        }

        [TestCase(10, 50, 48)]
        [TestCase(0, 50, 46)]
        public void ConjuredQualityRule_QualityDecreasesTwiceAsFast(int sellIn, int initialQuality, int expectedQuality)
        {
            var item = new Item { Name = "Conjured", SellIn = sellIn, Quality = initialQuality };

            var sut = new ConjuredQualityRule();

            sut.Update(item);

            item.Quality.Should().Be(expectedQuality);
        }
    }
}
