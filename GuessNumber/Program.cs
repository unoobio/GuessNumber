using GuessNumber.Abstractions.Logic;
using GuessNumber.Abstractions.UI;
using GuessNumber.Implementations.Logic;
using GuessNumber.Implementations.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = AppStartup();
        var dialogManager = host.Services.GetRequiredService<IDialogManager>();
        dialogManager.Run();

    }

    private static IHost AppStartup()
    {
        var host = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) => {
                        services.AddScoped<IConcievedNumberProvider, ConcievedNumberProvider>()
                        .AddScoped<ISettingsProvider, CashedAppConfigSettingsProvider>()
                        .Decorate<ISettingsProvider, SettingsValidator>()
                        .AddScoped<ICachedModelProvider<Settings>, CashedAppConfigSettingsProvider>()
                        .AddScoped<INumberComparer, NumberComparer>()
                        .AddScoped<INumberGenerator, NumberGenerator>()
                        .AddScoped<IMainLogic, MainLogic>()
                        .AddScoped<IDialogManager, ConsoleDialogManager>();

                    })
                    .Build();

        return host;
    }
}