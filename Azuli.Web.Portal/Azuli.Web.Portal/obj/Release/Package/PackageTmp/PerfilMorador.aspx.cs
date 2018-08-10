using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;

namespace Azuli.Web.Portal
{
    public partial class PerfilMorador : System.Web.UI.Page
    {
        Util.Util oUtil = new Util.Util();
        string bloco = "";
        string apto = "";
        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {
                    apto =Session["Ap"].ToString();
                    bloco = Session["Bloco"].ToString();
                    listaPerfilMorador();
                }
            }

        }


        public void listaPerfilMorador()
        {
            
            oAPmodel.apartamento = Convert.ToInt32(apto);
            oAPmodel.bloco =  Convert.ToInt32(bloco);

            foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
            {
                lblApto.Text =  item.ap.apartamento.ToString();
                lblBloco.Text = "0"+item.ap.bloco.ToString();
                lblNome.Text = item.proprietario1;
                lblEmail.Text = item.email;
            }

          
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            apto = Session["Ap"].ToString();
            bloco = Session["Bloco"].ToString();
            oAPmodel.apartamento = Convert.ToInt32(apto);
            oAPmodel.bloco = Convert.ToInt32(bloco);

            foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
            {
                lblApto.Text = item.ap.apartamento.ToString();
                lblBloco.Text = "0" + item.ap.bloco.ToString();
                lblNome.Text = item.proprietario1;
                lblEmail.Text = item.email;
            }


        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            apto = Session["Ap"].ToString();
            bloco = Session["Bloco"].ToString();
            oAPmodel.apartamento = Convert.ToInt32(apto);
            oAPmodel.bloco = Convert.ToInt32(bloco);

            foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
            {
                lblApto.Text = item.ap.apartamento.ToString();
                lblBloco.Text = "0" + item.ap.bloco.ToString();
                lblNome.Text = item.proprietario1;
                lblEmail.Text = item.email;
            }
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            apto = Session["Ap"].ToString();
            bloco = Session["Bloco"].ToString();
            oAPmodel.apartamento = Convert.ToInt32(apto);
            oAPmodel.bloco = Convert.ToInt32(bloco);

            foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
            {
                lblApto.Text = item.ap.apartamento.ToString();
                lblBloco.Text = "0" + item.ap.bloco.ToString();
                lblNome.Text = item.proprietario1;
                lblEmail.Text = item.email;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            apto = Session["Ap"].ToString();
            bloco = Session["Bloco"].ToString();
            oAPmodel.apartamento = Convert.ToInt32(apto);
            oAPmodel.bloco = Convert.ToInt32(bloco);

            foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
            {
                lblApto.Text = item.ap.apartamento.ToString();
                lblBloco.Text = "0" + item.ap.bloco.ToString();
                lblNome.Text = item.proprietario1;
                lblEmail.Text = item.email;
            }
        }
         
    }
}