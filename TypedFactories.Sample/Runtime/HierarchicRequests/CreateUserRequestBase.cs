namespace TypedFactories.Sample.Runtime.HierarchicRequests
{
    public class CreateUserRequestBase : IHierarchicRequest<CreateUserResponse>
    {
        public string Email { get; set; }
    }
}
