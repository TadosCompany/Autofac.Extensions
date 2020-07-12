namespace TypedFactories.Sample.Runtime.HierarchicRequestHandlers
{
    using HierarchicRequests;

    public interface IHierarchicRequestHandler<in THierarchicRequest, THierarchicResponse> : IWeaklyTypedHierarchicRequestHandler<THierarchicResponse>
        where THierarchicRequest : IHierarchicRequest<THierarchicResponse>
        where THierarchicResponse : IHierarchicResponse
    {
    }
}
