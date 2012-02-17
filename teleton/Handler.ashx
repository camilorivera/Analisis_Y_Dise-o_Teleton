<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.IO;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        BL.Paciente pac = new BL.Paciente();

        long expedienteID = long.Parse(context.Request.QueryString["Expediente"].ToString());
        int ca = int.Parse(context.Request.QueryString["CentroActual"].ToString());        
        
        if (pac.leerPaciente(ca, expedienteID))
        {           
            if (pac.Foto.Length > 0)
            {
                context.Response.ContentType = "image/jpg";    
                context.Response.OutputStream.Write(pac.Foto, 0, pac.Foto.Length);
            }
            else
            {
                FileStream f = new FileStream(context.Server.MapPath("~/images/usuario.png"), FileMode.Open);
                byte[] b = new byte[f.Length];
                f.Read(b, 0, (int)f.Length);
                f.Close();
                
                context.Response.ContentType = "image/png";
                context.Response.OutputStream.Write(b, 0, b.Length);
            }
            //context.Response.BinaryWrite(pac.Foto);
        }       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}