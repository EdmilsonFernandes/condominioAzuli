using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Reflection;

namespace Azuli.Web.Portal
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {


            if (!IsPostBack)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();



                Attribute copyright = AssemblyCopyrightAttribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute));
                if (copyright != null)
                    this.lblCopyright.Text = ((AssemblyCopyrightAttribute)copyright).Copyright;

                this.lblVersion.Text = string.Format(assembly.GetName().Version.ToString());

                lblApDesc.Text = Session["AP"].ToString();
                lblBlocoMasterDesc.Text ="0"+Session["Bloco"].ToString();
              

                lblProprietarioDesc.Text = Session["Proprie1"].ToString();

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
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }
           
        
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("http://camarasjc.sp.tempsite.ws/clicknow/telefones-uteis/");
        }

        public void checkPage()
        {

           
        }
    }





}
