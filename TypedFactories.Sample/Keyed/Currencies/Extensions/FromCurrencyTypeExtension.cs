namespace TypedFactories.Sample.Keyed.Currencies.Extensions
{
    using System;
    using System.Reflection;

    public static class FromCurrencyTypeExtension
    {
        public static Currency FromCurrency(this Type type)
        {
            var attribute = type.GetCustomAttribute<FromCurrencyAttribute>();

            if (attribute == null)
                throw new Exception("Type has no FromCurrencyAttribute attribute");

            return attribute.FromCurrency;
        }
    }
}
