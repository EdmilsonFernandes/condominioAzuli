using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azuli.Web.Portal
{
    public partial class TelaControlePortaria : System.Web.UI.Page
    {
        Util.Util oUtil = new Util.Util();
      
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               oUtil.validaAcessoPortaria();
                
            }

        }
    }
}