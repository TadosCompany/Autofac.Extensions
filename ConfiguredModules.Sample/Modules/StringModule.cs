namespace ConfiguredModules.Sample.Modules
{
    using Autofac;
    using Microsoft.Extensions.Configuration;
    using Services.StringPrinter;

    public class StringModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StringPrinter>()
                .As<IStringPrinter>()
                .WithParameter(StringPrinter.StringParameterName, Configuration.GetValue<string>("String"))
                .InstancePerDependency();
        }
    }
}
