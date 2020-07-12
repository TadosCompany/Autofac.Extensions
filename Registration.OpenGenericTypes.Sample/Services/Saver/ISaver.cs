namespace Registration.OpenGenericTypes.Sample.Services.Saver
{
    using Abstractions;
    using Entities.Abstractions;

    public interface ISaver<in TEntity> : IEntityService
        where TEntity: IEntity
    {
        void Save(TEntity entity);
    }
}
