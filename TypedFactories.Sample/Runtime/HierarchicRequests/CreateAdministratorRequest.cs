namespace TypedFactories.Sample.Runtime.HierarchicRequests
{
    public class CreateAdministratorRequest : CreateUserRequestBase
    {
        public string FullName { get; set; }

        public string Phone { get; set; }
    }
}
