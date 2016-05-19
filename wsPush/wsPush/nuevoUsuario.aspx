<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nuevoUsuario.aspx.cs" Inherits="nuevoUsuario" %>

<!DOCTYPE html>
<link href="bootstrap.css" type="text/css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    </head>
<body>
    <form id="form1" runat="server">

        <div class="text-center">

            <h1>
                <asp:Label ID="Label4" runat="server" CssClass="text-primary" Text="Nuevo Usuario"></asp:Label>
            </h1>
            <br />
            <br />

        <asp:Label ID="Label1" runat="server" Text="Usuario" CssClass="text-info"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUsuario" runat="server" Height="25px" Width="342px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Contraseña" CssClass="text-info"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtContraseña" runat="server" Height="25px" Width="342px" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Correo" CssClass="text-info"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCorreo" runat="server" Height="25px" Width="342px"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn-default" OnClick="btnAceptar_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn-default" />
        </div>

    </form>
</body>
</html>
