using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Azuli.Web.Model;
using Azuli.Web.Business;

namespace Azuli.Web.Portal
{
    /// <summary>
    /// Summary description for MostraFoto
    /// </summary>
    public class MostraFoto : IHttpHandler
    {
        Foto oFoto = new Foto();
        FotoBLL oFotoBLL = new FotoBLL();
        byte[] imagenByte;


        public void ProcessRequest(HttpContext context)
        {
            Dictionary<int, byte[]> lastIdFoto = new Dictionary<int, byte[]>();

             lastIdFoto =  oFotoBLL.lastIdFotoSaved();
            

            foreach (var item in lastIdFoto)
            {
                imagenByte = item.Value;
            }

            context.Response.ContentType = ".PNG";
            context.Response.BinaryWrite(imagenByte);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}