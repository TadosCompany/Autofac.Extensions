namespace ConfiguredModules.Sample.Services.NumberPrinter
{
    using System;

    public class NumberPrinter : INumberPrinter
    {
        public const string NumberParameterName = "number";



        private readonly int _number;



        public NumberPrinter(int number)
        {
            _number = number;
        }



        public void PrintNumber()
        {
            Console.WriteLine($"Number: {_number}");
        }
    }
}
