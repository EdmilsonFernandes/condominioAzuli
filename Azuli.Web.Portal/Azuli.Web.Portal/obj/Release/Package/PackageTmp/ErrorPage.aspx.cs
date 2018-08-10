using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azuli.Web.Portal
{
    public partial class ErrorPage : Util.Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ViewState["PreviousPage"] =
                 Request.UrlReferrer;
            }

            string request = Request.UrlReferrer.ToString() ;

            Exception ex = Server.GetLastError();

            if (Session["ErrorDetails"] != null)
            {


                if (Session["ErrorDetails"] != null)
                {
                    lblMessage.Text = Session["ErrorDetails"].ToString();
                }
                else
                {
                    lblMessage.Text = ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "Erro não encontrado";
              
            }

            Server.ClearError();

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
            //contains Previous page URL
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
                //Previous page by retrieving the PreviousPage Url from ViewState.
            }
        }
    }
}