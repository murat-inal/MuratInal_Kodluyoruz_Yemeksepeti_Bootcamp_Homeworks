using SingletonTransientScoped.Services.Interface;
using System;

namespace SingletonTransientScoped.Services
{
    public class SampleService : ISingletonService, IScopedService, ITransientService
    {
        public int RandomValue { get; }

        public SampleService()
        {
            RandomValue = new Random().Next(1000000, 10000000);
        }
    }
}
