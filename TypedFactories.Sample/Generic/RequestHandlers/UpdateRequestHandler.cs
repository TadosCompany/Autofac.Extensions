namespace TypedFactories.Sample.Generic.RequestHandlers
{
    using System;
    using Requests;

    public class UpdateRequestHandler : IRequestHandler<UpdateRequest>
    {
        public void Handle(UpdateRequest request)
        {
            Console.WriteLine($"{request.GetType().Name} handled");
        }
    }
}
