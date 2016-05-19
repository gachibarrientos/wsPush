using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        String usuario = txtUsuario.Text;
        String contraseña = txtContraseña.Text;
        if (usuario != " " && contraseña != " ")
        {
            String cadenadeconexion = "Data Source=GACHI-PC;Initial Catalog=docentes;User ID=Gachi;Password=gabrielb31";
            SqlConnection con = new SqlConnection(cadenadeconexion);
            SqlCommand sql = new SqlCommand();
            sql.Connection = con;
            sql.CommandText = "exec verificarUsuarioyContra '"+usuario+"','"+contraseña+"'";
            con.Open();
            bool proc = Convert.ToBoolean(sql.ExecuteNonQuery());
            if (proc) {
                Response.Redirect("Default.aspx");
                con.Close();
            }
            else
            {
                Response.Write("Error en la consulta sql");
            }
            
        }
        else {
            Response.Write("Debes ingresar los datos");
        }
    }

    protected void btnNuevoUsuario_Click(object sender, EventArgs e)
    {
        Response.Redirect("nuevoUsuario.aspx");
    }
}