namespace Registration.OpenGenericTypes
{
    using System;
    using System.Reflection;
    using Autofac;

    public static class ScanningOpenGenericTypesRegistrationExtensions
    {
        public static ScanningOpenGenericTypesRegistrationBuilder RegisterAssemblyOpenGenericTypes(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return new ScanningOpenGenericTypesRegistrationBuilder(builder, assemblies);
        }
    }
}
