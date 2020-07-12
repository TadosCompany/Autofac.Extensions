namespace TypedFactories.Sample.Keyed.CurrencyConverters
{
    using Currencies;

    [FromCurrency(Currency.Rub)]
    [ToCurrency(Currency.Usd)]
    public class RubToUsdConverter : ICurrencyConverter
    {
        public decimal Convert(decimal sum) => sum * 0.014m;
    }
}
