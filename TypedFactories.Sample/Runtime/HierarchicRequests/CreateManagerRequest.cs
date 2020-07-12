namespace TypedFactories.Sample.Runtime.HierarchicRequests
{
    public class CreateManagerRequest : CreateUserRequestBase
    {
        public string Department { get; set; }
    }
}
