using FluentAssertions;
using GildedRoseKata;
using GildedRoseKata.Service;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests.ServiceTests
{
    public class AgedBrieQualityRuleTests
    {
        [Test]
        public void QualityRule_RuleNameIsAgedBrie()
        {
            var sut = new AgedBrieQualityRule();
            sut.RuleName.Should().Be("Aged Brie");
        }

        [Test]
        public void QualityRule_QualityIncrease()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 40 };

            var sut = new AgedBrieQualityRule();

            sut.Update(item);

            item.Quality.Should().Be(41);
        }

        [Test]
        public void AgedBrie_QualityDoesntExceed50()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 };

            var sut = new AgedBrieQualityRule();

            sut.Update(item);

            item.Quality.Should().Be(50);
        }

    }
}
