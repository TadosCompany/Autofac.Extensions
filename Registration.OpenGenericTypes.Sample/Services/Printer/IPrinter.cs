namespace Registration.OpenGenericTypes.Sample.Services.Printer
{
    using Abstractions;
    using Entities.Abstractions;

    public interface IPrinter<in TEntity> : IEntityService
        where TEntity: IEntity
    {
        void Print(TEntity entity);
    }
}
