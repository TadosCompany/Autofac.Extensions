namespace TypedFactories.Sample.Generic.Factory
{
    using RequestHandlers;
    using Requests;

    public interface IRequestHandlerFactory
    {
        IRequestHandler<TRequest> CreateFor<TRequest>()
            where TRequest : IRequest;
    }
}
