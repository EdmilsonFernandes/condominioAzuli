using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using Azuli.Web.Business;
using System.Net;

namespace Azuli.Web.Portal
{
    public partial class consultaCircularAdministrador : Util.Base
    {
        Util.Util oUtil = new Util.Util();
        FileBLL oFileBLL = new Business.FileBLL();
        Azuli.Web.Model.File oFile = new Azuli.Web.Model.File();
        int ano = DateTime.Now.Year;
        DateTime data = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSessionAdmin())
                {

                    dvArquivosPublicados.Visible = false;
                    btnOk.Visible = false;
                    this.lbtMonth1.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(1).ToUpper();
                    this.lbtMonth2.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(2).ToUpper();
                    this.lbtMonth3.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(3).ToUpper();
                    this.lbtMonth4.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(4).ToUpper();
                    this.lbtMonth5.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(5).ToUpper();
                    this.lbtMonth6.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(6).ToUpper();
                    this.lbtMonth7.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(7).ToUpper();
                    this.lbtMonth8.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8).ToUpper();
                    this.lbtMonth9.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(9).ToUpper();
                    this.lbtMonth10.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(10).ToUpper();
                    this.lbtMonth11.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(11).ToUpper();
                    this.lbtMonth12.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToUpper();
                    preencheAno();
                    drpAno.SelectedItem.Text = data.Year.ToString();
                    CalculateQtdFile();


                }
            }


        }

        public void clearQuantidadeArquivos()
        {

            lblPercentage1.Text = "0";
            lblPercentage2.Text = "0";
            lblPercentage3.Text = "0";
            lblPercentage4.Text = "0";
            lblPercentage5.Text = "0";
            lblPercentage6.Text = "0";
            lblPercentage7.Text = "0";
            lblPercentage8.Text = "0";
            lblPercentage9.Text = "0";
            lblPercentage10.Text = "0";
            lblPercentage11.Text = "0";
            lblPercentage12.Text = "0";

        }

        public void preencheAno()
        {
            int anoAuxiliar = 2010; // irá receber o ano do banco.
            // Pegar o ano anterior de acordo com o ano do ultimo circular publicado, por enquanto está estático.
            for (int ano = data.Year; ano >= anoAuxiliar; ano--)
            {
                drpAno.Items.Add(ano.ToString());
            }

        }

        /// <summary>
        /// Calculates the percentage of all months of the year base.
        /// </summary>
        protected void CalculateQtdFile()
        {
            clearQuantidadeArquivos();

            oFile.ano = Convert.ToInt32(drpAno.SelectedItem.Text);

            Dictionary<int, int> qtdPublicacao = new Dictionary<int, int>();


            try
            {
                qtdPublicacao = oFileBLL.contaArquivoByMeses(oFile);

                if (qtdPublicacao.Count > 0)
                {


                    btnOk.Visible = true;


                    foreach (var item in qtdPublicacao)
                    {
                        if (item.Key == 1)
                        {

                            lblPercentage1.Text = item.Value.ToString();

                        }
                        else if (item.Key == 2)
                        {
                            lblPercentage2.Text = item.Value.ToString();
                        }
                        else if (item.Key == 3)
                        {
                            lblPercentage3.Text = item.Value.ToString();
                        }
                        else if (item.Key == 4)
                        {
                            lblPercentage4.Text = item.Value.ToString();
                        }
                        else if (item.Key == 5)
                        {
                            lblPercentage5.Text = item.Value.ToString();
                        }
                        else if (item.Key == 6)
                        {
                            lblPercentage6.Text = item.Value.ToString();
                        }
                        else if (item.Key == 7)
                        {
                            lblPercentage7.Text = item.Value.ToString();
                        }
                        else if (item.Key == 8)
                        {
                            lblPercentage8.Text = item.Value.ToString();
                        }
                        else if (item.Key == 9)
                        {
                            lblPercentage9.Text = item.Value.ToString();
                        }
                        else if (item.Key == 10)
                        {
                            lblPercentage10.Text = item.Value.ToString();
                        }
                        else if (item.Key == 11)
                        {
                            lblPercentage11.Text = item.Value.ToString();
                        }
                        else if (item.Key == 12)
                        {
                            lblPercentage12.Text = item.Value.ToString();
                        }

                        dvPublicacao.Visible = true;
                        btnOk.Visible = false;
                        lblMsg.Visible = false;
                    }
                }

                else
                {
                    btnOk.Visible = false;
                    dvPublicacao.Visible = false;
                    dvArquivosPublicados.Visible = false;
                    lblMsg.Text = "Não existem arquivos publicados para este ano " + drpAno.SelectedItem.Text;
                    lblMsg.Visible = true;

                }




            }
            catch (Exception)
            {

                throw;
            }





            //Business.Support.TimeSheet busTimeSheet = new Rhodia.Sahs.Business.Support.TimeSheet();

        }





        protected void lbtMonth_Click(object sender, EventArgs e)
        {

            preencheGridListaArquivo(1);
        }

        protected void lbtMonth2_Click(object sender, EventArgs e)
        {

            preencheGridListaArquivo(2);
        }

        protected void lbtMonth3_Click(object sender, EventArgs e)
        {

            preencheGridListaArquivo(3);
        }

        protected void lbtMonth4_Click(object sender, EventArgs e)
        {

            preencheGridListaArquivo(4);
        }

        protected void lbtMonth5_Click(object sender, EventArgs e)
        {

            preencheGridListaArquivo(5);
        }

        protected void lbtMonth6_Click(object sender, EventArgs e)
        {

            preencheGridListaArquivo(6);
        }

        protected void lbtMonth7_Click(object sender, EventArgs e)
        {

            preencheGridListaArquivo(7);
        }
        protected void lbtMonth_Click8(object sender, EventArgs e)
        {

            preencheGridListaArquivo(8);
        }
        protected void lbtMonth_Click9(object sender, EventArgs e)
        {

            preencheGridListaArquivo(9);
        }
        protected void lbtMonth_Click10(object sender, EventArgs e)
        {

            preencheGridListaArquivo(10);
        }
        protected void lbtMonth_Click11(object sender, EventArgs e)
        {

            preencheGridListaArquivo(11);
        }
        protected void lbtMonth_Click12(object sender, EventArgs e)
        {

            preencheGridListaArquivo(12);
        }

        public void preencheGridListaArquivo(int mes)
        {


            oFile.ano = Convert.ToInt32(drpAno.SelectedValue);
            oFile.mes = mes;

            lblmesAno.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes).ToUpper() + "/" + oFile.ano;
            try
            {
                grdCircular.DataSource = oFileBLL.listaArquivoCircular(oFile);
                grdCircular.DataBind();
                dvArquivosPublicados.Visible = true;
                btnOk.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdCircular_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string caminhoDownload = "";

            int index = int.Parse((string)e.CommandArgument);
            caminhoDownload = grdCircular.DataKeys[index]["nameFile"].ToString();

            try
            {

                string strScript = "window.open('MostraPdfCircular.aspx?static_document_id=" + caminhoDownload + "', 'Circular', 'width=900px,height=700px,left=100,top=50,status=1,toolbar=0,location=0,menubar=0,resizable=1,scrollbars=1');";

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Exemplo", strScript, true);


            }
            catch (FileNotFoundException ex)
            {

                throw ex;
            }


        }




        public void listarArquivos(string caminhoArquivo)
        {

            try
            {


                string folder = System.Configuration.ConfigurationManager.AppSettings["ArquivosCondominioDownload"];

                FileInfo arquivo = new FileInfo(Server.MapPath(folder) + ("\\" + caminhoArquivo));
                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(Server.MapPath(folder) + ("\\" + caminhoArquivo));

                if (buffer != null)
                {

                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=file.pdf");

                    HttpContext.Current.Response.ContentType = "application/pdf";

                    HttpContext.Current.Response.BinaryWrite(buffer);

                }

                //Response.AddHeader("Content-Disposition", ("inline; filename=\"" + arquivo.Name));
                //Response.Charset = "utf8";
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.ContentType = "application/octet-stream";
                //Response.AddHeader("Content-Length", arquivo.Length.ToString());
                //Response.WriteFile(arquivo.FullName);
                //Response.Flush();
            }
            catch (FileNotFoundException)
            {

                throw;
            }

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            dvArquivosPublicados.Visible = false;
            btnOk.Visible = false;
        }

        protected void drpAno_SelectedIndexChanged(object sender, EventArgs e)
        {

            CalculateQtdFile();
            dvArquivosPublicados.Visible = false;

        }

    }
}