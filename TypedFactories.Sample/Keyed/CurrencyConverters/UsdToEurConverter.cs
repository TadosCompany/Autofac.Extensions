namespace TypedFactories.Sample.Keyed.CurrencyConverters
{
    using Currencies;

    [FromCurrency(Currency.Usd)]
    [ToCurrency(Currency.Eur)]
    public class UsdToEurConverter : ICurrencyConverter
    {
        public decimal Convert(decimal sum) => sum * 0.890m;
    }
}
