namespace TypedFactories.Sample.Keyed.CurrencyConverters
{
    using Currencies;

    [FromCurrency(Currency.Eur)]
    [ToCurrency(Currency.Rub)]
    public class EurToRubConverter : ICurrencyConverter
    {
        public decimal Convert(decimal sum) => sum * 79.900m;
    }
}
