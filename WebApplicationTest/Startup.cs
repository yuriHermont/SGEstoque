using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using AutoMapper;
using Microsoft.OpenApi.Models;
using SGE.Application.Abstraction.Query;
using SGE.Application.QueryHandler;
using SGE.Application.Abstraction.Command;
using SGE.Application.Command;
using SGE.Domain.Services;
using SGE.Domain.Repository;
using SGE.Infrastructure.Repository;
using SGE.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using SGE.Application.CommandHandler;

namespace WebApplicationTest
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
            services.AddCors(option => option.AddDefaultPolicy(policy=> policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            //services.AddRazorPages();
            services.AddMvc();
            
            //services.AddDbContext<ProdutoDbContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<DBContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(ListarProdutosQuery), typeof(ListarProdutosQueryHandler));
            services.AddMediatR(typeof(ConsultarProdutoQuery), typeof(ConsultarProdutoQueryHandler));
            services.AddMediatR(typeof(CriarProdutoCommand), typeof(CriarProdutoCommandHandler));
            services.AddMediatR(typeof(AtualizarProdutoCommand), typeof(AtualizarProdutoCommandHandler));
            services.AddMediatR(typeof(DeletarProdutoCommand), typeof(DeletarProdutoCommandHandler));
            

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "SGE",
                        Description = "Sistema Gerenciado de Estoque",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Yuri S. Hermont Jr.",
                            Email = "yuri.hermont@gmail.com",
                            Url = new Uri("https://www.linkedin.com/in/yuri-de-souza-hermont-0483b5145/"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license"),
                        }
                    });
                })
            .Configure<SwaggerUIOptions>(this.Configuration.GetSection("Swagger:SwaggerUIOptions"));



            services.AddAutoMapper(typeof(SGE.API.Mapping.MappingProfile));
            services.AddAutoMapper(typeof(SGE.Application.Mapping.MappingProfile));

            //Queries
            services.AddScoped<ListarProdutosQuery>();
            services.AddScoped<ListarProdutosQueryHandler>();
            services.AddScoped<ConsultarProdutoQuery>();
            services.AddScoped<ConsultarProdutoQueryHandler>();

            //Commands
            services.AddScoped<CriarProdutoCommand>();
            services.AddScoped<CriarProdutoCommandHandler>();
            services.AddScoped<AtualizarProdutoCommand>();
            services.AddScoped<AtualizarProdutoCommandHandler>();
            services.AddScoped<DeletarProdutoCommand>();
            services.AddScoped<DeletarProdutoCommandHandler>();

            //DomainService
            services.AddScoped<ProdutoService>();

            //Repositories
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddSingleton<DBContext>();
            services.AddSingleton<ProdutoDbContext>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger()
               .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
