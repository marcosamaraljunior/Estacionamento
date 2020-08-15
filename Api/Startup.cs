using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestrutura.Contextos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Estacionamento
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
            services.AddControllers();
            // services.AddDbContext<MyContext>();

            services.AddDbContext<Infraestrutura.Contextos.MyContext>(options => options.UseMySQL("Server=localhost;DataBase=Estacionamento;Uid=estacionamento;Pwd=1234"));
            services.AddScoped<Dominio.Interfaces.Infraestrutura.Repositorios.IRepoEstadia, Infraestrutura.Repositorios.RepositorioEstadia>();
            services.AddScoped<Dominio.Interfaces.Infraestrutura.Repositorios.IRepoCarros, Infraestrutura.Repositorios.RepositorioCarros>();
            services.AddScoped<Dominio.Interfaces.Infraestrutura.Repositorios.IRepoHistoricoEstadias, Infraestrutura.Repositorios.RepositorioHistoricoEstadias>();
            services.AddScoped<Dominio.Interfaces.Servicos.IGerenciadorDeCarros, Servicos.GerenciadorDeCarros>();
            services.AddScoped<Dominio.Interfaces.Servicos.IGerenciadorDeEstadia, Servicos.GerenciadorDeEstadia>();
            services.AddScoped<Dominio.Interfaces.Servicos.IGerenciadorHistoricoEstadias, Servicos.GerenciadorHistoricoEstadias>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
