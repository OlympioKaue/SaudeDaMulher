using SaudeDaMulher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeDaMulher.Domain.Repositorios
{
   public interface IMulheresRepositorio
    {
        Task Add(Feminino feminino);
        Task<Feminino?> BuscarMulherPorId(int idDaMulher);
    }
}
