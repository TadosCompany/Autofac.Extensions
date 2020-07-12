namespace Registration.OpenGenericTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using Autofac.Builder;
    using Tados.Common.TypeExtensions;

    public class ScanningOpenGenericTypesRegistrationBuilder
    {
        private readonly ContainerBuilder _builder;



        private IEnumerable<Type> _types;
        private IEnumerable<IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle>> _registrationBuilders;



        internal ScanningOpenGenericTypesRegistrationBuilder(ContainerBuilder builder, params Assembly[] assemblies)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));

            _types = assemblies
                .SelectMany(assembly => assembly.DefinedTypes)
                .Where(type => type.IsClass)
                .Where(type => type.IsGenericTypeDefinition);
        }



        public ScanningOpenGenericTypesRegistrationBuilder AssignableTo<TType>()
        {
            _types = _types.Where(AssignTypeExtensions.IsAssignableTo<TType>);

            return this;
        }

        public ScanningOpenGenericTypesRegistrationBuilder AssignableTo(Type assignableToType)
        {
            _types = _types.Where(type => type.IsAssignableTo(assignableToType));

            return this;
        }

        public ScanningOpenGenericTypesRegistrationBuilder ThatImplementsOpenGeneric(Type openGenericType)
        {
            if (!openGenericType.IsGenericTypeDefinition)
                throw new ArgumentException("Open generic type expected", nameof(openGenericType));

            _types = _types.Where(type => type.ImplementsOpenGeneric(openGenericType));

            return this;
        }

        public ScanningOpenGenericTypesRegistrationBuilder As(Type openGenericType)
        {
            if (openGenericType == null)
                throw new ArgumentNullException(nameof(openGenericType));

            if (!openGenericType.IsGenericTypeDefinition)
                throw new ArgumentException("Open generic type expected", nameof(openGenericType));

            ForEachRegistrationBuilder(registrationBuilder => registrationBuilder.As(openGenericType));

            return this;
        }

        public ScanningOpenGenericTypesRegistrationBuilder AsImplementedInterfaces()
        {
            ForEachRegistrationBuilder(registrationBuilder => registrationBuilder.AsImplementedInterfaces());

            return this;
        }

        public ScanningOpenGenericTypesRegistrationBuilder AsImplementedGenericInterfaces()
        {
            ForEachRegistrationBuilder(registrationBuilder => registrationBuilder.AsImplementedGenericInterfaces());

            return this;
        }

        public ScanningOpenGenericTypesRegistrationBuilder InstancePerDependency()
        {
            ForEachRegistrationBuilder(registrationBuilder => registrationBuilder.InstancePerDependency());

            return this;
        }

        public ScanningOpenGenericTypesRegistrationBuilder InstancePerLifetimeScope()
        {
            ForEachRegistrationBuilder(registrationBuilder => registrationBuilder.InstancePerLifetimeScope());

            return this;
        }

        public ScanningOpenGenericTypesRegistrationBuilder SingleInstance()
        {
            ForEachRegistrationBuilder(registrationBuilder => registrationBuilder.SingleInstance());

            return this;
        }


        
        private void ForEachRegistrationBuilder(Action<IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle>> action)
        {
            SafeCreateRegistrationBuilders();

            foreach (IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle> registrationBuilder in _registrationBuilders)
            {
                action(registrationBuilder);
            }
        }

        private void SafeCreateRegistrationBuilders()
        {
            if (_registrationBuilders is null)
            {
                _registrationBuilders = _types.Select(_builder.RegisterGeneric);
            }
        }
    }
}
