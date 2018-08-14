using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DDD.Infra.Cross.Identity.Interfaces;
using DDD.Infra.Cross.Identity.Models;
using DDD.Infra.Cross.Identity.Services;
using DDD.Data.EF.Context;
using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Data.EF.Repositories;
using DDD.Domain.Test.Processos.Services;
using DDD.Domain.Core.Interfaces.Services;

namespace PGLaw.Infra.Cross.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<IAuthorizationHandler, RequisicaoAjaxHandler>();
            //services.AddSingleton<IAuthorizationHandler, TrocarSenhaHandler>();
            //services.AddSingleton<IAuthorizationHandler, TemAcessoUrlHandler>();
            //services.AddSingleton<IAuthorizationHandler, NaoTemAcessoHandler>();
            services.AddSingleton(Mapper.Configuration);
            //services.AddSingleton<TypeHelper>();
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // AppServices
            //services.AddScoped<IControleDeAcessoAppServices, ControleDeAcessoAppServices>();
            //services.AddScoped<ISistemaAppServices, SistemaAppServices>();
            //services.AddScoped<IProcessosAppServices, ProcessosAppServices>();
            //services.AddScoped<IContratosAppServices, ContratosAppServices>();
            //services.AddScoped<IAuxiliaresAppServices, AuxiliaresAppServices>();
            //services.AddScoped<Application.Juridico.Interfaces.Services.IPessoasAppServices, Application.Juridico.Services.PessoasAppServices>();
            //services.AddScoped<Application.Contratos.Interfaces.Services.IPessoasAppServices, Application.Contratos.Services.PessoasAppServices>();


            // DomainServices
            //services.AddScoped<IMenuServices, MenuServices>();
            //services.AddScoped<INivelDeAcessoServices, NivelDeAcessoServices>();
            //services.AddScoped<IMontagemDeMenusServices, MontagemDeMenusServices>();
            //services.AddScoped<IDadosIniciaisServices, DadosIniciaisServices>();
            //services.AddScoped<IControlarAcessoUsuarioServices, ControlarAcessoUsuarioServices>();
            //services.AddScoped<ICadastroProcessoServices, CadastroProcessoServices>();
            //services.AddScoped<ICadastroContratoServices, CadastroContratoServices>();
            //services.AddScoped<Domain.Juridico.Pessoas.Interfaces.Services.IManterPessoasServices, Domain.Juridico.Pessoas.Services.ManterPessoasServices>();
            //services.AddScoped<Domain.Contratos.Pessoas.Interfaces.Services.IManterPessoasServices, Domain.Contratos.Pessoas.Services.ManterPessoasServices>();
            services.AddScoped<IGenericDomainService, GenericService>();

            // Contexts
            services.AddScoped<DefaultContext>();
            //services.AddScoped<JuridicoContext>();
            //services.AddScoped<ContratoContext>();

            // Repositorios de Sistema
            //services.AddScoped<ISistemaUnitOfWork, SistemaUnitOfWork>();
            //services.AddScoped<ISistemaGlobalRepository, SistemaRepositorioGeral>();
            //services.AddScoped<ISistemaCQRS, SistemaRepositorioGeral>();
            //services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            //services.AddScoped<IUsuariosRepositoryCQRS, UsuariosRepository>();


            // Repositorios de Juridico
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IGenericRepositoryRead, GenericRepository>();

            // Repositorios de Contratos
            //services.AddScoped<IContratoUnitOfWork, ContratoUnitOfWork>();
            //services.AddScoped<IContratoCQRS, ContratoRepositorioGeral>();
            //services.AddScoped<IContratoGlobalRepository, ContratoRepositorioGeral>();
            //services.AddScoped<IContratosRepository, ContratosRepository>();
            //services.AddScoped<IContratosRepositoryCQRS, ContratosRepository>();
            //services.AddScoped<Domain.Contratos.Pessoas.Interfaces.Repositories.IPessoasRepository, Infra.Data.Contratos.Repositories.PessoasRepository>();
            //services.AddScoped<Domain.Contratos.Pessoas.Interfaces.Repositories.IPessoasRepositoryCQRS, Infra.Data.Contratos.Repositories.PessoasRepository>();


            // validadores
            //services.AddTransient<Domain.Juridico.Pessoas.Validations.PessoaValidator>();
            //services.AddTransient<Domain.Contratos.Pessoas.Validations.PessoaValidator>();
            //services.AddTransient<ProcessoValidator>();
            //services.AddTransient<ContratoValidator>();z

            // Infra - Identity
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
