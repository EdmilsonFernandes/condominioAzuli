using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Azuli.Web.Business;
using Azuli.Web.Model;

namespace Azuli.Web.Portal
{
    /// <summary>
    /// Summary description for WebServiceAzuli
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceAzuli : System.Web.Services.WebService
    {

        [WebMethod]
        public void cadastraFoto(byte[] foto)
        {
            Foto oFotoModel = new Foto();
            FotoBLL oFotoBLL = new FotoBLL();

            oFotoModel.foto = foto;

            try
            {
                oFotoBLL.cadastraFoto(oFotoModel);
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }
    }
}
