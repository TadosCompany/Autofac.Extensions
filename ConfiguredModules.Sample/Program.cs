namespace ConfiguredModules.Sample
{
    using System.IO;
    using System.Reflection;
    using Autofac;
    using Microsoft.Extensions.Configuration;
    using Services.NumberPrinter;
    using Services.StringPrinter;

    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();



            var containerBuilder = new ContainerBuilder();

            #region Простыня

            //containerBuilder
            //    .RegisterType<NumberPrinter>()
            //    .As<INumberPrinter>()
            //    .WithParameter(NumberPrinter.NumberParameterName, configuration.GetValue<int>("Number"))
            //    .InstancePerDependency();

            //containerBuilder
            //    .RegisterType<StringPrinter>()
            //    .As<IStringPrinter>()
            //    .WithParameter(StringPrinter.StringParameterName, configuration.GetValue<string>("String"))
            //    .InstancePerDependency();


            // И еще миллион регистраций зависимостей

            #endregion

            #region Нативный способ

            //containerBuilder.RegisterAssemblyModules(Assembly.GetCallingAssembly());

            // Не позволяет прокинуть IConfiguration в Module
            // Регистрации конфигурируемых зависимостей придется оставлять здесь

            #endregion

            #region Наш вариант

            containerBuilder.RegisterConfiguredModulesFromCurrentAssembly(configuration);

            #endregion



            using IContainer container = containerBuilder.Build();



            var numberPrinter = container.Resolve<INumberPrinter>();

            numberPrinter.PrintNumber();



            var stringPrinter = container.Resolve<IStringPrinter>();

            stringPrinter.PrintString();
        }
    }
}
