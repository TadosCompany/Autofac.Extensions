namespace Registration.OpenGenericTypes.Sample
{
    using System.Reflection;
    using Autofac;
    using Entities;
    using Services.Abstractions;
    using Services.Printer;
    using Services.Saver;
    using Services.Validator;

    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();

            #region Простыня

            //containerBuilder
            //    .RegisterType<Printer<Client>>()
            //    .As<IPrinter<Client>>()
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<Printer<Contact>>()
            //    .As<IPrinter<Contact>>()
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<Printer<User>>()
            //    .As<IPrinter<User>>()
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<Saver<Client>>()
            //    .As<ISaver<Client>>()
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<Saver<Contact>>()
            //    .As<ISaver<Contact>>()
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<Saver<User>>()
            //    .As<ISaver<User>>()
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<Validator<Client>>()
            //    .As<IValidator<Client>>()
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<Validator<Contact>>()
            //    .As<IValidator<Contact>>()
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<Validator<User>>()
            //    .As<IValidator<User>>()
            //    .InstancePerDependency();

            #endregion

            #region Нативный способ

            //containerBuilder
            //    .RegisterGeneric(typeof(Printer<>))
            //    .As(typeof(IPrinter<>))
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterGeneric(typeof(Saver<>))
            //    .As(typeof(ISaver<>))
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterGeneric(typeof(Validator<>))
            //    .As(typeof(IValidator<>))
            //    .InstancePerDependency();

            #endregion

            #region Наш вариант

            containerBuilder
                .RegisterAssemblyOpenGenericTypes(Assembly.GetCallingAssembly())
                .AssignableTo<IEntityService>()
                .AsImplementedGenericInterfaces()
                .InstancePerDependency();

            #endregion



            using IContainer container = containerBuilder.Build();



            container.Resolve<IPrinter<Client>>().Print(new Client());
            container.Resolve<ISaver<Client>>().Save(new Client());
            container.Resolve<IValidator<Client>>().Validate(new Client());

            container.Resolve<IPrinter<Contact>>().Print(new Contact());
            container.Resolve<ISaver<Contact>>().Save(new Contact());
            container.Resolve<IValidator<Contact>>().Validate(new Contact());

            container.Resolve<IPrinter<User>>().Print(new User());
            container.Resolve<ISaver<User>>().Save(new User());
            container.Resolve<IValidator<User>>().Validate(new User());
        }
    }
}
