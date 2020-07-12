namespace TypedFactories.Sample.Keyed.Currencies
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class FromCurrencyAttribute : Attribute
    {
        public FromCurrencyAttribute(Currency fromCurrency)
        {
            FromCurrency = fromCurrency;
        }



        public Currency FromCurrency { get; protected set; }
    }
}
