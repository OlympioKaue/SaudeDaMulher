using Mapster;
using SaudedaMulher.Aplicacao.Mapster;
using SaudeDaMulher.Comunicacao.RespostaDTO;
using SaudeDaMulher.Domain.Models;
using SaudeDaMulher.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.ObterRegistro
{
    public class ObterRegistroMulherUseCase : IObterRegistroMulherUseCase
    {
        private readonly IMulheresRepositorio _obterMulher;
        private readonly IMapsterConfig _teste;
        public ObterRegistroMulherUseCase(IMulheresRepositorio obterMulher, IMapsterConfig mapster)
        {
            _obterMulher = obterMulher;
            _teste = mapster;
        }

        public async Task<RespostaMulherDTO> Executar(int idDaMulher)
        {
            var buscar = await _obterMulher.BuscarMulherPorId(idDaMulher);
            if(buscar == null)
                throw new Exception("Mulher não encontrada.");

            return _teste.Mapear<Feminino, RespostaMulherDTO>(buscar);



        }
    }
}
