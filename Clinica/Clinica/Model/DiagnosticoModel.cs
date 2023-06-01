using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.Model
{
   public class DiagnosticoModel
    {


        [PrimaryKey]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
       

    }
}
