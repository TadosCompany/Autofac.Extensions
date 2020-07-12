namespace TypedFactories.Sample.Runtime.HierarchicRequestHandlers
{
    using System;
    using HierarchicRequests;

    public class CreateManagerRequestHandler : HierarchicRequestHandlerBase<CreateManagerRequest, CreateUserResponse>
    {
        protected override CreateUserResponse Handle(CreateManagerRequest request)
        {
            Console.WriteLine("Manager created");

            return new CreateUserResponse
            {
                Id = new Random().Next()
            };
        }
    }
}
