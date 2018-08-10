using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azuli.Web.Portal
{
    public partial class TelaConfirmacaoAgendamento : Util.Base
    {
        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (oUtil.validateSession())
                    validaAreaCadastro();
            }
        }

        protected void btnOKConfirma_Click(object sender, EventArgs e)
        {
            Response.Redirect("telaAgendamento.aspx");
        }

        public void validaAreaCadastro()
        {


            lblDataConfirma.Text = Session["DataConfirmacao"].ToString();
            lblBlocoConfirma.Text = Session["Bloco"].ToString();
            lblApConfirma.Text = Session["AP"].ToString();
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {

            HttpContext.Current.Response.Write("<script>window.print();</script>");

        }
    }
}