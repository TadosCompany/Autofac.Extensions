namespace TypedFactories.Sample.Runtime.Factory
{
    using HierarchicRequestHandlers;
    using HierarchicRequests;

    public interface IWeaklyTypedHierarchicRequestHandlerFactory
    {
        IWeaklyTypedHierarchicRequestHandler<THierarchicResponse> CreateFor<THierarchicRequest, THierarchicResponse>(THierarchicRequest request)
            where THierarchicRequest: IHierarchicRequest<THierarchicResponse>
            where THierarchicResponse : IHierarchicResponse;
    }
}
