namespace Registration.OpenGenericTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Autofac.Builder;

    public static class OpenGenericTypesRegistrationBuilderExtensions
    {
        public static IRegistrationBuilder<TLimit, ReflectionActivatorData, DynamicRegistrationStyle> AsImplementedGenericInterfaces<TLimit>(
            this IRegistrationBuilder<TLimit, ReflectionActivatorData, DynamicRegistrationStyle> registration)
        {
            if (registration == null)
                throw new ArgumentNullException(nameof(registration));

            Type implementationType = registration.ActivatorData.ImplementationType;

            if (!implementationType.ContainsGenericParameters)
                throw new InvalidOperationException("Generic implementation type expected");

            IEnumerable<Type> implementedGenericInterfaces = implementationType.GetTypeInfo().ImplementedInterfaces
                .Where(implementedInterface => implementedInterface.ContainsGenericParameters);

            return registration.As(implementedGenericInterfaces.ToArray());
        }
    }
}
