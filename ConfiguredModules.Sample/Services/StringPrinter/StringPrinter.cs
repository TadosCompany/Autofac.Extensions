namespace ConfiguredModules.Sample.Services.StringPrinter
{
    using System;

    public class StringPrinter : IStringPrinter
    {
        public const string StringParameterName = "string";



        private readonly string _string;



        public StringPrinter(string @string)
        {
            _string = @string;
        }



        public void PrintString()
        {
            Console.WriteLine($"String: {_string}");
        }
    }
}
