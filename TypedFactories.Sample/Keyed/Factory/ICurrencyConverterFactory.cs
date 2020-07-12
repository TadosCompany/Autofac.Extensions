namespace TypedFactories.Sample.Keyed.Factory
{
    using Currencies;
    using CurrencyConverters;

    public interface ICurrencyConverterFactory
    {
        ICurrencyConverter Create(Currency fromCurrency, Currency toCurrency);
    }
}
