namespace TypedFactories.Sample.Generic.RequestHandlers
{
    using Requests;

    public interface IRequestHandler<in TRequest>
        where TRequest : IRequest
    {
        void Handle(TRequest request);
    }
}
