namespace TypedFactories.Sample.Runtime.Factory
{
    using System;
    using Autofac;
    using HierarchicRequestHandlers;
    using HierarchicRequests;

    public class WeaklyTypedHierarchicRequestHandlerFactory : IWeaklyTypedHierarchicRequestHandlerFactory
    {
        private readonly IComponentContext _componentContext;



        public WeaklyTypedHierarchicRequestHandlerFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext ?? throw new ArgumentNullException(nameof(componentContext));
        }



        public IWeaklyTypedHierarchicRequestHandler<THierarchicResponse> CreateFor<THierarchicRequest, THierarchicResponse>(THierarchicRequest request) 
            where THierarchicRequest : IHierarchicRequest<THierarchicResponse> 
            where THierarchicResponse : IHierarchicResponse
        {
            Type hierarchicRequestHandlerType = typeof(IHierarchicRequestHandler<,>).MakeGenericType(request.GetType(), typeof(THierarchicResponse));
            
            return (IWeaklyTypedHierarchicRequestHandler<THierarchicResponse>)_componentContext.Resolve(hierarchicRequestHandlerType);
        }
    }
}
