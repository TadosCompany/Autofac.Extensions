namespace TypedFactories.Sample.Generic.RequestHandlers
{
    using System;
    using Requests;

    public class SaveRequestHandler : IRequestHandler<SaveRequest>
    {
        public void Handle(SaveRequest request)
        {
            Console.WriteLine($"{request.GetType().Name} handled");
        }
    }
}
