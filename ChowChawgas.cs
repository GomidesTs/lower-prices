namespace lower_prices
{
    class ChowChawgas : Petshop
    {
        public void components()
        {
            name = "ChowChawgas";
            distance = 0.800;
            priceSmall = 30;
            priceBig = 45;
        }
        public string? GetName()
        {
            return name;
        }
        public double GetDistance()
        {
            return distance;
        }
    }
}