using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.Model
{
 public   class PacienteModel
    {

        [PrimaryKey]
        public string Cedula { get; set; }
        public string Nombre { get; set; }       
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Fecha { get; set; }

       

    }
}
