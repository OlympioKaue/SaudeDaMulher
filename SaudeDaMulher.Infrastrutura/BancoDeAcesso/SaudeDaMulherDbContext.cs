using Microsoft.EntityFrameworkCore;
using SaudeDaMulher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeDaMulher.Infrastrutura.BancoDeAcesso
{
    public class SaudeDaMulherDbContext : DbContext
    {
        public SaudeDaMulherDbContext(DbContextOptions<SaudeDaMulherDbContext> options)
                : base(options)
        {
        }
        public DbSet<ExamesEducativos> ExamesEducativos { get; set; }
        public DbSet<MesesConscientizacao> MesesConscientizacao { get; set; }
        public DbSet<Feminino> CadastroMulheres { get; set; }

    }
}
