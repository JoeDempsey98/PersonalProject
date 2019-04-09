using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PersonalSite.Areas.Identity.IdentityHostingStartup))]
namespace PersonalSite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}