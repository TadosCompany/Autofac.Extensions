namespace TypedFactories.Sample.Runtime.HierarchicRequestHandlers
{
    using HierarchicRequests;

    public abstract class HierarchicRequestHandlerBase<THierarchicRequest, THierarchicResponse> : IHierarchicRequestHandler<THierarchicRequest, THierarchicResponse>
        where THierarchicRequest : IHierarchicRequest<THierarchicResponse>
        where THierarchicResponse : IHierarchicResponse
    {
        protected abstract THierarchicResponse Handle(THierarchicRequest request);



        THierarchicResponse IWeaklyTypedHierarchicRequestHandler<THierarchicResponse>.Handle(IHierarchicRequest<THierarchicResponse> request)
        {
            return Handle((THierarchicRequest)request);
        }
    }
}
