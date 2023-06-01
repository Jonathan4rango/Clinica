using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.Model
{
 public   class IncapacidadModel
    {


        [PrimaryKey]
        public string NIncapa { get; set; }
        public string Dias { get; set; }
        public string Apellido { get; set; }
        public string Fecha { get; set; }
        public string Cedula { get; set; }

    }
}
