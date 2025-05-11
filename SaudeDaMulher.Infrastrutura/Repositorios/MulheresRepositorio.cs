using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Adiciona uma mulher ao banco de dados, veficando se já existe uma mulher com o mesmo nome, telefone ou email.
        /// </summary>
        /// <param name="feminino"></param>
        /// <returns></returns>
        public async Task Add(Feminino feminino)
        {

            var existeNoBanco = await _banco.CadastroMulheres.AnyAsync
                (banco => banco.Nome == feminino.Nome || banco.Telefone == feminino.Telefone || banco.Email == feminino.Email);
            if (existeNoBanco)
                throw new Exception("Já existe um registro com o mesmo nome, telefone ou email.");


            await _banco.CadastroMulheres.AddAsync(feminino);

        }

        /// <summary>
        /// Busca a mulher por id
        /// </summary>
        /// <param name="idDaMulher"></param>
        /// <returns></returns>
        public  Task<Feminino?> BuscarMulherPorId(int idDaMulher)
        {
             return _banco.CadastroMulheres
                 .AsNoTracking()
                 .FirstOrDefaultAsync(mulher => mulher.Id == idDaMulher);

            
        }
    }
}
