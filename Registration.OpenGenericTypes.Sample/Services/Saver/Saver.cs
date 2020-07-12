namespace Registration.OpenGenericTypes.Sample.Services.Saver
{
    using System;
    using Entities.Abstractions;

    public class Saver<TEntity> : ISaver<TEntity>
        where TEntity: IEntity
    {
        public void Save(TEntity entity)
        {
            Console.WriteLine($"{entity.GetType().Name} saved");
        }
    }
}
