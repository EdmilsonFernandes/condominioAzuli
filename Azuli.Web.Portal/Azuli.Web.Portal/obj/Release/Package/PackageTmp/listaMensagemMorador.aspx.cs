using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Model;
using Azuli.Web.Business;

namespace Azuli.Web.Portal
{
    public partial class listaMensagemMorador : Util.Base
    {
        Util.Util oUtil = new Util.Util();
        MensagemMoradorModel oMensagemModel = new MensagemMoradorModel();
        MensagemMoradorBLL oMensagemBLL = new MensagemMoradorBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {
                   
                 
                    listaMensagemMoradorBLL();


                }
            }
       
        }


        public void listaMensagemMoradorBLL()
        {
           
            try
            {
                ApartamentoModel oApModel = new ApartamentoModel();
                oApModel.apartamento = Convert.ToInt32(Session["AP"]);
                oApModel.bloco = Convert.ToInt32(Session["Bloco"]);

                oMensagemModel.oAp = oApModel;


                dtListMensagem.DataSource = oMensagemBLL.listaMensagemMorador(oMensagemModel);
                dtListMensagem.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
    }
}