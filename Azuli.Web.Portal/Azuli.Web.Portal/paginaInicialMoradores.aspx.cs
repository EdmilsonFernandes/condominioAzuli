using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Model;
using Azuli.Web.Business;
using System.Text;
using System.IO;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace Azuli.Web.Portal
{
    public partial class paginaInicialMoradores : Util.Base
    {
        Util.Util oUtil = new Util.Util();
        MensagemMoradorModel oMensagemModel = new MensagemMoradorModel();
        MensagemMoradorBLL oMensagemBLL = new MensagemMoradorBLL();
        Enquete oEnqueteModel = new Enquete();
        EnqueteBLL oEnqueteBLL = new EnqueteBLL();
        ApartamentoModel oApEnquete = new ApartamentoModel();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {
                    lblMorador.Text = Session["Proprie1"].ToString();
                    Session["AP"].ToString();
                    Session["Bloco"].ToString();
                    Session["Proprie2"].ToString();
                    listaMensagemMoradorBLL();
                    resultadoEnquete();
                    preencheGrid();
                    dvResultado.Visible = false;
                    lblMsg.Visible = false;
                    
                    CultureInfo CI = new CultureInfo("pt-PT");
                    CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

                    Thread.CurrentThread.CurrentCulture = CI;
                    Thread.CurrentThread.CurrentUICulture = CI;
                    base.InitializeCulture();


                    if (Session["mensagem"] != null)
                    {
                        lnkBtnMsg.Text = Session["mensagem"].ToString();
                    }
                    else
                    {
                        lnkBtnMsg.ForeColor = System.Drawing.Color.Red;
                    }
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
                oMensagemModel.status = "1";
                oMensagemModel.oAp = oApModel;

                listaMensagemMorador listaQuantidade = new listaMensagemMorador();

                int contador = 0;

                if (oMensagemBLL.listaMensagemMorador(oMensagemModel).Count > 0)
                {
                    foreach (var item in oMensagemBLL.listaMensagemMorador(oMensagemModel))
                    {

                        contador += Convert.ToInt32(item.qtdMsg);
                        Session["mensagem"] = contador;
                    }
                }
                else
                {
                    Session.Remove("mensagem");
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void lnkBtnMsg_Click(object sender, EventArgs e)
        {

        }

        protected void lnkBtnMsg_Click1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["mensagem"]) >= 1)
            {
                Response.Redirect("detalheMensagemMorador.aspx");

            }
            else
            {
                lnkBtnMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void link1_Click(object sender, EventArgs e)
        {
            listarArquivos("RegimentoInternoAzuli.pdf");
        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            const string scriptString = "<script type='text/javascript'> alert('Desculpe em breve teremos estas informações, acesse o menu acima, obrigado!');</script>";
            ClientScriptManager script = Page.ClientScript;
            script.RegisterClientScriptBlock(GetType(), "randomName", scriptString);
        }

      
        protected void link4_Click(object sender, EventArgs e)
        {
            const string scriptString = "<script type='text/javascript'> alert('Desculpe em breve teremos estas informações, acesse o menu acima, obrigado!');</script>";
            ClientScriptManager script = Page.ClientScript;
            script.RegisterClientScriptBlock(GetType(), "randomName", scriptString);
        }

        protected void lnkDonwload_Click(object sender, EventArgs e)
        {
            listarArquivos("sgcFernandesVilela.pps");
        }


        private void listarArquivos(string nameArquivo)
        {

            try
            {


                string folder = System.Configuration.ConfigurationManager.AppSettings["ArquivosCondominioDownload"];

                FileInfo arquivo = new FileInfo(Server.MapPath(folder) + ("\\" + nameArquivo));

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

        protected void btnVotar_Click(object sender, EventArgs e)
        {

            if (rdlEnquete.SelectedItem != null)
            {
                oEnqueteModel.idEnquete = Convert.ToInt32(rdlEnquete.SelectedValue);
                oEnqueteModel.enqueteDescricao ="";
                oEnqueteModel.resultadoEnquete = 1;
                oApEnquete.apartamento = Convert.ToInt32(Session["AP"]);
                oApEnquete.bloco = Convert.ToInt32(Session["bloco"]);
                oEnqueteModel.oAP = oApEnquete;

                try
                {
                    oEnqueteBLL.cadastraVotacao(oEnqueteModel);
                    lblMsg.Visible = true;
                    lblMsg.Text = "voto feito com sucesso!! Obrigado";

                }
                catch (Exception)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Você já votou nesta Enquete, obrigado!";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Favor escolher umas das opções acima!";
            }

        }

        public void resultadoEnquete()
        {

            double total = 0;
            try
            {
                //Pegar o total de votos
                foreach (var item in oEnqueteBLL.resultadoEnquete())
                {
                    total += item.resultadoEnquete;
                }

                lblTotal.Text = Math.Round(total).ToString();
                double perIndispensabel = 0;
                double perdispensabel = 0;
                double perMuitoImportante = 0;
                double perImportante = 0;
                double perPoucoImportante = 0;

                //Faz o cálculo da votação
                foreach (var item in oEnqueteBLL.resultadoEnquete())
                {
                    switch (item.idEnquete)
                    {
                        case 1: //Indispensável
                            perIndispensabel = (item.resultadoEnquete / total * 100);
                            lblIndispensavel.Text = item.resultadoEnquete + " voto(s), " + "(" +Math.Round(perIndispensabel) +")%";
                            dvIndisp.Style["width"] = Math.Round(perIndispensabel) + "px"; 
                            break;

                        case 2: //Muito importante
                            perMuitoImportante = (item.resultadoEnquete / total * 100);
                            lblMuitoImportante.Text = item.resultadoEnquete + " voto(s), " + "(" +Math.Round(perMuitoImportante) + ")%";
                            dvMuitoImport.Style["width"] = Math.Round(perMuitoImportante) + "px"; 
                            break;

                        case 3: //Importante
                            perImportante = (item.resultadoEnquete / total * 100);
                            lblImportante.Text = item.resultadoEnquete + " voto(s), " + "(" + Math.Round(perImportante) + ")%";
                            dvImportante.Style["width"] = Math.Round(perImportante) + "px"; 
                            break;

                        case 4: //Pouco Importante
                            perPoucoImportante = (item.resultadoEnquete / total * 100);
                            lblPoucoImportante.Text = item.resultadoEnquete + " voto(s), " + "("+ Math.Round(perPoucoImportante) + ")%";
                            dvPoucoImpor.Style["width"] = Math.Round(perPoucoImportante) + "px"; 
                            break;

                        case 5: //Dispensável
                            perdispensabel = (item.resultadoEnquete / total * 100);
                            lblDispensavel.Text = item.resultadoEnquete + " voto(s), " + "(" + Math.Round(perPoucoImportante) + ")%";
                            dvDispen.Style["width"] = Math.Round(perPoucoImportante) + "px"; 
                            break;

                    }
                    
                }
            }
            catch (Exception err)
            {
                
                throw err;
            }
            
        }

        protected void lnkResultado_Click(object sender, EventArgs e)
        {
            resultadoEnquete();
            dvResultado.Visible = true;
            dvEnquete.Visible = false;
                
        }

        

        protected void lnkVoltar_Click1(object sender, EventArgs e)
        {
            dvResultado.Visible = false;
            dvEnquete.Visible = true;
            lblMsg.Visible = false;
            rdlEnquete.ClearSelection();
            
        }


        public static int ArraySorter(ArrayList lista)
        {
            ArrayList arrinput = new ArrayList();
            for (int i = 0; i < lista.Count; i++)
            {
                arrinput.Add(lista[i]);
            }
            Random rnd = new Random();
            int num = rnd.Next(arrinput.Count);
            return Convert.ToInt32(arrinput[num]);
        }

        public void preencheGrid()
        {
            ClassificadoBLL oClassificadoBLL = new ClassificadoBLL();
            Classificados oClassificaModel = new Classificados();
            ArrayList sorteioClassificado = new ArrayList();

            //GrupoClassificados oGrpModel = new GrupoClassificados();
            ApartamentoModel oAp = new ApartamentoModel();

            oClassificaModel.grpClassificado.grupoClassificado = 0;
            oClassificaModel.statusClassificado = "A";
            


            foreach (var item in oClassificadoBLL.consultaClassificado(oClassificaModel))
            {
                
                sorteioClassificado.Add(item.idClassificado);   
            }

            int quantidade = sorteioClassificado.Count;

            int[] numeroSorteado = new int[4];
            if (quantidade < 4)
            {
                
                //Query que tras os dados através de um sorteio.. para mostrar dinamincamente os classificados na página principal;
                grdClassificado.DataSource = from listaClassificados in oClassificadoBLL.consultaClassificado(oClassificaModel)
                                             where listaClassificados.statusClassificado == "A"
                                             orderby listaClassificados.dataClassificado
                                             select listaClassificados;

            }
            else
            {

                for (int i = 0; i < 4; i++)
                {
                    numeroSorteado[i] = paginaInicialMoradores.ArraySorter(sorteioClassificado);
                    sorteioClassificado.Remove(numeroSorteado[i]);
                }


                //Query que tras os dados através de um sorteio.. para mostrar dinamincamente os classificados na página principal;
                grdClassificado.DataSource = from listaClassificados in oClassificadoBLL.consultaClassificado(oClassificaModel)
                                             where listaClassificados.statusClassificado == "A"
                                             && listaClassificados.idClassificado == numeroSorteado[0] || listaClassificados.idClassificado == numeroSorteado[1]
                                             || listaClassificados.idClassificado == numeroSorteado[2] || listaClassificados.idClassificado == numeroSorteado[3]
                                             orderby listaClassificados.dataClassificado
                                             select listaClassificados;

            }
            grdClassificado.DataBind();



        }

        protected void btnClassificados_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("consultaClassificados.aspx");
        }

        
    }
   }
