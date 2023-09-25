using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests;

public class GildedRoseTest
{    
    [Fact]
    public void UpdateQuality_ShouldReduceItemQualityByOne_WhenItemNameIsNotAgedBrieOrTAFKAL80ETC_OrSulfurasAndQualityIsAboveZero()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 1 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();


        // Assert
        Assert.All(app.Items, item => Assert.Equal(0, item.Quality));
    }

    [Fact]
    public void UpdateQuality_ShouldNotReduceItemQualityByOne_WhenItemNameIsSulfurasAndQualityIsAboveZero()
    {
        // Arrange
        string sulfuras = "Sulfuras, Hand of Ragnaros";
        IList<Item> items = new List<Item> { new Item { Name = sulfuras, SellIn = 0, Quality = 1 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();


        // Assert
        Assert.All(app.Items, item => Assert.Equal(1, item.Quality));
    }

    [Theory]
    [InlineData("Aged Brie")]
    [InlineData("Backstage passes to a TAFKAL80ETC concert")]
    public void UpdateQuality_ShouldNotChangeQuality_WhenItemHasSacredNameAndQualityIsGreaterThan50(string sacredName)
    {
        IList<Item> items = new List<Item> { new Item { Name = sacredName, SellIn = 0, Quality = 51 } };

        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.All(app.Items, item => Assert.Equal(51, item.Quality));

    }

    // Item is not Sulfuras
    [Fact]
    public void UpdateQuality_ShouldDecreaseSellinByOne_WhenItemHasNameSulfuras()
    { }
    // Item SellIn < 0
    // Item is not Aged Brie && Quality < 50
    [Fact]
    public void UpdateQuality_ShouldIncreaseQualityByOne_WhenItemHasSellinGreaterThanZeroAndNotNameAgedBreeAndQualityLessThan50()
    {

    }

    // Item is Backstage pass
    [Fact]
    public void UpdateQuality_ShouldMakeQualityZero_WhenItemSellInIsGreaterThanZeroNotNamedBackStagepass()
    {

    }

    [Fact]
    public void UpdateQuality_ShouldDecreaseQualityByOne_WhenItemSellInIsGreaterThanZeroNotNamedBackStagepassAndHasQualityGreaterThanZeroAndIsNotNamedSulfuras()
    { 

    }


    // Item is not Backstage pass
    [Fact]
    public void UpdateQuality_ShouldBecomeZero_WhenItemSellInIsGreaterThanZeroNotNamedAgedBreeOrBackStagepass()
    {

    }
}