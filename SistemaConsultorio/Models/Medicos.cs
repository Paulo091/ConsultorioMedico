using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaConsultorio.Models
{
    public class Medicos : Pessoas
    {
        public int Id { get; set; }
        [Required]
        public string CRM { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
