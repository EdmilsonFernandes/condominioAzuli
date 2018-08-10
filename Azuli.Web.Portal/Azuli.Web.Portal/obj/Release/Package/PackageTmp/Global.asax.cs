using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;


namespace Azuli.Web.Portal
{
    public class Global : System.Web.HttpApplication
    {
     
        void Application_Start(object sender, EventArgs e)
        {

            //log4net.Config.XmlConfigurator.Configure();
            Application["ContadorAcessos"] = 0;

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            StringBuilder corpoEmail = new StringBuilder();

            string ambiente = System.Configuration.ConfigurationManager.AppSettings["ambiente"].ToString();

            
            
            Exception ex = Server.GetLastError();
            if (ex.GetType() != typeof(HttpException))
            {

               
              
                Util.SendMail logError = new Util.SendMail();

                string paginaAtual = Request.CurrentExecutionFilePath;

                HttpContext ctx = HttpContext.Current;

                corpoEmail.Append("<html>");
				corpoEmail.Append("<head>");
				corpoEmail.Append("<style type='text/css'>");
				corpoEmail.Append("	A{text-decoration:none;}");
				corpoEmail.Append("	A.linkbranco{text-decoration:none;color:white}");
				corpoEmail.Append("	A.ind:hover{text-decoration:underline}");
				corpoEmail.Append("	.preto{font-family:tahoma,sans-serif;font-size:12px;color:#000000;}");
				corpoEmail.Append("	.pretog	{font-family:tahoma,sans-serif;font-size:13px;color:#000000;}");
				corpoEmail.Append(".sbd		{font-family:tahoma,sans-serif;font-size:11px;color:blue;line-height: 11px}");
				corpoEmail.Append("</style>");
				corpoEmail.Append("</head>");
				corpoEmail.Append("<body bgcolor='#FFFFFF' leftmargin=5 topmargin=5>");
				corpoEmail.Append("<table border='0' cellspacing='0' cellpadding='5' width='610'>");
				corpoEmail.Append("<tr>");
				corpoEmail.Append("	<td valign='top'>--------------------------------------------</td>");
				corpoEmail.Append("</tr>");
				corpoEmail.Append("<tr><td valign=top><font class='sbd'>IP, " + Request.UserHostAddress.ToString() + " Página - "  + paginaAtual.Remove(0,paginaAtual.LastIndexOf("/") + 1)

+ "!</td></tr>");
				corpoEmail.Append("<tr><td valign=top><font class='sbd'>Error - " + ex.Message.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>Error - " + ex.StackTrace.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>Detalhes do Erro - " + ex.InnerException.Message.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>URL - " + Request.Url.AbsoluteUri.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>Stack Trace - " + ex.InnerException.StackTrace.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>Host Name: : - " + Request.UserHostName.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>User Agent: - " + Request.UserAgent.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>URL Referrer: - " + Request.UrlReferrer.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>UserName - " + Request.LogonUserIdentity.Name.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>Method - " + ex.TargetSite.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>Source - " + ex.Source.ToString() + " :</td>");
                corpoEmail.Append("<tr><td valign=top><font class='sbd'>UserName:: <b>" + System.Web.HttpContext.Current.Session["AP"] + "</b></td>");
				corpoEmail.Append("<tr><td valign=top><font class='sbd'>Bloco: <b>" + System.Web.HttpContext.Current.Session["Bloco"] +"</b></td>");
				corpoEmail.Append("<tr><td valign=top><font class='sbd'>Data:" + DateTime.Now + "</td></tr>");
				corpoEmail.Append("<tr><td valign=top><font class='sbd'>Spazio Azuli</td></tr>");
				corpoEmail.Append("<tr>");
				corpoEmail.Append("	<td valign='top'>---------------------------------------------</td>");
				corpoEmail.Append("</tr>");
				corpoEmail.Append("</table>");
                if (ambiente == "DEV")
                {
                    corpoEmail.Append("<b><h2><font color='red'> ERRO NO AMBIENTE DE DESENVOLVIMENTO</font></h2></b> ");
                    corpoEmail.Append("<b>DatabaseName: AzuliPortal</b> - Login: edmls34_SQLLogin_1 - Password - 25pdqsl4ih<br> ");
                    corpoEmail.Append("<b>Connection String: workstation id=PORTALAZULI.mssql.somee.com;packet size=4096;user id=edmls34_SQLLogin_1;pwd=25pdqsl4ih;data source=PORTALAZULI.mssql.somee.com;persist security info=False;initial catalog=PORTALAZULI</b><br> ");
                    corpoEmail.Append("<b>Application Name: azuli.somee.com</b><br> ");
                    corpoEmail.Append("<a href='http://www.azuli.somee.com'>http://www.azuli.somee.com/ </a> ");
                }
                else
                {
                    corpoEmail.Append("<b><h2><font color='red'>ERRO NO AMBIENTE DE PRODUÇÃO</font></h2></b> ");
                    corpoEmail.Append("<b>DatabaseName: PORTALAZULI</b> - Login: edmls34_SQLLogin_1 - Password - 25pdqsl4ih<br> ");
                    corpoEmail.Append("<b>Connection String: workstation id=AzuliPortal.mssql.somee.com;packet size=4096;user id=edmls34_SQLLogin_1;pwd=25pdqsl4ih;data source=AzuliPortal.mssql.somee.com;persist security info=False;initial catalog=AzuliPortal</b><br> ");
                    corpoEmail.Append("<b>Application Name: azulicondominio.somee.com</b><br> ");
                    corpoEmail.Append("<a href='http://condominiospazioazuli.somee.com/LoginAzulli.aspx'>http://condominiospazioazuli.somee.com/LoginAzulli.aspx </a> ");
                }
				
				corpoEmail.Append("</body>");
				corpoEmail.Append("</html>");


                logError.enviaSenha(corpoEmail.ToString(), "Log Error:", "edmls@ig.com.br", 1);

                Session["ErrorDetails"] = ex.InnerException + " / " + ex.Message;
                Response.Redirect("ErrorPage.aspx");

                
            }

        }

        void Session_Start(object sender, EventArgs e)
        {
            Application["ContadorAcessos"] = (int)(Application["ContadorAcessos"]) + 1;

        }

        void Session_End(object sender, EventArgs e)
        {

            Application["ContadorAcessos"] = (int)(Application["ContadorAcessos"]) - 1;
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
