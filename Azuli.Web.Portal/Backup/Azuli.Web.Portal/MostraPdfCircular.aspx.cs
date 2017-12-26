using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azuli.Web.Portal
{
    public partial class MostraPdfCircular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

             string test_document_id = Page.Request.QueryString["static_document_id"];
             consultaCircular oConsulta = new consultaCircular();

             oConsulta.listarArquivos(test_document_id);
        }
    }
}