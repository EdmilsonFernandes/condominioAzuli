using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Model;
using System.IO;
using System.Collections;
using Azuli.Web.Business;
namespace Azuli.Web.Portal

{
    public partial class circular : Util.Base
    {
        DateTime data = DateTime.Now;
        Util.Util oUtil = new Util.Util();
        Azuli.Web.Model.File oFile = new Azuli.Web.Model.File();
        FileBLL oFileBLL = new Business.FileBLL(); 
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (oUtil.validateSessionAdmin())
            {
                if (!IsPostBack)
                {
                    
                    preencheMeses();
                    drpMes.SelectedIndex = data.Month - 1;
                    //drpMes.Enabled = false;
                    preencheAno();

                }
            }
        }

       


        public void preencheMeses()
        {
            string mesCorrente = "";
            drpMes.DataSource = Enum.GetNames(typeof(Util.Util.meses));
           


            mesCorrente = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(data.Month);

            drpMes.Items.Add(mesCorrente); //drpMeses.Items.IndexOf(drpMeses.Items.FindByValue(data.Month.ToString()));
            drpMes.DataBind();
        }

        public void preencheAno()
        {

            for (int ano = 2012; ano < 2020; ano++)
            {
                drpAno.Items.Add(ano.ToString());
            }

        }

        public int validaPublicacao( Azuli.Web.Model.File oFile)
        {
            int qtdPublicacao = 0; 
            try
            {
               qtdPublicacao = oFileBLL.validaCircular(oFile);

            }
            catch (Exception)
            {
                
                throw;
            }

            return qtdPublicacao;
        }

        protected void btnPublicar_Click(object sender, EventArgs e)
        {
           
            double tamanhoArquivo = 0;
            double permitido = 1000;
            string erroRegra = "0";
            string extensao = "";
            string diretorio = "";

            if (fileWord.PostedFile.FileName != "")
            {
                string arq = fileWord.PostedFile.FileName;
                tamanhoArquivo = Convert.ToDouble(fileWord.PostedFile.ContentLength) / 2048;

                 extensao = arq.Substring(arq.Length - 4).ToLower();

                if (tamanhoArquivo > permitido)
                {
                    this.lblMsg.Text = "Tamanho Máximo permitido é de " + permitido + " kb!"; 
                    erroRegra = "1";
                }
                if (extensao.Trim() != ".doc" && extensao.Trim() != ".xls" && extensao.Trim() != "docx" && extensao.Trim() != "xlsx" && extensao.Trim() != ".pdf")
                {
                    lblMsg.Text = "Extensão inválida, só são permitidas .doc, .docx, .xls,.xlsx, pdf";
                    erroRegra = "2";
                }
              
                string folder = System.Configuration.ConfigurationManager.AppSettings["ArquivosCondominio"] + "/" +tira_acentos(arq);
                diretorio = Server.MapPath(folder);
                oFile.nameFile = tira_acentos(arq);

                List<Util.Util.meses> lista = Enum.GetValues(typeof(Util.Util.meses)).Cast<Util.Util.meses>().ToList();

                string mesEscolhido = "";
                foreach (var item in lista)
                {

                    mesEscolhido = item.ToString();

                    if (mesEscolhido == drpMes.SelectedItem.Value)
                    {
                        oFile.mes = Convert.ToInt32(item);
                    }


                }

                oFile.assunto = txtAssunto.Text;

                oFile.ano = Convert.ToInt32(drpAno.SelectedItem.Value);
                oFile.areaPublicacao = (int)Util.Util.paginaPublicada.circular;

                if (erroRegra == "0")
                {


                    try
                    {

                        if (!System.IO.File.Exists(diretorio))
                        {



                            oFileBLL.publicarArquivo(oFile);

                            fileWord.PostedFile.SaveAs(Server.MapPath(folder));


                            lblMsg.Text = "Arquivo publicado com sucesso!!";
                        }
                        else
                        {
                            lblMsg.Text = "Já existe um arquivo com esse nome!, por favor mude o nome do arquivo e tente novamente";
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {

                }

            }
            else
            {
                lblMsg.Text = "Não existe arquivo selecionado!!";
            }
          

            //else
            //{
            //    lblMsg.Text = "Já existe Circular publicado o mês: " + oFile.mes + " e ano: " + oFile.ano;
            //}
           
           
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