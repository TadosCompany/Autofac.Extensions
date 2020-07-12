namespace TypedFactories.Sample.Runtime.HierarchicRequests
{
    public interface IHierarchicRequest<out THierarchicResponse>
        where THierarchicResponse : IHierarchicResponse
    {
    }
}
