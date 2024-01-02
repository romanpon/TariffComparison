namespace TariffComparison.Tariff
{
    public class AnualCostModel
    {
        public string Name { get; }
        public double Cost { get; }
        public string Desription { get; }

        public AnualCostModel(string name, double cost, string desription)
        {
            Name = name;
            Cost = cost;
            Desription = desription;
        }
    }
}
