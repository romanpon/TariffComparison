namespace TariffComparison.Tariff
{
    internal class TariffComparisionHandler
    {
        private readonly List<ITariff> tariffs = [];

        public TariffComparisionHandler()
        {
            tariffs.Add(new BasicElectricityTariff());
            tariffs.Add(new PackagedTariff());
        }

        public IReadOnlyList<AnualCostModel> GetAnualCost(double consumption)
        {
            var result = new List<AnualCostModel>();
            foreach (var tariff in tariffs)
            {
                result.Add(tariff.CalculateAnnualCosts(consumption));
            }

            return result
                .OrderBy(x => x.Cost)
                .ToList()
                .AsReadOnly();
        }
    }
}
