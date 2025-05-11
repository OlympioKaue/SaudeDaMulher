using SaudeDaMulher.Comunicacao.RespostaDTO;
using SaudeDaMulher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.ObterRegistro
{
    public interface IObterRegistroMulherUseCase
    {
        Task<RespostaMulherDTO> Executar(int idDaMulher);
    }
}
