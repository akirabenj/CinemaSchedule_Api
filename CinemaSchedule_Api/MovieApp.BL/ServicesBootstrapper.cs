using Microsoft.Extensions.DependencyInjection;
using MovieApp.BL.Interfaces;
using MovieApp.BL.Services;

namespace MovieApp.BL
{
    //Bootstrapper for BL services
    public static class ServicesBootstrapper
    {
        public static void ServicesDI (this IServiceCollection services)
        {
            services.AddTransient<IActorService, ActorService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IShowTimeService, ShowTimeService>();
        }
    }
}
