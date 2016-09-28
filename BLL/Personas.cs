using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Personas : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int personaId { get; set; }
        public string nombre { get; set; }
        public int sexo { get; set; }
        public List<PersonasTelefonos> telefono { get; set; }

        public Personas()
        {
            this.personaId = 0;
            this.nombre = "";
            this.sexo = 0;
            telefono = new List<PersonasTelefonos>();
        }

        public Personas(int personaId, string nombre, int sexo)
        {
            this.personaId = personaId;
            this.nombre = nombre;
            this.sexo = sexo;
        }

        public void AgregarTelefono(int personaId, string tipoTelefono, string telefono)
        {
            //telefono.Add(new PersonasTelefonos(personaId, tipoTelefono, telefono));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            object identity;
            try
            {

                identity = conexion.ObtenerValor(String.Format("Insert int Personas(Nombre,Sexo) values('{0}',{1}) select @@Identity", this.nombre, this.sexo));

                int.TryParse(identity.ToString(), out retorno);

                this.personaId = retorno;
                foreach (PersonasTelefonos item in telefono)
                {
                    conexion.Ejecutar(String.Format("insert int PersonasTelefonos(PersonaId,TipoTelefono,Telefono) values({0},'{1}','{2}')", retorno, item.TipoTelefono, item.Telefono));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;

            try
            {
                retorno = conexion.Ejecutar(String.Format("update Personas set Nombre='{0}',Sexo={1} where PersonaId={3}", this.nombre, this.sexo, this.personaId));
                if (retorno)
                {
                    conexion.Ejecutar(String.Format("delete from PersonasTelefonos where PersonaId={0}", this.personaId));
                    foreach (PersonasTelefonos item in telefono)
                    {
                        conexion.Ejecutar(String.Format("insert into PersonasTelefonos(PersonaId,TipoTelefono,Telefono) values({0},'{1}','{2}')", this.personaId, item.TipoTelefono, item.Telefono));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("delete from Personas where PersonaId={0}", this.personaId + "delete from PersonasTelefonos from PersonaId={0}", this.personaId));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable data = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Persona where PersonaId= {0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.personaId = (int)dt.Rows[0]["PersonaId"];
                    this.nombre = dt.Rows[0]["Nombre"].ToString();
                    this.sexo = (int)dt.Rows[0]["Sexo"];

                    data = conexion.ObtenerDatos(string.Format("select * from PersonaTelefono where PersonaId='{0}'", this.personaId));
                    foreach (var item in dt.Rows)
                    {
                        AgregarTelefono((int)dt.Rows[0]["PersonaId"], dt.Rows[0]["TipoTelefono"].ToString(), dt.Rows[0]["Telefono"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Orden by " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Personas Where " + Condicion + Orden);
        }
    }
}
