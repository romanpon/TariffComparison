namespace TariffComparison.Tariff
{
    public class PackagedTariff : ITariff
    {
        private readonly string name = "Packaged tariff";

        public AnualCostModel CalculateAnnualCosts(double consumption)
        {
            if (consumption < 0)
                throw new ArgumentException("Cannot be negative", nameof(consumption));

            var baseCost = 800d;
            if (consumption <= 4000)
            {
                var description = "Annual costs = 800 €/year";
                return new AnualCostModel(name, baseCost, description);
            }
            else
            {
                var additionalConsuption = consumption - 4000;
                var additionalConsumptionCosts = additionalConsuption * 0.30;
                var totalCost = baseCost + additionalConsumptionCosts;
                var description = $"Annual costs = {totalCost}€/year ({baseCost}€ + {additionalConsuption} kWh * 30 cent/kWh {additionalConsumptionCosts}€ additional consumption costs) ";
                return new AnualCostModel(name, totalCost, description);
            }
        }
    }
}
