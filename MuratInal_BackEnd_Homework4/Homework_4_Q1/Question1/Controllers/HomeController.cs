using Microsoft.AspNetCore.Mvc;
using SingletonTransientScoped.Services.Interface;
using System;

namespace SingletonTransientScoped.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;

        public HomeController(IScopedService scopedService1, IScopedService scopedService2,
                              ISingletonService singletonService1, ISingletonService singletonService2,
                              ITransientService transientService1, ITransientService transientService2)
        {
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
        }

        [HttpGet]
        public string GetNumbers()
        {
            string result = $"Scoped Service 1 Worked : {_scopedService1.RandomValue} {Environment.NewLine}" +
                            $"Scoped Service 2 Worked : {_scopedService2.RandomValue} {Environment.NewLine}" +
                            $"Singleton Service 1 Worked : {_singletonService1.RandomValue} {Environment.NewLine}" +
                            $"Singleton Service 2 Worked : {_singletonService2.RandomValue} {Environment.NewLine}" +
                            $"Transient Service 1 Worked : {_transientService1.RandomValue} {Environment.NewLine}" +
                            $"Transient Service 2 Worked : {_transientService2.RandomValue} {Environment.NewLine}";

            return result;
        }
    }
}
