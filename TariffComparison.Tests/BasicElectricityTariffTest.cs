using TariffComparison.Tariff;
using Xunit;

namespace TariffComparison.Tests
{
    public class BasicElectricityTariffTests
    {
        [Theory]
        [InlineData(3500, 830, "Annual costs = 830 €/year (5€ * 12 months = 60 € base costs + 3500 kWh/year * 22 cent/kWh = 770€ consumption costs)")]
        [InlineData(4500, 1050, "Annual costs = 1050 €/year (5€ * 12 months = 60 € base costs + 4500 kWh/year * 22 cent/kWh = 990€ consumption costs)")]
        [InlineData(6000, 1380, "Annual costs = 1380 €/year (5€ * 12 months = 60 € base costs + 6000 kWh/year * 22 cent/kWh = 1320€ consumption costs)")]
        public void CalculateAnnualCosts_ShouldReturnCorrectCosts(double consumption, double expectedCosts, string expectedDescription)
        {
            var basicTariff = new BasicElectricityTariff();

            var tariff = basicTariff.CalculateAnnualCosts(consumption);

            Assert.Equal(expectedCosts, tariff.Cost, 2);
        }

        [Fact]
        public void CalculateAnnualCosts_ShouldThrowException_WhenNegativeConsumption()
        {
            var basicTariff = new BasicElectricityTariff();

            Assert.Throws<ArgumentException>(() => basicTariff.CalculateAnnualCosts(-100));
        }
    }
}
