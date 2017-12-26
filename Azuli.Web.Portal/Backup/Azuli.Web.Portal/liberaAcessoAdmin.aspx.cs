using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Text;
using System.Text.RegularExpressions;

namespace Azuli.Web.Portal
{
    public partial class liberaAcessoAdmin : System.Web.UI.Page
    {
        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        Util.Util oUtil = new Util.Util();
        Util.SendMail oEnviaEmail = new Util.SendMail();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oUtil.validateSessionAdmin();

            }
        }


        protected void grdGerenciamentoMoradores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int bloco, apartamento;


            int index = 0;

            index = int.Parse((string)e.CommandArgument);
            bloco = Convert.ToInt32(grdGerenciamentoMoradores.DataKeys[index]["PROPRIETARIO_BLOCO"]);
            apartamento = Convert.ToInt32(grdGerenciamentoMoradores.DataKeys[index]["PROPRIETARIO_AP"]);

            oAPmodel.apartamento = apartamento;
            oAPmodel.bloco = bloco;

            



            //Liberar Acesso
            try
            {
               oProprietario.liberaAcesso(oAPmodel);

               foreach (var item in oProprietario.enviaCrendencialAcesso(oAPmodel))
               {
                   oProprietarioModel.email = item.email;
                   oProprietarioModel.proprietario1 = item.proprietario1;
                   oProprietarioModel.senha = item.senha;
                   oAPmodel.bloco = item.ap.bloco;
                   oAPmodel.apartamento = item.ap.apartamento;
                   oProprietarioModel.ap = oAPmodel;
               }

               StringBuilder msgMorador = new StringBuilder();

               msgMorador.Append("Olá, " + oProprietarioModel.proprietario1);
               msgMorador.Append("<br> Segue abaixo seus dados para acesso <br>");
               msgMorador.Append(" Bloco: " + oProprietarioModel.ap.bloco);
               msgMorador.Append(" <br> Apartamento: " + oProprietarioModel.ap.apartamento);
               msgMorador.Append("<br> Senha: " + oProprietarioModel.senha);
               msgMorador.Append("<br> Acesse Agora: http://www.condominioazuli.somee.com/");

               bool isEmail = Regex.IsMatch(oProprietarioModel.email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

               if (isEmail)
               {
                   oEnviaEmail.enviaSenha(msgMorador.ToString(), oProprietarioModel.proprietario1, oProprietarioModel.email, 0);

               }
               else
               {
                   oEnviaEmail.enviaSenha(msgMorador.ToString(), oProprietarioModel.proprietario1, "residencialcampoazuli@gmail.com", 0);

               }
               
               lblMsg.Text = "Acesso liberado com sucesso! Bloco: " + oProprietarioModel.ap.bloco + " Apartamento: " + oProprietarioModel.ap.apartamento;
               grdGerenciamentoMoradores.DataBind();
            }

            catch (Exception err)
            {
                
                throw err;
            }
        }
    }
}