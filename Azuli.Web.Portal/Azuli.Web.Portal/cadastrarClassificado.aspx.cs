using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Text;
using System.Globalization;
using System.Threading;

namespace Azuli.Web.Portal
{
    public partial class cadastrarClassificado : System.Web.UI.Page
    {
        Util.Util oUtil = new Util.Util();
        ClassificadoBLL oClassificado = new ClassificadoBLL();
        Classificados oClassificadoModel = new Classificados();
        GrupoClassificados oGrpModel = new GrupoClassificados();
        ApartamentoModel oApModel = new ApartamentoModel();
        double tamanhoArquivo = 0;
        string extensao = "";
        string diretorio = "";
        bool validaImagem1 = false;
        bool validaImagem2 = false;
        bool validaImagem3 = false;
        bool validaImagem4 = false;
        string folder = System.Configuration.ConfigurationManager.AppSettings["classificado"];

        Dictionary<int, string> recebeValida = new Dictionary<int, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                    lblDescBloco.Text = Session["Bloco"].ToString();
                    lblDescApartamento.Text = Session["AP"].ToString();
                    txtFalarCom.Text = Session["Proprie1"].ToString();
                    carregaGrupoClassificado(Convert.ToInt32(Request.QueryString["var"]));
                    txtValor.Attributes.Add("onKeyDown", "this, 10, this.event, 2");
                    CultureInfo CI = new CultureInfo("pt-PT");
                    CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

                    Thread.CurrentThread.CurrentCulture = CI;
                    Thread.CurrentThread.CurrentUICulture = CI;
                    base.InitializeCulture();
                }

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


        public Dictionary<int, string> verificaTamanho(double tamanhoArquivo, string extensao)
        {

            Dictionary<int, string> valores = new Dictionary<int, string>();
            double permitido = 2000;

            if (tamanhoArquivo > permitido)
            {
                valores.Add(1, "Tamanho Máximo permitido é de " + permitido + " kb!");


            }
            else if (extensao.Trim() != ".jpg" && extensao.Trim() != ".png" && extensao.Trim() != ".bmp" && extensao.Trim() != ".gif" && extensao.Trim() != ".ico")
            {
                valores.Add(2, "Extensão inválida, só são permitidas .jpg, .gif , .bmp, .png");

            }
            else
            {
                valores.Add(0, "OK");
            }

            return valores;

        }




        public void publicarImagem1()
        {


            if (FileUpload1.PostedFile.FileName != "")
            {
                string arq = FileUpload1.PostedFile.FileName;
                tamanhoArquivo = Convert.ToDouble(FileUpload1.PostedFile.ContentLength) / 2048;
                extensao = arq.Substring(arq.Length - 4).ToLower();

                recebeValida = verificaTamanho(tamanhoArquivo, extensao);

                foreach (var item in recebeValida)
                {
                    if (item.Key == 0)
                    {
                        diretorio = Server.MapPath(folder);
                        oClassificadoModel.classificadoimg1 = tira_acentos(Session["Bloco"].ToString() + Session["Ap"].ToString() + oUtil.GeraSenha() + arq);

                        if (!System.IO.File.Exists(diretorio))
                        {

                            try
                            {
                                validaImagem1 = true;
                                FileUpload1.PostedFile.SaveAs(Server.MapPath(folder + "/" + oClassificadoModel.classificadoimg1));
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }

                        else
                        {
                            validaImagem1 = false;
                            lblAnuncio.Text = "Este nome de arquivo, já existe na base, por favor escolha outro arquivo ou troque o nome!";
                        }

                    }
                }
            }
            else
            {
                validaImagem1 = true;
                oClassificadoModel.classificadoimg1 = "semimg.jpg";
            }
        }


        public void publicarImagem2()
        {


            if (FileUpload2.PostedFile.FileName != "")
            {
                string arq = FileUpload2.PostedFile.FileName;
                tamanhoArquivo = Convert.ToDouble(FileUpload2.PostedFile.ContentLength) / 2048;

                extensao = arq.Substring(arq.Length - 4).ToLower();

                recebeValida = verificaTamanho(tamanhoArquivo, extensao);

                foreach (var item in recebeValida)
                {
                    if (item.Key == 0)
                    {
                        diretorio = Server.MapPath(folder);
                        oClassificadoModel.classificadoimg2 = tira_acentos(Session["Bloco"].ToString() + Session["Ap"].ToString() + oUtil.GeraSenha() + arq);

                        if (!System.IO.File.Exists(diretorio))
                        {

                            try
                            {
                                validaImagem2 = true;
                                FileUpload2.PostedFile.SaveAs(Server.MapPath(folder + "/" + oClassificadoModel.classificadoimg2));
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }
                        else
                        {
                            validaImagem2 = false;
                            lblAnuncio.Text = "Este nome de arquivo, já existe na base, por favor escolha outro arquivo ou troque o nome!";

                        }

                    }
                    else
                    {
                        validaImagem2 = false;
                        oClassificadoModel.classificadoimg2 = "semimg.jpg";
                    }
                }
            }
            else
            {
                validaImagem2 = true;
                oClassificadoModel.classificadoimg2 = "semimg.jpg";
            }
        }


        public void publicarImagem3()
        {


            if (FileUpload3.PostedFile.FileName != "")
            {
                string arq = FileUpload3.PostedFile.FileName;
                tamanhoArquivo = Convert.ToDouble(FileUpload3.PostedFile.ContentLength) / 2048;

                extensao = arq.Substring(arq.Length - 4).ToLower();

                recebeValida = verificaTamanho(tamanhoArquivo, extensao);

                foreach (var item in recebeValida)
                {
                    if (item.Key == 0)
                    {
                        diretorio = Server.MapPath(folder);
                        oClassificadoModel.classificadoimg3 = tira_acentos(Session["Bloco"].ToString() + Session["Ap"].ToString() + oUtil.GeraSenha() + arq);

                        if (!System.IO.File.Exists(diretorio))
                        {

                            try
                            {
                                validaImagem3 = true;
                                FileUpload3.PostedFile.SaveAs(Server.MapPath(folder + "/" + oClassificadoModel.classificadoimg3));
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }
                        else
                        {
                            validaImagem3 = false;
                            lblAnuncio.Text = "Este nome de arquivo, já existe na base, por favor escolha outro arquivo ou troque o nome!";

                        }

                    }
                    else
                    {
                        validaImagem3 = false;
                        oClassificadoModel.classificadoimg3 = "semimg.jpg";
                    }
                }
            }
            else
            {
                validaImagem3 = true;
                oClassificadoModel.classificadoimg3 = "semimg.jpg";
            }
        }

        public void publicarImagem4()
        {


            if (FileUpload4.PostedFile.FileName != "")
            {
                string arq = FileUpload4.PostedFile.FileName;
                tamanhoArquivo = Convert.ToDouble(FileUpload4.PostedFile.ContentLength) / 2048;

                extensao = arq.Substring(arq.Length - 4).ToLower();

                recebeValida = verificaTamanho(tamanhoArquivo, extensao);

                foreach (var item in recebeValida)
                {
                    if (item.Key == 0)
                    {
                        diretorio = Server.MapPath(folder);
                        oClassificadoModel.classificadoimg4 = tira_acentos(Session["Bloco"].ToString() + Session["Ap"].ToString() + oUtil.GeraSenha() + arq);

                        if (!System.IO.File.Exists(diretorio))
                        {

                            try
                            {
                                validaImagem4 = true;
                                FileUpload4.PostedFile.SaveAs(Server.MapPath(folder + "/" + oClassificadoModel.classificadoimg4));
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }

                        else
                        {
                            validaImagem4 = false;
                            lblAnuncio.Text = "Este nome de arquivo, já existe na base, por favor escolha outro arquivo ou troque o nome!";

                        }

                    }
                    else
                    {
                        validaImagem4 = false;
                        oClassificadoModel.classificadoimg4 = "semimg.jpg";
                    }
                }

            }
            else
            {
                validaImagem4 = true;
                oClassificadoModel.classificadoimg4 = "semimg.jpg";
            }
        }
        protected void btnAnunciar_Click(object sender, EventArgs e)
        {
            publicarImagem1();
            publicarImagem2();
            publicarImagem3();
            publicarImagem4();

            if (validaImagem1 == true && validaImagem2 == true && validaImagem3 == true && validaImagem4 == true)
            {

                oClassificadoModel.descricaoClassificado = txtDescricao.Text;
                oClassificadoModel.emailClassificadoContato = txtEmail.Text;
                oClassificadoModel.classificadoTelefone1 = txtTel.Text;
                oClassificadoModel.classificadoTelefone2 = txtCel.Text;
                oGrpModel.grupoClassificado = Convert.ToInt32(Request.QueryString["var"]);
                oClassificadoModel.grpClassificado = oGrpModel;
                oApModel.bloco = Convert.ToInt32(Session["Bloco"]);
                oApModel.apartamento = Convert.ToInt32(Session["Ap"]);
                oClassificadoModel.apartamentoClassificado = oApModel;
                oClassificadoModel.dataClassificado = DateTime.Now;
                oClassificadoModel.valorVendaClassificado = Convert.ToDouble(txtValor.Text);
                //oClassificadoModel.classificadoDataVenda = DateTime.Now;
                //oClassificadoModel.validadeClassificado = DateTime.Now;
                oClassificadoModel.contato = txtFalarCom.Text;
                oClassificadoModel.statusClassificado = "A";
                oClassificadoModel.assuntoClassificado = txtTitulo.Text;

                if (Util.Util.validaEmail(txtEmail.Text))
                {
                    try
                    {
                        oClassificado.cadastraClassificado(oClassificadoModel);
                        lblAnuncio.Text = "Anúncio feito com sucesso!!";
                        hiddenControl();
                    }
                    catch (Exception err)
                    {
                        lblAnuncio.Text = "Ouve um erro a anunciar!" + err.ToString();
                    }
                }
                else
                {
                    lblAnuncio.Text = "E-mail inválido!";
                }
                
            }
            else
            {
                lblAnuncio.Text = "O arquivo é maior do que o permitido!";
            }


        }

        public void hiddenControl()
        {
            txtCel.Text = "";
            txtDescricao.Text = "";
            txtEmail.Text = "";
            txtValor.Text = "";
            txtTel.Text = "";
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