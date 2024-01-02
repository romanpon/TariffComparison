namespace TariffComparison.Tariff
{
    public class BasicElectricityTariff : ITariff
    {
        private readonly string name = "Basic electricity tariff";

        public AnualCostModel CalculateAnnualCosts(double consumption)
        {
            if (consumption < 0)
                throw new ArgumentException("Cannot be negative", nameof(consumption));

            double baseCosts = 5 * 12;
            double consumptionCosts = consumption * 0.22;
            var totalCost = baseCosts + consumptionCosts;

            var desription = $"Annual costs = {totalCost} €/year (5€ * 12 months = 60 € base costs + {consumption} kWh/year * 22 cent/kWh = {consumptionCosts}€ consumption costs)";

            return new AnualCostModel(name, totalCost, desription);
        }
    }
}
