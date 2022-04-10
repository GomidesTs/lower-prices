namespace lower_prices
{
    public class LowerPriceException : ApplicationException
    {
        public LowerPriceException(string mensagem) : base(mensagem)
        {
        }
    }
}