namespace Registration.OpenGenericTypes.Sample.Services.Validator
{
    using Abstractions;
    using Entities.Abstractions;

    public interface IValidator<in TEntity> : IEntityService
        where TEntity: IEntity
    {
        void Validate(TEntity entity);
    }
}
