namespace Registration.OpenGenericTypes.Sample.Services.Printer
{
    using System;
    using Entities.Abstractions;

    public class Printer<TEntity> : IPrinter<TEntity>
        where TEntity: IEntity
    {
        public void Print(TEntity entity)
        {
            Console.WriteLine($"{entity.GetType().Name} printed");
        }
    }
}
