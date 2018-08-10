using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Globalization;
using System.Threading;

namespace Azuli.Web.Portal
{
    public partial class DetalheClassificado : System.Web.UI.Page
    {
        Util.Util oUtil = new Util.Util();
        ClassificadoBLL oClassificado = new ClassificadoBLL();
        Model.ClassificadoVisto oClassificadoVisto = new Model.ClassificadoVisto();
        Business.ClassificadoVisto oClassViewBll = new Business.ClassificadoVisto();
        Classificados oClassificaModel = new Classificados();
        ApartamentoModel oApModel = new ApartamentoModel();

        int codigoClassificado = 0;
        string folder = System.Configuration.ConfigurationManager.AppSettings["classificado"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                   // lblDescBloco.Text = Session["Bloco"].ToString();
                    //lblDescApartamento.Text = Session["AP"].ToString();
                    //carregaGrupoClassificado();
                    //preencheGrid();
                    //dvAnunciar.Visible = false;
                    //lblGrupo.Text = Session["lblGrupo"].ToString();
                    imgGrupo.ImageUrl = Session["imagemGrupo"].ToString();
                    codigoClassificado = Convert.ToInt32(Request.QueryString["codigo"]);
                    preencheClassificadoDetalhe(codigoClassificado);
                    CultureInfo CI = new CultureInfo("pt-PT");
                    CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

                    Thread.CurrentThread.CurrentCulture = CI;
                    Thread.CurrentThread.CurrentUICulture = CI;
                    base.InitializeCulture();
                    atualizaListaContadorClassificado();

                   // string.CompareOrdinal("ç", "p");
                }

            }

        }

        public void atualizaListaContadorClassificado()
        {
            int contador = 0;
            string data = "";
            

            oClassificaModel.idClassificado = codigoClassificado;
            oClassificadoVisto.oClassificadoID = oClassificaModel;
            data = DateTime.Now.ToString("dd/MM/yyyy");

            oClassificadoVisto.dataVisto = Convert.ToDateTime(data);

            oApModel.apartamento = Convert.ToInt32(Session["AP"]);
            oApModel.bloco = Convert.ToInt32(Session["Bloco"]);

            oClassificadoVisto.oApartamento = oApModel;



            foreach (var item in oClassViewBll.validaClassificadoVisto(oClassificadoVisto))
            {
                contador = item.contadorClassificado;
            }


            if (contador == 0)
            {
                //Insere no classificados Visto
                try
                {
                    oClassViewBll.contabilizaVistoClassificado(oClassificadoVisto);
                }
                catch (Exception err)
                {
                    err.ToString();

                }
            }

            //Lista quantas vezes foi visto
             foreach (var item in  oClassViewBll.listaClassificadoVisto(oClassificadoVisto))
             {
                 lblContador.Text = "Anúncio já visto " + item.contadorClassificado + " X ";
             }
        }

        public void preencheClassificadoDetalhe(int codigoClassificado)
        {
            

            //GrupoClassificados oGrpModel = new GrupoClassificados();

            oClassificaModel.idClassificado = codigoClassificado;

            foreach (var item in oClassificado.consultaClassificado(oClassificaModel))
	        {
                lblCel.Text = item.classificadoTelefone1;
                lblTel.Text = item.classificadoTelefone2;
                lblApartamento.Text = item.apartamentoClassificado.apartamento.ToString();
                lblBloco.Text = item.apartamentoClassificado.bloco.ToString();
                lblDescricao.Text = item.descricaoClassificado;
                lblAssunto.Text = item.assuntoClassificado;
                lblValor.Text = string.Format("{0:C}",item.valorVendaClassificado);

                if (item.classificadoimg4 == "semimg.jpg" && item.classificadoimg2 == "semimg.jpg" && item.classificadoimg3 == "semimg.jpg" && item.classificadoimg1 == "semimg.jpg")
                {
                    dvImagens.Visible = false;
                }
                else
                {
                    if (item.classificadoimg4 != "semimg.jpg")
                    {
                        dvImagens.Visible = true;
                        ImageButton4.Visible = true;
                        ImageButton4.ImageUrl = folder + item.classificadoimg4;
                    }
                    else
                    {
                        ImageButton4.Visible = false;
                    }
                    if (item.classificadoimg2 != "semimg.jpg")
                    {
                        dvImagens.Visible = true;
                        ImageButton2.Visible = true;
                        ImageButton2.ImageUrl = folder + item.classificadoimg2;
                    }
                    else
                    {
                        ImageButton2.Visible = false;
                    }
                    if (item.classificadoimg3 != "semimg.jpg")
                    {
                        dvImagens.Visible = true;
                        ImageButton3.Visible = true;
                        ImageButton3.ImageUrl = folder + item.classificadoimg3;
                    }
                    else
                    {
                        ImageButton3.Visible = false;
                    }

                    if (item.classificadoimg1 != "semimg.jpg")
                    {
                        dvImagens.Visible = true;
                        ImageButton1.Visible = true;
                        ImageButton1.ImageUrl = folder + item.classificadoimg1;
                    }
                    else
                    {

                        ImageButton1.Visible = false;
                    }
                }
            
                lblData.Text = item.dataClassificado.ToString();
                lblEmail.Text = item.emailClassificadoContato;
                tbImagem.Visible = true;
		 
	        } 
          
            



        }

        public void carregaGrupoClassificado(int grupoAnuncio)
        {
            GrupoClassificadoBLL ogrpBll = new GrupoClassificadoBLL();
            GrupoClassificados ogrpModel = new GrupoClassificados();

            ogrpModel.grupoClassificado = grupoAnuncio;
            ogrpModel.descricacaoGrupoClassificado = "";
            ogrpModel.statusClassificado = "";
            ogrpModel.imgGrupoClassificado = "";
            string caminho = "";


            try
            {

                var listaClassifica = ogrpBll.listaGrupoClassificado(ogrpModel);

                var query = from c in listaClassifica
                            where c.grupoClassificado == grupoAnuncio
                            select c;

                caminho = System.Configuration.ConfigurationManager.AppSettings["classificado"];
                foreach (var item in query)
                {

                    imgGrupo.ImageUrl = caminho + item.imgGrupoClassificado;
                   // lblGrupo.Text = item.descricacaoGrupoClassificado;

                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("consultaClassificados.aspx");
        }
    }
}