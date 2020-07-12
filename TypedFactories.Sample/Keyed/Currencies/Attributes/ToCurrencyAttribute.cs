namespace TypedFactories.Sample.Keyed.Currencies
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class ToCurrencyAttribute : Attribute
    {
        public ToCurrencyAttribute(Currency toCurrency)
        {
            ToCurrency = toCurrency;
        }



        public Currency ToCurrency { get; protected set; }
    }
}
