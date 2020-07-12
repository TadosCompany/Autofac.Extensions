namespace TypedFactories.Sample.Keyed.Factory
{
    using System;
    using Autofac;
    using Currencies;
    using CurrencyConverters;

    public class CurrencyConverterFactory : ICurrencyConverterFactory
    {
        private readonly IComponentContext _componentContext;



        public CurrencyConverterFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext ?? throw new ArgumentNullException(nameof(componentContext));
        }



        public ICurrencyConverter Create(Currency fromCurrency, Currency toCurrency)
        {
            return _componentContext.ResolveKeyed<ICurrencyConverter>((fromCurrency, toCurrency));
        }
    }
}
