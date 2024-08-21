using Microsoft.Extensions.Logging;
using Symptoms.ApiClient.IoC;
using Symptoms.Client.Models.ViewModels;
using Symptoms.Client.Pages;
using System.Runtime.ExceptionServices;

namespace Symptoms.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSymptomsApiClientService(x => x.ApiBaseAddress = "http://10.0.2.2:5158/");
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<SymptomAddEdit>();

            builder.Services.AddTransient<SymptomsViewModel>();
            builder.Services.AddTransient<SymptomDetailViewModel>();

            builder.Services.AddTransient<SymptomListPage>(sp =>
            {
                var viewModel = sp.GetRequiredService<SymptomsViewModel>();
                return new SymptomListPage
                {
                    BindingContext = viewModel
                };
            });

            builder.Services.AddTransient<SymptomDetailPage>(sp =>
            {
                var viewModel = sp.GetRequiredService<SymptomDetailViewModel>();
                return new SymptomDetailPage
                {
                    BindingContext = viewModel
                };
            });

            //builder.Services.AddTransient<SymptomListPage>();
            //builder.Services.AddTransient<SymptomDetailPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // Rejestracja globalnej obsługi wyjątków
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

            return builder.Build();
        }
        private static void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"********************************** UNHANDLED EXCEPTION! Details: {e.Exception.ToString()}");
        }
    }
}
