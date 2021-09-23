using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ofertas.Dominio.Handlers.Autenticacao;
using Ofertas.Dominio.Handlers.Produtos;
using Ofertas.Dominio.Handlers.ReservaProdutos;
using Ofertas.Dominio.Handlers.Usuarios;
using Ofertas.Dominio.Repositories;
using Ofertas.InfraData.Contexts;
using Ofertas.InfraData.Repositories;
using System;

namespace Ofertas.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<OfertasContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ofertas.Api", Version = "v1" });
            });

            services
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })

               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("OfertasKeySenai2021")),
                       ClockSkew = TimeSpan.FromMinutes(60),
                       ValidIssuer = "Ofertas",
                       ValidAudience = "Ofertas"
                   };
               });


            
            services.AddCors(options => {
                
                options.AddPolicy("CorsPolicy",
                    
                    builder => {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    }
                );
            });

            
            // injeções de dependência            
            #region Usuarios
            services.AddTransient<IUsuarioRepositorio,UsuarioRepositorio>();
            services.AddTransient<CadastrarContaHandle,CadastrarContaHandle>();
            services.AddTransient<ListarUsuariosHandle,ListarUsuariosHandle>();
            services.AddTransient<ObterDadosHandle,ObterDadosHandle>();
            services.AddTransient<ExcluirUsuarioHandle,ExcluirUsuarioHandle>();
            services.AddTransient<LogarHandle,LogarHandle>();
            services.AddTransient<RecuperarSenhaHandle,RecuperarSenhaHandle>();
            services.AddTransient<AlterarSenhaHandle,AlterarSenhaHandle>();

            services.AddTransient<IReservaProdutoRepositorio,ReservaProdutoRepositorio>();
            services.AddTransient<ReservarProdutoHandle,ReservarProdutoHandle>();
            services.AddTransient<ListarReservasHandle,ListarReservasHandle>();
            services.AddTransient<MostrarReservaHandle, MostrarReservaHandle>();
            #endregion


            #region Produtos
            services.AddTransient<IProdutoRepositorio,ProdutoRepositorio>();            
            services.AddTransient<AlterarProdutoHandle,AlterarProdutoHandle>();
            services.AddTransient<BuscarProdutoHandle,BuscarProdutoHandle>();
            services.AddTransient<CadastrarProdutoHandle,CadastrarProdutoHandle>();
            services.AddTransient<ExcluirProdutoHandle,ExcluirProdutoHandle>();
            services.AddTransient<ListarProdutosHandle,ListarProdutosHandle>();                        
            #endregion

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ofertas.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    
    }

}
