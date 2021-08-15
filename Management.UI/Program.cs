using System;
using System.Threading.Tasks;
using Management.BusinessLogic;
using Management.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Management.UI
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            try
            {
                ConfigureServices();

                IBusinessLogicUser actionsUser = serviceProvider.GetRequiredService<IBusinessLogicUser>();

                IBusinessLogicStore actionsStore = serviceProvider.GetRequiredService<IBusinessLogicStore>();
                //wait is used to allow for async await operations
                UserRegistration registration = new UserRegistration(actionsUser, actionsStore);
                registration.DisplayDashboard().Wait();

            }
            catch (Exception)
            {
                Console.WriteLine("Unable to start application");
            }
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddScoped<IBusinessLogicUser, UserActions>();
            services.AddScoped<IBusinessLogicStore, StoreActions>();
            services.AddScoped<IUserDataStore, UserDataStore>();
            services.AddScoped<IStoreDataStore, StoreDataStore>();

            serviceProvider = services.BuildServiceProvider();
        }

    }
}
