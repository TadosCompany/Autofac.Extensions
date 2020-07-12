namespace Registration.OpenGenericTypes.Sample.Services.Validator
{
    using System;
    using Entities.Abstractions;

    public class Validator<TEntity> : IValidator<TEntity>
        where TEntity: IEntity
    {
        public void Validate(TEntity entity)
        {
            Console.WriteLine($"{entity.GetType().Name} validated");
        }
    }
}
