using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Configuration;
using Azuli.Web.Portal.Util;



namespace Azuli.Web.Portal.Account
{
    public partial class LoginAzulli : Util.Base
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Page.Request.ServerVariables["http_user_agent"].ToLower().Contains("safari"))
            {
                Page.ClientTarget = "uplevel";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("blocoMorador");
            if(cookie.Value != null)
                drpBloco.SelectedItem.Text = cookie.Value.ToString();

            hiddenControl();
            string id = ConfigurationManager.AppSettings["GoogleAnalyticsId"];

            if (!string.IsNullOrEmpty(id))
            {
                string script = "";

                script += "<script type=\"text/javascript\">";

                script += "var _gaq = _gaq || [];";
                script += "_gaq.push(['_setAccount', '" + id + "']);";
                script += "_gaq.push(['_trackPageview']);";

                script += "(function() {";
                script += "  var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;";
                script += "  ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';";
                script += "  var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);";
                script += "})();";

                script += "</script>";






                //ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageAlert",
                //  "<script language=\"JavaScript\">" + Environment.NewLine +
                //  "alert(\'" + "TEST" + "\');" + Environment.NewLine +
                //  "</script>", false);


                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageAlert", script, false);


            }
        }


        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        Util.Util oUtil = new Util.Util();
     

        protected void Page_Load(object sender, EventArgs e)
        {

            hiddenControl();
            Session.Clear();
            Session.Abandon();

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

          

            HttpCookie cookie = new HttpCookie("blocoMorador");
            cookie.Value = drpBloco.SelectedItem.Text;
            cookie.Expires = DateTime.Now.AddDays(365); this.Page.Response.AppendCookie(cookie);
            Response.Cookies.Add(cookie);

           




            Session.Clear();

            oAPmodel.apartamento = Convert.ToInt32(txtAP.Text);
            oAPmodel.bloco = Convert.ToInt32(drpBloco.Text);
            oProprietarioModel.senha = Password.Text;

            Session["AP"] = Convert.ToInt32(txtAP.Text);
            Session["Bloco"] = Convert.ToInt32(drpBloco.Text);


            oAPmodel.oProprietario = oProprietarioModel; 


            int valida = oProprietario.autenticaMorador(oAPmodel);

            


            if (valida != 0)
            {


                foreach (var item in oProprietario.populaProprietario(oAPmodel))
                {
                    Session["AP"] = item.ap.apartamento;
                    Session["Bloco"] = item.ap.bloco;
                    Session["Proprie1"] = item.proprietario1.ToString();
                    Session["Proprie2"] = item.proprietario2.ToString();
                    if (item.email != null)
                        Session["email"] = item.email.ToString();

                    //  Session["senha"] = item.senha.ToString();
                }

                if (Session["AP"].ToString() == "0" && Session["Bloco"].ToString() == "0")
                {
                    Response.Redirect("WelcomeAdmin.aspx");
                }
                else
                {

                    if (Session["AP"].ToString() != "301" && Session["Bloco"].ToString() != "6")
                    {
                        Util.SendMail oEmail = new SendMail();
                        oEmail.enviaSenha("Acesso feito com sucesso para o apartamento/bloco " + Session["AP"].ToString() + " - " + Session["Bloco"].ToString(), "Acessos", "residencialcampoazuli@gmail.com", 0);
                        //logger.Info("Acesso feito com sucesso para o apartamento/bloco " + Session["AP"].ToString() + " - " + Session["Bloco"].ToString());
                        Response.Redirect("~/paginaInicialMoradores.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/paginaInicialMoradores.aspx");
                      //  logger.Warn("Acesso negado!");
                    }


                }
            }
            else
            {
                FailureText.Text = "Número do Apartamento ou senha inválida";
                Session.Clear();
            }

        }

        protected void lnkBtnTeste_Click(object sender, EventArgs e)
        {
            dvLogin.Visible = false;
            dvDadosMorador.Visible = true;
        }

        protected void lnkBtnEsqueci_Click(object sender, EventArgs e)
        {




            if (txtAP.Text != string.Empty && drpBloco.Text != string.Empty)
            {
                Session["AP"] = Convert.ToInt32(txtAP.Text);
                Session["Bloco"] = Convert.ToInt32(drpBloco.Text);
                Response.Redirect("~/esqueciSenha.aspx");

            }
            else
            {
                lblEsqueciSenha.Text = "Favor preencher <b><font color='#4884CD'> Bloco e Apartamento </font> e clique novamente 'Esqueci minha Senha'!!";
            }


        }

        public void enviaMail()
        {

            SendMail enviaEmail = new SendMail();

            try
            {
                int status = 0;

                string mensagem = "Solicitação de Acesso Ap: " + txtSolicitaAP.Text + " Bloco " + drpBlocoSolicita.SelectedItem.Text + "Email " + txtEmail.Text + " Nome " + txtNome.Text;

                enviaEmail.enviaSenha(mensagem, txtNome.Text, "edmls@ig.com.br", status);

                lblMsg.Text = "<b> <font color=green>Solicitação enviada com sucesso, no prazo de algumas horas você receberá seu acesso por e-mail </b></font>";


            }
            catch (Exception ex)
            {

                lblMsg.Text = "<b> <font color=green>Erro ao solicitar acesso,verifique os dados e tente novamente </b></font> </br>" + ex.Message;
            }
            finally
            {
                lblMsg.Visible = true;
            }
        }

        protected void btnOkPesquisa_Click(object sender, EventArgs e)
        {


            oProprietarioModel.ap = new ApartamentoModel();
            oAPmodel.apartamento = Convert.ToInt32(txtSolicitaAP.Text);
            oAPmodel.bloco = Convert.ToInt32(drpBlocoSolicita.SelectedItem.Text);//Convert.ToInt32(txtSolicitaBloco.Text);
            oProprietarioModel.ap = oAPmodel;

            if (Util.Util.validaEmail(txtEmail.Text))
            {

                if (oProprietario.BuscaMoradorAdmin(oAPmodel).Count == 0)
                {

                    oProprietarioModel.proprietario1 = txtNome.Text;
                    oProprietarioModel.proprietario2 = "";

                    oProprietarioModel.email = txtEmail.Text;
                    oProprietarioModel.senha = oUtil.GeraSenha();

                    try
                    {
                        int count = oProprietario.CadastrarApartamentoMorador(oProprietarioModel);

                        if (count > 0)
                        {

                            lblMsg.Text = "Já existe cadastro para o Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento;

                        }

                        else
                        {
                             enviaMail();
                             SendMail enviaEmail = new SendMail();
                             int status = 0;
                             string msgCredencial = "";
                             msgCredencial = "Solicitação de acesso favor verificar na área administrativa -> liberar acessos";
                             enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1,"edmls@ig.com.br", status);
                            dvDadosMorador.Visible = true;
                            lblMsg.Text = "Solicitação efetuada com sucesso!! Em breve você irá receber sua senha no e-mail informado <br> <b> ";
                            txtNome.Text = "";
                            txtEmail.Text = "";
                            txtSolicitaAP.Text = "";
                            drpBlocoSolicita.SelectedItem.Text = "1";

                        }

                    }
                    catch (Exception ex)
                    {
                        //logger.Error(ex.StackTrace);
                        throw ex;
                    }
                }
                else
                {
                    dvDadosMorador.Visible = true;
                    lblMsg.Text = "Já existe cadastro para o Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento;
                }
            }
            else
            {
                dvDadosMorador.Visible = true;
                lblMsg.Text = "E-mail inválido, favor verificar";
            }


        }

        protected void btnCancel0_Click1(object sender, EventArgs e)
        {

            hiddenControl();
            txtSolicitaAP.Text = "";
            drpBlocoSolicita.SelectedIndex = -1;
            txtEmail.Text = "";
            Response.Redirect("LoginAzulli.aspx");
        }

        public void hiddenControl()
        {
            dvDadosMorador.Visible = false;

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://www.facebook.com/Sgcondominio");
        }
    }
}
