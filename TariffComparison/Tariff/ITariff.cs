namespace TariffComparison.Tariff
{
    public interface ITariff
    {
        AnualCostModel CalculateAnnualCosts(double consumption);
    }
}
