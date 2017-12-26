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
    public partial class anunciarClassificado : Util.Base
    {
       
        Util.Util oUtil = new Util.Util();
        ClassificadoBLL oClassificado = new ClassificadoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                    lblDescBloco.Text = Session["Bloco"].ToString();
                    lblDescApartamento.Text = Session["AP"].ToString();
                  //  carregaGrupoClassificado();
                    preencheGrid();
                    //dvAnunciar.Visible = false;
                }
                
            }

        }

        //public void carregaGrupoClassificado()
        //{
        //    GrupoClassificadoBLL ogrpBll = new GrupoClassificadoBLL();
        //    GrupoClassificados ogrpModel = new GrupoClassificados();

        //    ogrpModel.grupoClassificado = 0;
        //    ogrpModel.descricacaoGrupoClassificado = "";
        //    ogrpModel.statusClassificado = "";
        //    ogrpModel.imgGrupoClassificado = "";


        //    try
        //    {
            
        //        var listaClassifica =    ogrpBll.listaGrupoClassificado(ogrpModel);

        //        foreach (var item in listaClassifica)
        //        {
        //            switch (item.grupoClassificado)
        //            {
        //                case 1: // Imóveis
        //                    lblImoveis.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 2: // Veiculos
        //                    lblVeiculos.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 3: // Negocios
        //                    lblNegocio.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 5:
        //                    lbleletronico.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 6:
        //                    lblParaSuaCasa.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 7:
        //                    lblModa.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 8:
        //                    lblMusica.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 9:
        //                    lblAnimal.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 10:
        //                    lblCrianca.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 11:
        //                    lblSport.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 12:
        //                    lblDiversos.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //                case 13:
        //                    lblDiversos.Text = item.descricacaoGrupoClassificado;
        //                    break;
        //            }
                    
        //        }
            
        //    }
        //    catch (Exception e)
        //    {
                
        //        throw e;
        //    }

        //}

        public void preencheGrid()
        {
            Classificados oClassificaModel = new Classificados();
            
            //GrupoClassificados oGrpModel = new GrupoClassificados();
             ApartamentoModel oAp = new ApartamentoModel();

             oAp.apartamento = Convert.ToInt32(Session["Ap"]);
             oAp.bloco = Convert.ToInt32(Session["Bloco"]);
             oClassificaModel.apartamentoClassificado = oAp;
            //oGrpModel.grupoClassificado = 0;
            //oClassificaModel.grpClassificado = oGrpModel;
            //oClassificaModel.dataClassificado = Convert.ToDateTime("17530101");

             grdClassificado.DataSource = from listaClassificados in oClassificado.consultaClassificado(oClassificaModel)
                                          where listaClassificados.statusClassificado == "A"
                                          orderby listaClassificados.dataClassificado
                                          select listaClassificados;

             grdClassificado.DataBind();

        
           
        }

        protected void imgImoveis_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+1);
        }

        protected void imgVeiculos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+2);

        }

        protected void imgNegocios_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+3);
        }

        protected void imgEletronicoCelulares_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+5);
        }

        protected void imgCasa_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+6);
        }

        protected void imgModaBeleza_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+7);
        }

        protected void imgMusicaHobbie_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+8);
        }

        protected void imgAnimaisAcessorios_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+9);
        }

        protected void imgBebeCrianca_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+10);
        }

        protected void imgSport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+11);
        }

        protected void imgDiversos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastrarClassificado.aspx?var="+12);
        }


        }
    }
