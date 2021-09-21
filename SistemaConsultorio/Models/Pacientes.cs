using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaConsultorio.Models
{
    public class Pacientes : Pessoas
    {
        public int Id { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
