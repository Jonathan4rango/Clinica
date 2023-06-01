using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.Model
{
  public  class RegistroModel
    {
        
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Correo { get; set; }

        public string Contrasena { get; set; }

        public string Telefono { get; set; }

        [PrimaryKey]
        public string Usuario { get; set; }

    }
}
