using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaudeDaMulher.Domain.Repositorios;
using SaudeDaMulher.Infrastrutura.BancoDeAcesso;
using SaudeDaMulher.Infrastrutura.Repositorios;


namespace SaudeDaMulher.Infrastrutura.ExtensaoDeDependencia;

public static class ExtensaoInjecaoDeDependencia
{

    public static void AdicionarDados(this IServiceCollection service, IConfiguration connection)
    {
        AdicionarBancoDeDados(service, connection);
        AdicionarInjecaoDeDependencia(service);
    }   

    private static void AdicionarBancoDeDados(IServiceCollection service, IConfiguration connection)
    {
        var conexao = connection.GetConnectionString("ContextDb");
        var versaoMySql = new MySqlServerVersion(new Version(8, 0, 41));

        service.AddDbContext<SaudeDaMulherDbContext>(options =>
        {
            options.UseMySql(conexao, versaoMySql, mySqlOptions =>
            {
                mySqlOptions.MigrationsAssembly("SaudaDaMulher.API");
            });
        }); 
    }


    public static void AdicionarInjecaoDeDependencia(this IServiceCollection service)
    {
        service.AddScoped<IMulheresRepositorio, MulheresRepositorio>();
        service.AddScoped<ISalvarDados, SalvarRepositorio>();

    }
}
