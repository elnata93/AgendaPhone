using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PersonasTelefonos
    {
        public int Id { get; set; }
        public string TipoTelefono { get; set; }
        public string Telefono { get; set; }

        public PersonasTelefonos()
        {
            this.Id = 0;
            this.TipoTelefono = "";
            this.Telefono = "";
        }

        public PersonasTelefonos(string tipoTelefono,string telefono)
        {
            this.TipoTelefono = tipoTelefono;
            this.Telefono = telefono;
        }
    }
}
