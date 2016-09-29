<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="AgendaPhone.Agenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
       
        <div class="container">
            <div class="panel panel-success">
                <div class="panel-heading">Registro de Personas</div>
                <div class="panel-body">
                    <div class="form-horizontal col-md-12" role="form">
            <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
            <asp:TextBox ID="IdTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
            <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="NombreTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Sexo:"></asp:Label>
            <asp:RadioButton ID="MasculinoRadioButton" runat="server" Text="Masculino" />
            <asp:RadioButton ID="FemeninoRadioButton" runat="server" Text="Femenino"/>
            <asp:Label ID="Label4" runat="server" Text="Tipo de Telefono:"></asp:Label>
            <asp:DropDownList ID="TipoTelefonoDropDownList" runat="server">
                <asp:ListItem>Movil</asp:ListItem>
                <asp:ListItem>Casa</asp:ListItem>
                <asp:ListItem>Trabajo</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label5" runat="server" Text="Telefono:"></asp:Label>
            <asp:TextBox ID="TelefonoTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="AgregarButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
            <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
            <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
            <asp:GridView ID="TelefonoGridView" runat="server">
            </asp:GridView>
            </div>
            </div>
            </div>
        </div>
</asp:Content>
