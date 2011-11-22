<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        BL.Paciente pac = new BL.Paciente();

        long expedienteID = long.Parse(context.Request.QueryString["Expediente"].ToString());
        int ca = int.Parse(context.Request.QueryString["CentroActual"].ToString());        
        
        if (pac.leerPaciente(ca, expedienteID))
        {
            context.Response.ContentType = "image/jpg";
            context.Response.OutputStream.Write(pac.Foto, 0, pac.Foto.Length);
            //context.Response.BinaryWrite(pac.Foto);
        }       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}