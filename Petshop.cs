namespace lower_prices
{
    abstract class Petshop
    {
        protected string? name;
        public int quantidadeSmall;
        protected double distance;
        public int quantidadeBig;
        protected double priceSmall;
        protected double priceBig;
        public Boolean weekend;
        private double priceFinal;
        public double pricePetshop()
        {
            this.priceFinal = ((this.priceSmall * this.quantidadeSmall) + (this.priceBig * this.quantidadeBig));
            return priceFinal;
        }
    }
}