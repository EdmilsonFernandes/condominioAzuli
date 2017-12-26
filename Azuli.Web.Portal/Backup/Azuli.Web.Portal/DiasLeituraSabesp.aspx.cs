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
    public partial class DiasLeituraSabesp : Util.Base
    {
        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                oUtil.validateSessionAdmin();
            }

        }

        protected void txtLeituraAnterior_TextChanged(object sender, EventArgs e)
        {
            TimeSpan diasLeitura = Convert.ToDateTime(txtLeituraAtual.Text) - Convert.ToDateTime(txtLeituraAnterior.Text);
            txtPeriodo.Text = diasLeitura.Days.ToString();
        }

        protected void btnCadastraLeituraSabesp_Click(object sender, EventArgs e)
        {
            LeituraSabesp oLeituraSabespModel = new LeituraSabesp();
            LeituraSabespBLL oLeituraSabesp = new LeituraSabespBLL();

            oLeituraSabespModel.mesReferencia = drpListaMes.SelectedItem.Value + "(" + drpListaMes.SelectedItem.Text + ")";
            oLeituraSabespModel.dataAtual = Convert.ToDateTime(txtLeituraAtual.Text);
            oLeituraSabespModel.dataAnterior = Convert.ToDateTime(txtLeituraAnterior.Text);
            oLeituraSabespModel.dias = Convert.ToInt32(txtPeriodo.Text);


            try
            {

              oLeituraSabesp.cadastraLeituraSabels(oLeituraSabespModel);
              grdConfigArea.DataBind();

              txtPeriodo.Text = "";
              txtLeituraAtual.Text = "";
              txtLeituraAnterior.Text = "";
              drpListaMes.SelectedIndex = - 1;

            }
            catch (Exception ex)
            {

                throw ex;
            }


           
        }
    }
}