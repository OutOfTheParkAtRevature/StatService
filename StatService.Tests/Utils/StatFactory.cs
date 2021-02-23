using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Repository;

namespace StatService.Tests.Utils
{
    public class StatFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class {
        protected override void ConfigureWebHost(IWebHostBuilder builder) {
            builder.UseContentRoot(".");
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services => {
                var descriptor = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<StatsContext>)
                );
                services.Remove(descriptor);
                services.AddDbContext<StatsContext>(options => {
                    options.UseInMemoryDatabase(databaseName: "intg-db");
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope()) {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<StatsContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<StatFactory<TStartup>>>();
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}