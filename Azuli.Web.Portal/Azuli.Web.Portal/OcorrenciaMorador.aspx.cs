using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using Azuli.Web.Portal.Util;
using System.Text;

namespace Azuli.Web.Portal
{
    public partial class OcorrenciaMorador : Util.Base
    {
        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        Util.Util oUtil = new Util.Util();
        string arq = "";
        string folder = "";
        Azuli.Web.Model.File oFile = new Azuli.Web.Model.File();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                    lblMsg.Visible = false;
                    lblDescApartamento.Text = Session["AP"].ToString();
                    lblDescBloco.Text = Session["Bloco"].ToString();

                  
                }
                else
                {


                }
            }
        }

        protected void btnOcorrencia_Click(object sender, EventArgs e)
        {

            if (drpListSubject.SelectedItem.Value != "-1")
            {
                LancamentoOcorrenciaModel oLancamento = new LancamentoOcorrenciaModel();
                ApartamentoModel oApartamento = new ApartamentoModel();
                OcorrenciaModel oOcorrencia = new OcorrenciaModel();

                oLancamento.dataOcorrencia = DateTime.Now;
                oLancamento.statusOcorrencia = Util.Util.statusChamado.aberto.ToString().ToUpper();
                oLancamento.descricaoOcorrencia = txtDescription.Text;
                oApartamento.bloco = Convert.ToInt32(Session["Bloco"]);
                oApartamento.apartamento = Convert.ToInt32(Session["AP"].ToString());
                oLancamento.oAp = oApartamento;
                oLancamento.dataFinalizacao = DateTime.Now;
                oLancamento.dataCancelamento = DateTime.Now;

                double tamanhoArquivo = 0;
                double permitido = 1000;
                string erroRegra = "0";
                string extensao = "";
                string diretorio = "";
               

                if (fileImagem.PostedFile.FileName != "")
                {
                    
                     arq = fileImagem.PostedFile.FileName;
                     folder = System.Configuration.ConfigurationManager.AppSettings["EvidenciaMoradorOC"] + "/" + tira_acentos(arq);
                    tamanhoArquivo = Convert.ToDouble(fileImagem.PostedFile.ContentLength) / 1024;

                    extensao = arq.Substring(arq.Length - 4).ToLower();

                    if (tamanhoArquivo > permitido)
                    {
                        this.lblMsg.Text = "Tamanho Máximo permitido é de " + permitido + " kb!";
                        lblMsg.Visible = true;
                        erroRegra = "1";
                    }

                    if (extensao.Trim() != ".jpg" && extensao.Trim() != ".gif" && extensao.Trim() != ".png" && extensao.Trim() != ".bmp")
                    {
                        lblMsg.Text = "Extensão inválida, só são permitidas .jpg, .gif, .png,.bmp";
                        lblMsg.Visible = true;
                        erroRegra = "2";
                    }
                
                    if (erroRegra == "0")
                    {
                        if (!System.IO.File.Exists(diretorio))
                        {
                            fileImagem.PostedFile.SaveAs(Server.MapPath(folder));
                          
                        }
                        else
                        {
                            lblMsg.Text = "Já existe uma imagem com esse nome!, por favor mude o nome do arquivo e tente novamente";
                        }
                    }
                }

                if (erroRegra != "2" && erroRegra != "1")
                {
                    diretorio = Server.MapPath(folder);
                    oLancamento.imagemEvidencia = tira_acentos(arq);
                    oOcorrencia.codigoOcorencia = Convert.ToInt32(drpListSubject.SelectedItem.Value);
                    oLancamento.oOcorrencia = oOcorrencia;

                    try
                    {
                        oProprietario.cadastraOcorrencia(oLancamento);
                        dvCadastro.Visible = false;
                        lblMsg.Visible = true;
                        Session["MensagemCadastro"] = true;
                        Response.Redirect("detalheOcorrencia.aspx");
                       

                    }
                     
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Por favor esolha um assunto!!";
            }
           
            

        }

        public static string tira_acentos(string texto)
        {

            string ComAcentos = "!@#$%¨&*()-?:{}][ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç ";

            string SemAcentos = "_________________AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc_";

            for (int i = 0; i < ComAcentos.Length; i++)

                texto = texto.Replace(ComAcentos[i].ToString(), SemAcentos[i].ToString()).Trim();



            return texto;



        }
    }
}