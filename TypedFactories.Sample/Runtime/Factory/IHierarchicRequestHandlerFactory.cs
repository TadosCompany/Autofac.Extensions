namespace TypedFactories.Sample.Runtime.Factory
{
    using HierarchicRequestHandlers;
    using HierarchicRequests;

    public interface IHierarchicRequestHandlerFactory
    {
        IHierarchicRequestHandler<THierarchicRequest, THierarchicResponse> CreateFor<THierarchicRequest, THierarchicResponse>(THierarchicRequest request)
            where THierarchicRequest: IHierarchicRequest<THierarchicResponse>
            where THierarchicResponse : IHierarchicResponse;
    }
}
