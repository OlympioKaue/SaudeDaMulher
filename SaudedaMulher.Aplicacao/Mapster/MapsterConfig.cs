using Mapster;
using SaudeDaMulher.Comunicacao.RequisicaoDTO;
using SaudeDaMulher.Comunicacao.RespostaDTO;
using SaudeDaMulher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudedaMulher.Aplicacao.Mapster
{
    public class MapsterConfig : IMapsterConfig
    {
        public Destino Mapear<Origem, Destino>(Origem origem)
        {
            return origem.Adapt<Destino>();
        }

        public static void RegistrarMapeamento()
        {
            // DTO requisição -> Entidade
            TypeAdapterConfig<CadastroMulheres, Feminino>
                .NewConfig();


            // Entidade -> DTO resposta
            TypeAdapterConfig<Feminino, RespostaMulherDTO>
                .NewConfig();
               
        }

       
    }
}
