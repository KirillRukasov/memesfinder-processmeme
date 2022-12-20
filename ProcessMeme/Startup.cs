﻿using System;
using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessMeme.Extensions;
using ProcessMeme.Infrastructure.SearchEngine;

[assembly: FunctionsStartup(typeof(ProcessMeme.Startup))]
namespace ProcessMeme
{
	public class Startup : FunctionsStartup
	{
        private IConfigurationRoot _functionConfig;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            _functionConfig = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddGoogleSearch(_functionConfig);

            builder.Services.AddLogging();
        }
    }
}

