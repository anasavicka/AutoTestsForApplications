using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTests.Fixtures
{
    public class TestFixture
    {
        public ServiceProvider Provider { get; }

        public TestFixture()
        {
            var services = new ServiceCollection();

            var dbPath = Path.Combine(AppContext.BaseDirectory, "marketplace.db");
            var conn = $"Data Source={dbPath}";
            services.AddDataAccess(conn);
            Provider = services.BuildServiceProvider();
        }
    }
}
