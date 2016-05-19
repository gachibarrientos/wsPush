using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        //CREAMOS UNA NUEVA SOLICITUD AL SERVIDOR DE ONE SIGNAL
        var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;
                String titulo = txtTitulo.Text;
        String mensaje = txtCuerpo.Text;
                request.KeepAlive = true;
        request.Method = "POST";
        request.ContentType = "application/json";
                //AGREGAMOS NUESTRA REST API KEY
        request.Headers.Add("authorization", "Basic NTI2MTNjMTEtNTRhNC00YzA3LTk1NDgtZmFlZTFiNzY5YTM0");
                byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                                                //ONE SIGNAL APP ID
                                                + "\"app_id\": \"f06c49ff-e059-4524-bd21-487c527ba457\","
                                                + "\"headings\": {\"en\": \" " + titulo + "\" },"
                                                + "\"contents\": {\"en\": \" "+ mensaje + "\" },"
                                                + "\"included_segments\": [\"All\"]}");
                string responseContent = null;

        try
        {
            using (var writer = request.GetRequestStream())
            {
                writer.Write(byteArray, 0, byteArray.Length);
                if (byteArray.Length > 0) {
                    //SI EL MENSAJE SE ENVIA CORRECTAMENTE HACEMOS LO SIGUIENTE
                    Response.Write("Enviado con éxito");
                    txtCuerpo.Text = "";
                    txtTitulo.Text = "";
                }
                else{
                    Response.Write("ocurrió un error al intentar enviar la notificación");
                }
            }
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                }
            }
        }
        catch (WebException ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
        }
        System.Diagnostics.Debug.WriteLine(responseContent);
        
    }
}