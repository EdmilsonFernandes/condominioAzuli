using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Drawing;
using System.IO;
using Ionic.Zip;

namespace Azuli.Web.Portal
{
    public partial class integracaoWeb : System.Web.UI.Page
    {
        Util.Util oUtil = new Util.Util();
        #region Properties
        private listaSegundaViaAgua IteropList
        {
            get
            {
                if (ViewState["IteropList"] == null)
                    return new listaSegundaViaAgua();
                else
                    return (listaSegundaViaAgua)ViewState["IteropList"];
            }
            set
            {
                ViewState["IteropList"] = value;
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (oUtil.validateSessionAdmin())
                {
                    string script = "$(document).ready(function () { $('[id*=cmdSave]').click(); });";
                    ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                    hiddenComponent();
                    btnCheck.Visible = true;
                }
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            
            this.lblSaved.Visible = false;
            try
            {

                if (this.fupProject.HasFile)
                {
                  
                    divtabela.Visible = true;
                    Util.ImportFileIntegrationWeb oIntegracao = new Util.ImportFileIntegrationWeb();

                    listaSegundaViaAgua olist = oIntegracao.LoadFile(fupProject.FileContent);

                    var ordenaList = from listaOrdena in olist
                                     orderby listaOrdena.registro ascending
                                     select listaOrdena;

                    IteropList.Clear();
                    IteropList = olist;

                    this.grdImport.DataSource = ordenaList;
                    this.grdImport.DataBind();
                    this.lblTotalRead.Text = olist.Count.ToString();
                    this.cmdSave.Enabled = true;
                    lblMsgError.Visible = false;
                    this.grZip.DataSource = null;
                    this.grZip.DataBind();
                    showComponent();
                    

                }

                else
                {

                    this.lblTotalRead.Text = "0";
                    this.grZip.DataSource = null;
                    this.grZip.DataBind();
                    this.lblMsgError.Text = "No File Uploaded.";
                    lblMsgError.Visible = true;
                    this.cmdSave.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                divtabela.Visible = false;
                lblDescTotalRead.Visible = false;
                lblSaved.Visible = false;
                lblTotalRead.Visible = false;
                cmdSave.Visible = false;
                lblMsgError.Visible = true;
                dvUploadArquivos.Visible = false;
                this.lblMsgError.Text = ex.Message;
               
            }    
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {

            

            ReciboAgua oReciboModel = new ReciboAgua();
            ReciboAguaBLL bussiness = new ReciboAguaBLL();

            oReciboModel.ano = IteropList[1].mes;
            oReciboModel.mes = IteropList[1].ano;

            var contador = bussiness.validaImportacao(oReciboModel);

            if (contador[0].mes == 0)
            {



                // Add Fake Delay to simulate long running process.
                System.Threading.Thread.Sleep(5000);
                //Forech entry found in text file loaded
                for (int c = 0; c < IteropList.Count; c++)
                {

                    try
                    {
                        bussiness.importIntegracaoWeb(IteropList[c]);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }

                this.lblSaved.Visible = true;
                lblSaved.Text = "Integração feita com sucesso Referência - > " + oReciboModel.mes + "/" + oReciboModel.ano;
                divtabela.Visible = false;
                cmdSave.Visible = false;
                lblDescTotalRead.Visible = false;
                lblTotalRead.Visible = false;
                btnCheck.Visible = true;
                dvUploadArquivos.Visible = true;
                this.grZip.DataSource = null;
                this.grZip.DataBind();
            }
            else
            {
                hiddenComponent();
                this.lblSaved.Visible = true;
                this.btnCheck.Visible = true;
                this.lblSaved.ForeColor = Color.Red;
                lblSaved.Text = "já houve integração p/ refêrencia - "+oReciboModel.mes +"/"+oReciboModel.ano;
            }
        }

        public void hiddenComponent()
        {
            divtabela.Visible = false;
            lblDescTotalRead.Visible = false;
            lblSaved.Visible = false;
            lblTotalRead.Visible = false;
            cmdSave.Visible = false;
            btnCheck.Visible = false;
            dvUploadArquivos.Visible = false;
            lblMsgError.Visible = true;
            lnkRecibo.Visible = false;
            lnkRecibo.Visible = false;
        }

        public void showComponent()
        {
            divtabela.Visible = true;
            lblDescTotalRead.Visible = true;
            lblTotalRead.Visible = true;
            cmdSave.Visible = true;
        }

        protected void btnUploadImg_Click(object sender, EventArgs e)
        {
            try
            {
                string path = System.Configuration.ConfigurationManager.AppSettings["imagemRecibo"].ToString();

                string ano = IteropList[1].mes.ToString();
                string mes = IteropList[1].ano.ToString();


                string pasta = ano.Substring(2, 2) + mes;
                path += pasta;

                string serverMap = Server.MapPath(path);

                DirectoryInfo dir = new DirectoryInfo(serverMap);
                if (dir.Exists)
                {

                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('já existe imagens para esta referência- "+pasta+ "')</script>");
                    lblSavedImagen.Visible = false;
                    
                }
                else
                {
                    System.IO.Directory.CreateDirectory(serverMap);


                    if (this.fileUploadImagem.HasFile)
                    {

                        using (ZipFile zip = ZipFile.Read(fileUploadImagem.PostedFile.InputStream))
                        {
                            zip.ExtractAll(serverMap, ExtractExistingFileAction.DoNotOverwrite);

                            var zipOrdenado = from itensUzipados in  zip.Entries
                                              orderby itensUzipados.FileName ascending
                                              select itensUzipados;


                            grZip.DataSource = zipOrdenado;
                            grZip.DataBind();

                            lblRegistros.Text = " " + zip.Count + " arquivos salvos";

                            lblSavedImagen.Visible = true;
                            lnkRecibo.Visible =  true;
                            lblSavedImagen.Text = "Importação das imagens feitas com sucesso. Referência -> " + pasta;


                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }

        protected void lnkRecibo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerarReciboAzuliAdm.aspx");
        }

        }

      

     

            
    }
        
   

