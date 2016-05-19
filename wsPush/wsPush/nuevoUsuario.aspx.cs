using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nuevoUsuario : System.Web.UI.Page
{
    String cadenadeconexion = "Data Source=GACHI-PC;Initial Catalog=docentes;User ID=Gachi;Password=gabrielb31";
    String usuario, contraseña, correo;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
       usuario = txtUsuario.Text;
        contraseña = txtContraseña.Text;
         correo = txtCorreo.Text;

        if (usuario != "" && contraseña != "")
        {
            Boolean state = verificarUsuario();
            if (state)
            {

                Response.Write("Nombre de usuario existente");
                
            }
            else {
                SqlConnection con = new SqlConnection(cadenadeconexion);
                SqlCommand sql = new SqlCommand();
                sql.Connection = con;
                sql.CommandText = "insertQuery '" + usuario + "','" + contraseña + "','" + correo + "'";
                con.Open();
                bool proc = Convert.ToBoolean(sql.ExecuteNonQuery());
                if (proc)
                {
                    Response.Redirect("Default.aspx");
                    Response.Write("Registrado con éxito");
                    con.Close();
                }
                else
                {
                    Response.Write("Error SQL");
                }
            }
        }
        else {
            Response.Write("Debes ingresar datos válidos");
        }
    }
    public bool verificarUsuario() {    
        SqlConnection con = new SqlConnection(cadenadeconexion);
        SqlCommand sql = new SqlCommand();
        sql.Connection = con;
        sql.CommandText = "exec usuarioExistente '" + usuario + "'";
        con.Open();
        int proc = Convert.ToInt32(sql.ExecuteScalar());
        con.Close();
        return proc>0;
    }
}