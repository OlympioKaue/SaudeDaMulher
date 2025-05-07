using SaudeDaMulher.Domain.Repositorios;
using SaudeDaMulher.Infrastrutura.BancoDeAcesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeDaMulher.Infrastrutura.Repositorios
{
    internal class SalvarRepositorio : ISalvarDados
    {
        private readonly SaudeDaMulherDbContext _banco;

        public SalvarRepositorio(SaudeDaMulherDbContext banco)
        {
            _banco = banco;
        }

        public async Task SalvarDados()
        {
            await _banco.SaveChangesAsync();
        }
    }
}
