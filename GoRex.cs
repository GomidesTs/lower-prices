namespace lower_prices
{
    class GoRex : Petshop
    {
        public void components()
        {
            name = "Vai Rex";
            distance = 1.7;
            if (weekend == true)
            {
                priceSmall = 20;
                priceBig = 55;
            }
            else
            {
                priceSmall = 15;
                priceBig = 50;
            }
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