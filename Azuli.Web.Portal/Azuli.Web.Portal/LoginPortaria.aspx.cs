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

namespace Azuli.Web.Portal
{
    public partial class LoginPortaria : System.Web.UI.Page
    {

        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Session.Clear();

            oAPmodel.apartamento = 99;
            oAPmodel.bloco = 99;
          
            oProprietarioModel.proprietario1 = txtUser.Text;
             oProprietarioModel.senha = txtSenha.Text;


             oAPmodel.oProprietario = oProprietarioModel;
             int valida = oProprietario.autenticaMorador(oAPmodel);




            if (valida != 0)
            {


                foreach (var item in oProprietario.populaProprietario(oAPmodel, oProprietarioModel))
                {
                   
                    Session["Porteiro"] = item.proprietario1.ToString();
                    Session["AP"] = item.ap.apartamento;
                    Session["Bloco"] = item.ap.bloco;
                  
                    if (item.email != null)
                        Session["email"] = item.email.ToString();

                    //  Session["senha"] = item.senha.ToString();
                }

                Response.Redirect("ControlePortaria.aspx");

              
            }
            else
            {
                FailureText.Text = "Usuário e Senha inválida";
                Session.Clear();
            }
        }



    }
}