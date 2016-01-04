using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Model;
using Azuli.Web.Business;
using System.Globalization;
using System.IO;

namespace Azuli.Web.Portal
{
    public partial class listaOcorrenciaMorador : Util.Base
    {
        Util.Util oUtil = new Util.Util();
        DateTime data = DateTime.Now;
        LancamentoOcorrenciaModel olancamentoModel = new LancamentoOcorrenciaModel();
        LancamentoOcorrencia olancamentoBLL = new LancamentoOcorrencia();
        ApartamentoModel oAp = new ApartamentoModel();

        string folder = System.Configuration.ConfigurationManager.AppSettings["EvidenciaMoradorOC"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {


                    listaOcorrenciaMes();
                    //DivRespostaSindico.Visible = false;
                    DivRespostaSindico1.Visible = false;


                }
            }
        }


        public void listaOcorrenciaMes()
        {


            try
            {
                olancamentoModel.codigoOcorrencia = Convert.ToInt32(Session["codigoOcorrencia"]);

                foreach (var item in olancamentoBLL.buscaOcorrenciaById(olancamentoModel))
                {
                    lblAssunto.Text = item.descricaoOcorrencia;
                    lblDataAbertura.Text = item.dataOcorrencia.ToString();
                    lblMensagem.Text = "Descrição da Ocorrência: " + item.ocorrenciaLancamento;
                    lblOcorrencia.Text = item.codigoOcorrencia.ToString();
                    lblMorador.Text = Session["Proprie1"].ToString();
                    lblBlocoMsg.Text = Session["Bloco"].ToString();
                    lblApartamento.Text = Session["AP"].ToString();

                    if (item.imagemEvidencia != "")
                    {
                        lnkDonwloadEvidencia.Visible = true;
                        ImageButton1.Visible = true;
                        ImageButton1.ImageUrl = folder + ("/" + item.imagemEvidencia);

                        Session["NomeImagem"] = item.imagemEvidencia.ToString();

                    }
                    else
                    {
                        lnkDonwloadEvidencia.Visible = false;
                        ImageButton1.Visible = false;
                    }

                }



            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void drpMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaOcorrenciaMes();
        }

        private void listarArquivos(string caminhoArquivo)
        {

            try
            {




                FileInfo arquivo = new FileInfo(Server.MapPath(folder) + ("\\" + caminhoArquivo));

                Response.Clear();


                Response.AddHeader("Content-Disposition", ("attachment; filename=\"" + arquivo.Name));
                Response.Charset = "utf8";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Length", arquivo.Length.ToString());
                Response.WriteFile(arquivo.FullName);
                Response.Flush();
            }
            catch (FileNotFoundException)
            {

                throw;
            }

        }

        protected void lnkDonwloadEvidencia_Click(object sender, EventArgs e)
        {
            listarArquivos(Session["NomeImagem"].ToString());
        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalheOcorrencia.aspx");
        }
    }
}