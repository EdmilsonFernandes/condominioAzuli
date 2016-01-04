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
    public partial class consultaClassificados : System.Web.UI.Page
    {
        
        Util.Util oUtil = new Util.Util();
        ClassificadoBLL oClassificadoBLL = new ClassificadoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                   // lblDescBloco.Text = Session["Bloco"].ToString();
                    //lblDescApartamento.Text = Session["AP"].ToString();
                    carregaGrupoClassificado();
                    
                    dvAnunciar.Visible = false;
                    CultureInfo CI = new CultureInfo("pt-PT");
                    CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

                    Thread.CurrentThread.CurrentCulture = CI;
                    Thread.CurrentThread.CurrentUICulture = CI;
                    base.InitializeCulture();
                }
                
            }

        }

        public void carregaGrupoClassificado()
        {
            Classificados oClassificaModel = new Classificados();
            GrupoClassificadoBLL ogrpBll = new GrupoClassificadoBLL();
            GrupoClassificados ogrpModel = new GrupoClassificados();
            int contaGrup = 0;

            var listaContaGrupo = oClassificadoBLL.contaGrupoClassificado(oClassificaModel);

            ogrpModel.grupoClassificado = 0;
            ogrpModel.descricacaoGrupoClassificado = "";
            ogrpModel.statusClassificado = "";
            ogrpModel.imgGrupoClassificado = "";


            try
            {
            
                var listaClassifica =    ogrpBll.listaGrupoClassificado(ogrpModel);

                foreach (var item in listaClassifica)
                {
                    switch (item.grupoClassificado)
                    {

                            
                        case 1: // Imóveis

                            contaGrup = 0;
                            var query = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query)
                            {
                                contaGrup = count.contaGrupo;
                            }

                            lblImoveis.Text = "(" + contaGrup + ")";   

                           
                            break;
                        case 2: // Veiculos
                            contaGrup = 0;
                            
                            var query2 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query2)
                            {
                                contaGrup = count.contaGrupo;
                                
                            }

                            lblVeiculos.Text = "(" + contaGrup + ")";   
                            break;
                        case 3: // Negocios
                            contaGrup = 0;  
                            var query3 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query3)
                            {
                                contaGrup = count.contaGrupo;
                                  
                            }

                            lblNegocio.Text = "(" + contaGrup + ")";   
                            break;
                        case 5:
                            contaGrup = 0;   
                            var query5 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query5)
                            {
                                contaGrup = count.contaGrupo;
                               
                            }

                            lbleletronico.Text = "(" + contaGrup + ")";   
                            break;
                        case 6:
                            contaGrup = 0;
                            var query6 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query6)
                            {
                                contaGrup = count.contaGrupo;
                               
                            }

                            lblParaSuaCasa.Text = "(" + contaGrup + ")";   
                            break;
                        case 7:
                            contaGrup = 0;   
                            var query7 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query7)
                            {
                                contaGrup = count.contaGrupo;
                                 
                            }
                            lblModa.Text = "(" + contaGrup + ")";   
                            break;
                        case 8:

                            contaGrup = 0;  
                            var query8 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query8)
                            {
                                contaGrup = count.contaGrupo;
                                
                            }

                            lblMusica.Text = "(" + contaGrup + ")";   
                            break;
                        case 9:
                            contaGrup = 0;  
                            var query9 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query9)
                            {
                                contaGrup = count.contaGrupo;
                               
                            }
                            lblAnimal.Text = "(" + contaGrup + ")";   
                            break;
                        case 10:
                            contaGrup = 0;   
                            var query10 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query10)
                            {
                                contaGrup = count.contaGrupo;
                                
                            }
                            lblCrianca.Text = "(" + contaGrup + ")";   
                            break;
                        case 11:
                            contaGrup = 0;  
                            var query11 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query11)
                            {
                                contaGrup = count.contaGrupo;
                                
                            }
                            lblSport.Text = "(" + contaGrup + ")";   
                            break;
                        case 12:

                            contaGrup = 0;
                            var query12 = from contadoGrupo in listaContaGrupo
                                        where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                        select contadoGrupo;

                            foreach (var count in query12)
                            {
                                contaGrup = count.contaGrupo;
                                
                            }
                            lblDiversos.Text = "(" + contaGrup + ")";   
                            break;

                        case 13:

                            contaGrup = 0;
                            var query13 = from contadoGrupo in listaContaGrupo
                                          where contadoGrupo.grpClassificado.grupoClassificado == item.grupoClassificado
                                          select contadoGrupo;

                            foreach (var count in query13)
                            {
                                contaGrup = count.contaGrupo;

                            }
                            lblDiversos.Text = "(" + contaGrup + ")";
                            break;

                    }
                    
                }
            
            }
            catch (Exception e)
            {
                
                throw e;
            }

        }

        public void preencheGrid(int idClassificado)
        {
            Classificados oClassificaModel = new Classificados();
            
            //GrupoClassificados oGrpModel = new GrupoClassificados();
             ApartamentoModel oAp = new ApartamentoModel();

             oClassificaModel.grpClassificado.grupoClassificado = idClassificado;

            //Traz todos os classificados Ativos
             grdClassificado.DataSource = from listaClassificados in oClassificadoBLL.consultaClassificado(oClassificaModel)
                                          where listaClassificados.statusClassificado == "A"
                                          orderby listaClassificados.dataClassificado
                                          select listaClassificados;

       
             grdClassificado.DataBind();

        
           
        }

        protected void imgImoveis_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            preencheGrid(1);
        }

        protected void imgVeiculos_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(2);
            carregaGrupoClassificado(2);

        }

        protected void imgNegocios_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(3);
            carregaGrupoClassificado(3);
        }

        protected void imgEletronicoCelulares_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(5);
            carregaGrupoClassificado(5);
        }

        protected void imgCasa_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(6);
            carregaGrupoClassificado(6);
        }

        protected void imgModaBeleza_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(7);
            carregaGrupoClassificado(7);
        }

        protected void imgMusicaHobbie_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(8);
            carregaGrupoClassificado(8);
        }

        protected void imgAnimaisAcessorios_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(9);
            carregaGrupoClassificado(9);
        }

        protected void imgBebeCrianca_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(10);
            carregaGrupoClassificado(10);
        }

        protected void imgSport_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(11);
            carregaGrupoClassificado(11);
        }

        protected void imgDiversos_Click(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(13);
            carregaGrupoClassificado(13);
        }

        protected void imgImoveis_Click1(object sender, ImageClickEventArgs e)
        {
            dvAnunciar.Visible = true;
            dvGrupo.Visible = false;
            preencheGrid(1);
            carregaGrupoClassificado(1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dvGrupo.Visible = true;
            dvAnunciar.Visible = false;
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
                    lblGrupo.Text = item.descricacaoGrupoClassificado;
                    Session["imagemGrupo"] = imgGrupo.ImageUrl;
                    Session["lblgrupo"] = lblGrupo.Text;

                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }


        }
    }
