using TariffComparison.Tariff;
using Xunit;

namespace TariffComparison.Tests
{
    public class PackagedTariffTest
    {
        [Theory]
        [InlineData(3500, 800, "Annual costs = 800 €/year")]
        [InlineData(4500, 950, "Annual costs = 950€/year (800€ + 500 kWh * 30 cent/kWh 150€ additional consumption costs)")]
        [InlineData(6000, 1400, "Annual costs = 1400€/year (800€ + 2000 kWh * 30 cent/kWh 600€ additional consumption costs)")]
        public void CalculateAnnualCosts_ShouldReturnCorrectCosts(double consumption, double expectedCosts, string expectedDescription)
        {
            var packagedTariff = new PackagedTariff();

            var tariff = packagedTariff.CalculateAnnualCosts(consumption);

            Assert.Equal(expectedCosts, tariff.Cost, 2);
        }

        [Fact]
        public void CalculateAnnualCosts_ShouldThrowException_WhenNegativeConsumption()
        {
            var packagedTariff = new PackagedTariff();

            Assert.Throws<ArgumentException>(() => packagedTariff.CalculateAnnualCosts(-100));
        }
    }
}
