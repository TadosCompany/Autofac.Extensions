namespace ConfiguredModules.Sample.Modules
{
    using System;
    using Autofac;
    using Microsoft.Extensions.Configuration;
    using Services.NumberPrinter;

    public class NumberModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<NumberPrinter>()
                .As<INumberPrinter>()
                .WithParameter(NumberPrinter.NumberParameterName, Configuration.GetValue<int>("Number"))
                .InstancePerDependency();
        }
    }
}
