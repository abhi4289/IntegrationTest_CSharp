using Domain.Interfaces.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Net.Http;

namespace JadCentral.IntegrationTests.Framework
{
    public class TestEngine
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly WebApplicationFactoryClientOptions _options;

        public TestEngine(Mock<IJadCentralDataAccess> dataAccess = null, Action<IServiceCollection> action = null)
        {
            _options = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            };
            _factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(webHostBuilder => webHostBuilder.ConfigureTestServices(services =>
            {
                if (dataAccess != null)
                {
                    services.AddTransient(provider => dataAccess.Object);
                }
                action?.Invoke(services);
            }));
        }

        public HttpClient Client() => _factory.CreateClient(_options);

    }
}
