using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudedaMulher.Aplicacao.Mapster
{
    public interface IMapsterConfig
    {
       Destino Mapear<Origem, Destino>(Origem origem);
    } 
}
