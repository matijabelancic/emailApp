using emailApp_Q.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MudBlazor.Services;
using MudBlazor;

namespace emailApp_Q.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddMudServices(config =>
             {
                 config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
                 config.SnackbarConfiguration.PreventDuplicates = false;
                 config.SnackbarConfiguration.NewestOnTop = false;
                 config.SnackbarConfiguration.ShowCloseIcon = true;
                 config.SnackbarConfiguration.VisibleStateDuration = 1500;
                 config.SnackbarConfiguration.HideTransitionDuration = 500;
                 config.SnackbarConfiguration.ShowTransitionDuration = 500;
                 config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
                 config.SnackbarConfiguration.MaxDisplayedSnackbars = 1;
             });

            await builder.Build().RunAsync();
        }
    }
}
