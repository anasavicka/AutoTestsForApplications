using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ApiTests.Modules;

namespace ApiTests.Preconditions
{
    public class DataBasePreconditions
    {
        public ServiceProvider Provider {  get; }

        public DataBasePreconditions() 
        {
            var services = new ServiceCollection();
            services.AddDataAccessMarketplace("Data Source=marketplace.db");
            Provider = services.BuildServiceProvider();
        }
    }
}