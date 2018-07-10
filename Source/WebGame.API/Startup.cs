using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebGame.Core.Data;
using WebGame.Data;
using WebGame.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using WebGame.API.Models;
using WebGame.API.Models.Types;

namespace WebGame.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<WebGameContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:WebGameDb"]));
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IPlanetRepository, PlanetRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<WebGameQuery>();
            services.AddSingleton<WebGameMutation>();

            services.AddSingleton<PlayerType>();
            services.AddSingleton<PlayerInputType>();
            services.AddSingleton<PlanetType>();
            services.AddSingleton<PlanetInputType>();
            services.AddSingleton<CountryType>();
            services.AddSingleton<CountryInputType>();
            services.AddSingleton<CityType>();
            services.AddSingleton<CityInputType>();
            services.AddSingleton<AddCityInputType>();
            services.AddSingleton<AddCountryInputType>();
            services.AddSingleton<SetCityInputType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new WebGameSchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WebGameContext db)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
            //db.EnsureCreated();
        }
    }
}
