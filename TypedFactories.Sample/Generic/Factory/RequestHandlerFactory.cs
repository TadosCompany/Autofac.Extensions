namespace TypedFactories.Sample.Generic.Factory
{
    using System;
    using Autofac;
    using RequestHandlers;
    using Requests;

    public class RequestHandlerFactory : IRequestHandlerFactory
    {
        private readonly IComponentContext _componentContext;



        public RequestHandlerFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext ?? throw new ArgumentNullException(nameof(componentContext));
        }



        public IRequestHandler<TRequest> CreateFor<TRequest>()
            where TRequest : IRequest
        {
            return _componentContext.Resolve<IRequestHandler<TRequest>>();
        }
    }
}
