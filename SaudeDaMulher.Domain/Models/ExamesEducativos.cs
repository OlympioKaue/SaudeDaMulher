using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeDaMulher.Domain.Models
{
    public class ExamesEducativos
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Explicacao { get; set; }
        public int IdadeMinima {get; set;}
        public int IdadeMaxima { get; set; }
        public int FrequenciaAnos { get; set; }
    }
}
