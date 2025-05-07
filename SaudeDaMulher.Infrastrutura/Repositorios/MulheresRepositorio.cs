using SaudeDaMulher.Domain.Models;
using SaudeDaMulher.Domain.Repositorios;
using SaudeDaMulher.Infrastrutura.BancoDeAcesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeDaMulher.Infrastrutura.Repositorios
{
    internal class MulheresRepositorio : IMulheresRepositorio
    {
        private readonly SaudeDaMulherDbContext _banco;

        public MulheresRepositorio(SaudeDaMulherDbContext banco)
        {
            _banco = banco;
        }

        public async Task Add(Feminino feminino)
        {
           await _banco.CadastroMulheres.AddAsync(feminino);

        }
    }
}
