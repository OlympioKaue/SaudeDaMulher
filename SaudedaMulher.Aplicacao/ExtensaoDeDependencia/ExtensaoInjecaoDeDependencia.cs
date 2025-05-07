using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulher.Registros;
using SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudedaMulher.Aplicacao.ExtensaoDeDependencia
{
   public static class ExtensaoInjecaoDeDependencia
    {
      public static void Adicionar_Programa(this IServiceCollection services)
        {
            AdicionarExtensaoDeDepencia(services);
        }

        private static void AdicionarExtensaoDeDepencia(this IServiceCollection services)
        {
            services.AddScoped<IRegistrosMulherUseCase, RegistrosMulherUseCase>();
            //services.AddScoped<IObterMulherUseCase, ObterMulherUseCase>();
            //services.AddScoped<IAtualizarMulherUseCase, AtualizarMulherUseCase>();
            //services.AddScoped<IRemoverMulherUseCase, RemoverMulherUseCase>();
        }
    }
}
