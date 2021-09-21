using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaConsultorio.Models
{
    public class Consultas
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Observação { get; set; }

        public int PacienteFK { get; set; }
        public int MedicoFK { get; set; }
        [ForeignKey("PacienteFK")]
        public Pacientes Paciente {get;set;}
        [ForeignKey("MedicoFK")]
        public Medicos Medico { get; set; }
    }
}
