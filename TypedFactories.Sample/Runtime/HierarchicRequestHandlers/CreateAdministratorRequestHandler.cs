namespace TypedFactories.Sample.Runtime.HierarchicRequestHandlers
{
    using System;
    using HierarchicRequests;

    public class CreateAdministratorRequestHandler : HierarchicRequestHandlerBase<CreateAdministratorRequest, CreateUserResponse>
    {
        protected override CreateUserResponse Handle(CreateAdministratorRequest request)
        {
            Console.WriteLine("Administrator created");

            return new CreateUserResponse
            {
                Id = new Random().Next()
            };
        }
    }
}
