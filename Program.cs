
namespace configtest
{
    using System;
    using System.IO;
    using ConfigTest;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .Configure<AppSettings>(o => configuration.Bind(o))
                .BuildServiceProvider();

            var appSettings = serviceProvider.GetService<IOptions<AppSettings>>().Value;


            Console.WriteLine($"{appSettings.Test} {appSettings.Test2}");

        }
    }
}
