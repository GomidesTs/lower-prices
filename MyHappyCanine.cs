namespace lower_prices
{
    class MyHappyCanine : Petshop
    {
        public void components()
        {
            name = "Meu Canino Feliz";
            distance = 2;
            if (weekend == true)
            {
                priceSmall = 20 * 1.2;
                priceBig = 40 * 1.2;
            }
            else
            {
                priceSmall = 20;
                priceBig = 40;
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