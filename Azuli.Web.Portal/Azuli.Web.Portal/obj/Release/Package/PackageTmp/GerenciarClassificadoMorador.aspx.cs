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
    public partial class GerenciarClassificadoMorador : System.Web.UI.Page
    {

        Util.Util oUtil = new Util.Util();
        ClassificadoBLL oClassificado = new ClassificadoBLL();
        Classificados oClassificaModel = new Classificados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                    DetailsView1.Visible = true;
                    DetailsView1.ChangeMode(DetailsViewMode.Edit);
                    preencheDetailsView();
                    //dvAnunciar.Visible = false;
                    CultureInfo CI = new CultureInfo("pt-PT");
                    CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

                    Thread.CurrentThread.CurrentCulture = CI;
                    Thread.CurrentThread.CurrentUICulture = CI;
                    base.InitializeCulture();
                }

            }
        }


        

        public void preencheDetailsView()
        {
            

       
            ApartamentoModel oAp = new ApartamentoModel();

            oAp.apartamento = Convert.ToInt32(Session["Ap"]);
            oAp.bloco = Convert.ToInt32(Session["Bloco"]);
            oClassificaModel.apartamentoClassificado = oAp;
            oClassificaModel.idClassificado = Convert.ToInt32(Request.QueryString["codigo"]);
            //oClassificaModel.dataClassificado = Convert.ToDateTime("17530101");


            DetailsView1.DataSource = oClassificado.consultaClassificado(oClassificaModel);
            DetailsView1.DataBind();



        }

        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            DataKey key = DetailsView1.DataKey;

            if (e.CommandName == "Update")
            {

                Classificados oClassificaModel = new Classificados();
                GrupoClassificados oGrupoModel = new GrupoClassificados();

           

                TextBox assunto = (TextBox)DetailsView1.FindControl("TextBox1");
                oClassificaModel.assuntoClassificado = assunto.Text;

                TextBox descricao = (TextBox)DetailsView1.FindControl("TextBox2");
                oClassificaModel.descricaoClassificado = descricao.Text;

                TextBox telefone = (TextBox)DetailsView1.FindControl("TextBox3");
                oClassificaModel.classificadoTelefone1 = telefone.Text;

                TextBox celular = (TextBox)DetailsView1.FindControl("TextBox4");
                oClassificaModel.classificadoTelefone2 = celular.Text;

                TextBox email = (TextBox)DetailsView1.FindControl("TextBox5");
                oClassificaModel.emailClassificadoContato = email.Text;

                TextBox valor = (TextBox)DetailsView1.FindControl("TextBox6");
                oClassificaModel.valorVendaClassificado = Double.Parse(valor.Text, System.Globalization.CultureInfo.CurrentCulture);

                //TextBox status = (TextBox)DetailsView1.FindControl("TextBox7");
                //oClassificaModel.statusClassificado = status.Text;



                //TextBox img1 = (TextBox)DetailsView1.FindControl("TextBox10");
                //oClassificaModel.classificadoimg1 = img1.Text;


                //TextBox img2 = (TextBox)DetailsView1.FindControl("TextBox11");
                //oClassificaModel.classificadoimg2 = img2.Text;


                //TextBox img3 = (TextBox)DetailsView1.FindControl("TextBox12");
                //oClassificaModel.classificadoimg3 = img3.Text;

                //TextBox dataVenda = (TextBox)DetailsView1.FindControl("TextBox14");
                //oClassificaModel.classificadoDataVenda = Convert.ToDateTime(dataVenda.Text);

                //TextBox img4 = (TextBox)DetailsView1.FindControl("TextBox7");
                //oClassificaModel.classificadoimg4 = img4.Text;

                 //TextBox grupoClassificados = (TextBox)DetailsView1.FindControl("TextBox9");
               // oGrupoModel.grupoClassificado = Convert.ToInt32(grupoClassificados.Text);
               // oClassificaModel.grpClassificado = oGrupoModel;

                oClassificaModel.idClassificado = Convert.ToInt32(key.Value);

                try
                {
                    oClassificado.atualizaClassificado(oClassificaModel);
                    lblMsg.Text = "Classificado Alterado com Sucesso!!";
                }
                catch (Exception err)
                {

                    throw err;
                }
            }
            else if (e.CommandName == "Vendido")
            {

                oClassificaModel.idClassificado = Convert.ToInt32(key.Value);
                oClassificaModel.classificadoDataVenda = DateTime.Now;
              

                try
                {
                    oClassificado.atualizaClassificado(oClassificaModel);
                    DetailsView1.Visible = false;
                    lblMsg.Text = "Obrigador por utilizar o Classificado!";

                }
                catch (Exception)
                {
                    
                    throw;
                }

            }
            else if (e.CommandName == "Desativar")
            {

                oClassificaModel.idClassificado = Convert.ToInt32(key.Value);
                oClassificaModel.statusClassificado = "I";
              

                try
                {
                    oClassificado.atualizaClassificado(oClassificaModel);
                    lblMsg.Text = "Classificado Desativado com sucesso!!";
                }
                catch (Exception error)
                {

                    throw error;
                }
                
            }

            else if (e.CommandName == "voltar")
            {

                Response.Redirect("meuClassificados.aspx");
            }



            
          


        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {

        }
    }
}