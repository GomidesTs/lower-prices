namespace lower_prices
{
    public class Date
    {
        public Boolean isWeekend(DateTime date)
        {
            Boolean weekend = false;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                weekend = true;
            }
            return weekend;
        }
    }
}