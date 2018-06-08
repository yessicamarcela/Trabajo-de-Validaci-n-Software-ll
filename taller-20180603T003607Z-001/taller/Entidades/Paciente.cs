using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller
{
    class Paciente
    {
       
        public string nombrePaciente { get; set; }
        public long NumeroDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public Rango Rango { get; set; }
        public long CostosServicios { get; set; }


    }
}
