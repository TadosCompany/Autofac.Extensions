namespace TypedFactories.Sample
{
    using System;
    using System.Reflection;
    using Autofac;
    using Generic.Factory;
    using Generic.RequestHandlers;
    using Generic.Requests;
    using Keyed.Currencies;
    using Keyed.Currencies.Extensions;
    using Keyed.CurrencyConverters;
    using Keyed.Factory;
    using Runtime.Factory;
    using Runtime.HierarchicRequestHandlers;
    using Runtime.HierarchicRequests;
    using TypedFactories.Keyed;

    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();

            #region Generic

            //containerBuilder
            //    .RegisterAssemblyTypes(Assembly.GetCallingAssembly())
            //    .AsClosedTypesOf(typeof(IRequestHandler<>))
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<RequestHandlerFactory>()
            //    .As<IRequestHandlerFactory>()
            //    .InstancePerLifetimeScope();

            containerBuilder
                .RegisterAssemblyTypes(Assembly.GetCallingAssembly())
                .AsClosedTypesOf(typeof(IRequestHandler<>))
                .InstancePerDependency();

            containerBuilder
                .RegisterGenericTypedFactory<IRequestHandlerFactory>()
                .InstancePerLifetimeScope();

            #endregion

            #region Keyed

            //containerBuilder
            //    .RegisterAssemblyTypes(Assembly.GetCallingAssembly())
            //    .AssignableTo<ICurrencyConverter>()
            //    .Keyed<ICurrencyConverter>(x => (x.FromCurrency(), x.ToCurrency()))
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<CurrencyConverterFactory>()
            //    .As<ICurrencyConverterFactory>()
            //    .InstancePerLifetimeScope();

            containerBuilder
                .RegisterAssemblyTypes(Assembly.GetCallingAssembly())
                .AssignableTo<ICurrencyConverter>()
                .Keyed<ICurrencyConverter>(x => x.FromCurrency(), x => x.ToCurrency())
                .InstancePerDependency();

            containerBuilder
                .RegisterKeyedTypedFactory<ICurrencyConverterFactory>()
                .InstancePerLifetimeScope();

            #endregion

            #region Runtime

            //containerBuilder
            //    .RegisterAssemblyTypes(Assembly.GetCallingAssembly())
            //    .AsClosedTypesOf(typeof(IHierarchicRequestHandler<,>))
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<WeaklyTypedHierarchicRequestHandlerFactory>()
            //    .As<IWeaklyTypedHierarchicRequestHandlerFactory>()
            //    .InstancePerLifetimeScope();

            containerBuilder
                .RegisterAssemblyTypes(Assembly.GetCallingAssembly())
                .AsClosedTypesOf(typeof(IHierarchicRequestHandler<,>))
                .InstancePerDependency();

            containerBuilder
                .RegisterRuntimeTypedFactory<IHierarchicRequestHandlerFactory>()
                .InstancePerLifetimeScope();

            #endregion



            using IContainer container = containerBuilder.Build();



            #region Generic

            var genericRequestHandlerFactory = container.Resolve<IRequestHandlerFactory>();

            genericRequestHandlerFactory.CreateFor<SaveRequest>().Handle(new SaveRequest());
            genericRequestHandlerFactory.CreateFor<UpdateRequest>().Handle(new UpdateRequest());

            #endregion

            #region Keyed

            //var keyedCurrencyConverterFactory = container.Resolve<ICurrencyConverterFactory>();

            //const decimal sum = 100;

            //decimal sumUsd = keyedCurrencyConverterFactory.Create(Currency.Rub, Currency.Usd).Convert(sum);
            //Console.WriteLine($"{sum} rub = {sumUsd} usd");

            //decimal sumEur = keyedCurrencyConverterFactory.Create(Currency.Usd, Currency.Eur).Convert(sum);
            //Console.WriteLine($"{sum} usd = {sumEur} eur");

            //decimal sumRub = keyedCurrencyConverterFactory.Create(Currency.Eur, Currency.Rub).Convert(sum);
            //Console.WriteLine($"{sum} eur = {sumRub} rub");

            #endregion

            #region Runtime

            ////var runtimeHierarchicRequestHandlerFactory = container.Resolve<IWeaklyTypedHierarchicRequestHandlerFactory>();
            //var runtimeHierarchicRequestHandlerFactory = container.Resolve<IHierarchicRequestHandlerFactory>();

            //CreateUserRequestBase request;
            //CreateUserResponse response;

            //request = new CreateManagerRequest();
            //response = runtimeHierarchicRequestHandlerFactory.CreateFor<CreateUserRequestBase, CreateUserResponse>(request).Handle(request);
            //Console.WriteLine($"Manager id = {response.Id}");

            //request = new CreateAdministratorRequest();
            //response = runtimeHierarchicRequestHandlerFactory.CreateFor<CreateUserRequestBase, CreateUserResponse>(request).Handle(request);
            //Console.WriteLine($"Administrator id = {response.Id}");

            #endregion
        }
    }
}
