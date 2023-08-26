using DynamicServiceRegistration.Services;

using Microsoft.AspNetCore.Mvc;

namespace DynamicServiceRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ServicesController : ControllerBase
    {
        [HttpGet(Name = "ScopedServiceA")]
        public string ScopedServiceA([FromServices] IScopedServiceA scopedServiceA)
        {
            return scopedServiceA.GetServiceName();
        }

        [HttpGet(Name = "ScopedServiceB")]
        public string ScopedServiceB([FromServices] IScopedServiceB scopedServiceB)
        {
            return scopedServiceB.GetServiceName();
        }

        [HttpGet(Name = "ScopedServiceNoInterface")]
        public string ScopedServiceStandalone([FromServices] ScopedServiceNoInterface scopedServiceStandalone)
        {
            return scopedServiceStandalone.GetServiceName();
        }

        
        [HttpGet(Name = "TransientServiceA")]
        public string TransientServiceA([FromServices] ITransientServiceA transientServiceA)
        {
            return transientServiceA.GetServiceName();
        }

        [HttpGet(Name = "SingletonServiceA")]
        public string SingletonServiceA([FromServices] ISingleTonServiceA singleTonServiceA)
        {
            return singleTonServiceA.GetServiceName();
        }
    }
}