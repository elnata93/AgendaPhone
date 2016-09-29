using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AgendaPhone
{
    public partial class Agenda : System.Web.UI.Page
    {
        Personas persona = new Personas();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            MasculinoRadioButton.Checked = false;
            FemeninoRadioButton.Checked = false;
            TipoTelefonoDropDownList.Text = "";
            TelefonoTextBox.Text = "";
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void LlenarDatos()
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);
            persona.nombre = NombreTextBox.Text;
            if (MasculinoRadioButton.Checked == true)
            {
                persona.sexo = 0;
            }
            if (FemeninoRadioButton.Checked == false)
            {
                persona.sexo = 1;
            }

            /*DataTable data = (DataTable)ViewState["Personas"];
            DataRow fila;
            fila = data.NewRow();
            fila["TipoTelefonos"] = TipoTelefonoDropDownList.Text;
            fila["Telefonos"] = TelefonoTextBox.Text;
            data.Rows.Add(fila);
            ViewState["Personas"] = data;
            TelefonoGridView.DataSource = (DataTable)ViewState["Personas"];
            TelefonoGridView.DataBind();*/

            foreach (GridViewRow item in TelefonoGridView.Rows)
            {
                persona.AgregarTelefono(item.Cells[1].Text, item.Cells[2].Text);
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (TelefonoGridView.Rows.Count == 0 || NombreTextBox.Text.Length == 0 || MasculinoRadioButton.Checked == true || FemeninoRadioButton.Checked == true || TipoTelefonoDropDownList.Text.Length == 0 || TelefonoTextBox.Text.Length == 0)
            {
                Response.Write("<script>Alert('Llene los Campos Vacios')</script>");
            }
            else
            if (IdTextBox.Text.Length == 0)
            {
                LlenarDatos();
                if (persona.Insertar())
                {
                    Response.Write("<script>alert('Contacto Guardado')</script>");
                }
                else
                {
                    Response.Write("<script>alert('No se Guardo')</script>");
                }
                Limpiar();
            }
            else
            {
                if (persona.personaId > 0)
                {
                    if (IdTextBox.Text.Length == 0)
                    {
                        LlenarDatos();
                        if (persona.Editar())
                        {
                            Response.Write("<script>alert('Contacto Guardado')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No se Guardo')</script>");
                        }
                        Limpiar();
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Introduzca un ID', 'Alerta', 'Warning')</script>");
            }
            else
            if (persona.Buscar(persona.personaId))
            {
                persona.Eliminar();
            }

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Personas persona;

            if (Session["Persona"] == null)
            {
                Session["Persona"] = new Personas();
            }

            persona = (Personas)Session["Persona"];
            if (TipoTelefonoDropDownList.Text.Length == 0 || TelefonoTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Debe llenar los Campos');</script>");
            }
            persona.AgregarTelefono(TipoTelefonoDropDownList.Text, TelefonoTextBox.Text);
            TelefonoGridView.DataSource = persona.telefono;
            TelefonoGridView.DataBind();
        }
    }
}