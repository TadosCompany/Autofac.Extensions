namespace TypedFactories.Sample.Keyed.Currencies.Extensions
{
    using System;
    using System.Reflection;

    public static class ToCurrencyTypeExtension
    {
        public static Currency ToCurrency(this Type type)
        {
            var attribute = type.GetCustomAttribute<ToCurrencyAttribute>();

            if (attribute == null)
                throw new Exception("Type has no ToCurrencyAttribute attribute");

            return attribute.ToCurrency;
        }
    }
}
