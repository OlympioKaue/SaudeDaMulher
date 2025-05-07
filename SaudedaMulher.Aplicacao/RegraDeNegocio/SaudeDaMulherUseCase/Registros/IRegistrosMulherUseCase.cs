using SaudeDaMulher.Comunicacao.RequisicaoDTO;
using SaudeDaMulher.Comunicacao.RespostaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudedaMulher.Aplicacao.RegraDeNegocio.SaudeDaMulherUseCase.Registros
{
   public interface IRegistrosMulherUseCase
    {
        Task<RespostaRegistroMulher> Executar(CadastroMulheres request);
    }
}
