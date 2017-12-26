using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Configuration;

namespace Azuli.Web.Portal.Util
{
    public class    SendMail
    {

        public void enviaSenha(string mensagem, string proprietario, string emailProprietario, int status)
        {
            string senhaDescriptografada = "";
            string emailMorador = emailProprietario;
            string nomeMorador = proprietario;
            SmtpClient cliente = new SmtpClient();
            Util descriptografaSenha = new Util();
            string emailRemetente = ConfigurationManager.AppSettings["emailRemetente"].ToString();
            string logError = ConfigurationManager.AppSettings["emailErrorSystem"].ToString();
            
            string senhaCriptrografada = ConfigurationManager.AppSettings["pwd"].ToString();

            senhaDescriptografada = descriptografaSenha.SNH(senhaCriptrografada);


            NetworkCredential credencial = new NetworkCredential(emailRemetente, senhaDescriptografada);
            cliente.UseDefaultCredentials = true;
            cliente.Credentials = credencial;
            cliente.EnableSsl = true;

            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;

             MailAddress remetente = new MailAddress(emailRemetente, "Administrador Azuli");

             MailAddress destinatario = null;
            
             if (status != 0)
             {
                  destinatario = new MailAddress(emailMorador, "Sistema Azuli - Error Sistema");
                  MailMessage msgErr = new MailMessage(remetente, destinatario);
                  msgErr.Bcc.Add(logError);
                  msgErr.Bcc.Add("leandrolvilela@gmail.com");
                  msgErr.IsBodyHtml = true;
                  msgErr.Body = mensagem;
                  msgErr.Subject = "Sistema Spazio Campo Azuli";
                  
                 try
                  {
                      cliente.Send(msgErr);

                  }
                  catch 
                  {

                      
                    throw new Exception("Não foi possivel enviar e-mail de acesso para " + emailMorador);
                  }
                
             }
             else
             {
                  destinatario = new MailAddress(emailMorador, nomeMorador);
                  MailMessage msg = new MailMessage(remetente, destinatario);
                  //msg.Bcc.Add("leandrolvilela@gmail.com");
                  msg.Bcc.Add("residencialcampoazuli@gmail.com");
                  msg.Bcc.Add("edmls2008@gmail.com");
                  msg.IsBodyHtml = true;
                  msg.Body = mensagem;
                  msg.Subject = "Sistema Spazio Campo Azuli - Sua Credencial - Agendamento";

                  try
                  {
                      cliente.Send(msg);

                  }
                  catch (Exception)
                  {
                      
                      throw;
                  }
             }

            
        }


        public static void enviaSenhaComAnexo(string mensagem, string proprietario, string emailProprietario, string anexoRecibo)
        {
            string senhaDescriptografada = "";
            string emailMorador = emailProprietario;
            string nomeMorador = proprietario;
            SmtpClient cliente = new SmtpClient();
            Util descriptografaSenha = new Util();
            string emailRemetente = ConfigurationManager.AppSettings["emailRemetente"].ToString();

            string senhaCriptrografada = ConfigurationManager.AppSettings["pwd"].ToString();
            senhaDescriptografada = descriptografaSenha.SNH(senhaCriptrografada);
            NetworkCredential credencial = new NetworkCredential(emailRemetente, senhaDescriptografada);

            cliente.UseDefaultCredentials = true;
            cliente.Credentials = credencial;
            cliente.EnableSsl = true;

            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailAddress remetente = new MailAddress(emailRemetente, "Spazio Campo Azuli");

            MailAddress destinatario = null;

          
            destinatario = new MailAddress(emailMorador, nomeMorador);
               
            MailMessage msg = new MailMessage(remetente, destinatario);
            msg.Attachments.Add(new Attachment(anexoRecibo));
            msg.Bcc.Add("edmls2008@gmail.com");
            msg.Bcc.Add("residencialcampoazuli@gmail.com");
            msg.IsBodyHtml = true;
            msg.Body = mensagem;
            msg.Subject = "Gestão de recibo da Água - Condomínio Azuli";

            try
            {
                cliente.Send(msg);

            }
            catch (Exception e)
            {

                throw e;
            }
         }


        public void enviaEmailCancelamento(string mensagem, string proprietario, string emailProprietario)
        {
            string senhaDescriptografada = "";
            string emailMorador = emailProprietario;
            string nomeMorador = proprietario;
            SmtpClient cliente = new SmtpClient();
            Util descriptografaSenha = new Util();
            string emailRemetente = ConfigurationManager.AppSettings["emailRemetente"].ToString();

            string senhaCriptrografada = ConfigurationManager.AppSettings["pwd"].ToString();
            senhaDescriptografada = descriptografaSenha.SNH(senhaCriptrografada);
            NetworkCredential credencial = new NetworkCredential(emailRemetente, senhaDescriptografada);

            cliente.UseDefaultCredentials = true;
            cliente.Credentials = credencial;
            cliente.EnableSsl = true;

            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailAddress remetente = new MailAddress(emailRemetente, "Spazio Campo Azuli");

            MailAddress destinatario = null;


            destinatario = new MailAddress(emailMorador, nomeMorador);

            MailMessage msg = new MailMessage(remetente, destinatario);
            msg.Bcc.Add("edmls2008@gmail.com");
            msg.Bcc.Add("residencialcampoazuli@gmail.com");
            msg.IsBodyHtml = true;
            msg.Body = mensagem;
            msg.Subject = "Cancelamento de agendamento";

            try
            {
                cliente.Send(msg);

            }
            catch (Exception e)
            {

                throw e;
            }
        }



        



        internal void enviaSenha(string p, string p_2, System.Web.UI.WebControls.TextBox txtEmail, int p_3)
        {
            throw new NotImplementedException();
        }
    }
}