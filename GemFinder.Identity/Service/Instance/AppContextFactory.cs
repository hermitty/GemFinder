using GemFinder.Identity.Service.Context;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GemFinder.Identity.Service.Instance
{
    internal sealed class AppContextFactory : IAppContextFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IAppContext Create()
        {
            var context = _httpContextAccessor.GetCorrelationContext();

            return context is null ? AppContext.Empty : new AppContext(context);
        }
    }
}