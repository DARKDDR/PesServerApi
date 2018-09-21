using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pes.Models;
using Pes.Repositories;
using Pes.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace PesApi
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
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            _addRepositories(services);
            _addServices(services);
        }

        private void _addRepositories(IServiceCollection services)
        {
            var connection = @"server=localhost;database=pes;user=root;password=root";
            services.AddDbContext<DbContext, pesContext>(options => options.UseMySql(connection) );
            services.AddTransient<ICrudRepository<Bet>, BetRepository>();
            services.AddTransient<ICrudRepository<EventOpponent>, EventOpponentRepository>();
            services.AddTransient<ICrudRepository<Event>, EventRepository>();
            services.AddTransient<ICrudRepository<Game>, GameRepository>();
            services.AddTransient<ICrudRepository<Opponent>, OpponentRepository>();
            services.AddTransient<ICrudRepository<UserBet>, UserBetRepository>();
            services.AddTransient<ICrudRepository<User>, UserRepository>();
        }

        private void _addServices(IServiceCollection services)
        {
            services.AddTransient<IBetService, BetService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IOpponentService, OpponentService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
