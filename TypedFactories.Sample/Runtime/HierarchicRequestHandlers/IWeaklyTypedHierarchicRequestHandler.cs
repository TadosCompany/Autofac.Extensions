namespace TypedFactories.Sample.Runtime.HierarchicRequestHandlers
{
    using HierarchicRequests;

    public interface IWeaklyTypedHierarchicRequestHandler<THierarchicResponse>
        where THierarchicResponse : IHierarchicResponse
    {
        THierarchicResponse Handle(IHierarchicRequest<THierarchicResponse> request);
    }
}
