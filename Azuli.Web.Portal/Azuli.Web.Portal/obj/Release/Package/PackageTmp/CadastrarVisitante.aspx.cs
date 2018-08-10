using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.IO;
using System.Configuration;

namespace Azuli.Web.Portal
{
    public partial class CadastrarVisitante : System.Web.UI.Page
    {
        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        Visitante oVisitanteModel = new Visitante();
        VisitanteBLL oVisitanteBLL = new VisitanteBLL();
        Foto ofotoModel = new Foto();
        FotoBLL oFotoBll = new FotoBLL();
        string path = ConfigurationManager.AppSettings["uploadFotoWebCam"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                // Image1.ImageUrl = "";
            

                string Dir = HttpContext.Current.Server.MapPath(path);
                string FileName = String.Format("{0:ddMMyyyyhhmmss}.jpg", DateTime.Now);

                string CompleteFileName = String.Format("{0}\\{1}", Dir, FileName);
                byte[] buffer = null;


                FileInfo informacaoArquivo = new FileInfo(CompleteFileName);




                using (FileStream fs = informacaoArquivo.Open(FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    buffer = new byte[HttpContext.Current.Request.InputStream.Length];
                    if (buffer.Length != 0)
                    {
                        Request.InputStream.Read(buffer, 0, (int)HttpContext.Current.Request.InputStream.Length);
                        fs.Write(buffer, 0, buffer.Length);
                    }
                }




                if (buffer.Length != 0)
                {
                    // Image1.ImageUrl = "~/ServerFile/FotosWebCam/"+FileName;
                    //Image1.Visible = true;
                    Response.ContentType = ".jpg";
                    Response.BinaryWrite(buffer);

                    string URLSaida = String.Format("{0}://{1}{2}{3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.GetComponents(UriComponents.HostAndPort, UriFormat.Unescaped), "/ServerFile/FotosWebCam/", FileName);
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Write(URLSaida);
                }

                // HttpContext.Current.Session["buffer"] = Dir+ FileName;

                //   context.Response.ContentType = ".jpg";
                //  context.Response.BinaryWrite(buffer);

                //  HttpContext.Current.Response.Redirect("CadastrarVisitante.aspx");


            }

            catch
            {
                //HttpContext.Current.Response.Clear();
                Response.Write("ERROR: Erro ao salvar imagem\n");
            }








            //  Session["buffer"].ToString();



        }

        protected void drpBloco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drpMsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscaMorador();
        }

        public void buscaMorador()
        {

            string nomeMorador = "";



            oAPmodel.apartamento = Convert.ToInt32(drpMsg.SelectedItem.Text);
            oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedItem.Text);

            if (oProprietario.BuscaMoradorAdmin(oAPmodel).Count > 0)
            {

                foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
                {

                    lblMorador.Text = item.proprietario1.ToString();
                    nomeMorador = item.proprietario1.ToString();


                }
            }

            else
            {
               
                nomeMorador = "Não existe morador cadastrado!";
                lblMorador.Text = "Não existe morador cadastrado!";
            }

        }


        public void cadastarVisitante()
        {
            Dictionary<int, byte[]> lastIdFoto = new Dictionary<int, byte[]>();

            lastIdFoto = oFotoBll.lastIdFotoSaved();

            if (lastIdFoto.Keys.Count > 0)
            {


                oVisitanteModel.visitanteNome = txtBoxNome.Text;
                oVisitanteModel.visitanteRG = txtBoxRG.Text;
                oVisitanteModel.visitanteTipo = rblTipoVisita.SelectedItem.Selected.ToString();
                foreach (var item in lastIdFoto)
                {

                    ofotoModel.idFoto = item.Key;
                }

                oVisitanteModel.idFoto = ofotoModel;

                try
                {

                    oVisitanteBLL.cadastraVisitante(oVisitanteModel);
                    //  Image1.ImageUrl = "~/MostraFoto.ashx";
                    Session.Remove("ID_ATUAL");

                }
                catch (Exception)
                {

                    throw;
                }

            }


        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            cadastarVisitante();
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

    }
}