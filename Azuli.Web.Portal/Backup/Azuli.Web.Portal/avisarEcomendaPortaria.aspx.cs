using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azuli.Web.Portal
{
    public partial class avisarEcomendaPortaria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            //int count = 5;
            //int top = 0;
            //while (count > 0)
            //{
            //    Literal tagBR = new Literal();
            //    Literal divInicio = new Literal();
            //    Literal divFim = new Literal();
            //    Panel pnlBotoes = new Panel();
            //    Button btn = new Button();

            //    divInicio.Text = "<div class=" + count + ">";

            //    divFim.Text = "</div>";
            //    tagBR.Text = "<br/>";
            //    btn.Text = "Texto do botão";
            //    btn.ID = "ID do botão" + count; //Este deve variar também
            //    btn.Width = 100; //Largura
            //    btn.Height = 20; //Altura
            //    btn.Style["Position"] = "Absolute"; //CSS
            //    btn.Style["Top"] = top.ToString() + "px"; //Posição na tela, se não será criado um ao lado do outro
            //    pnlBotoes.Controls.Add(btn);
            //    pnlBotoes.Controls.Add(divInicio);
            //    pnlBotoes.Controls.Add(tagBR);
            //    pnlBotoes.Controls.Add(divFim);

            //    Page.Master.FindControl("MainContent").Controls.Add(pnlBotoes);
            //    // form1.Controls.Add(btn); //Adicionando o botão
            //    btn.Click += new System.EventHandler(this.Button1_Click); //Evento relacionado ao clicar do botão
            //    count = count - 1;
            //    top = top + 20;
            //}
        

        


            Panel pnlBotoes = new Panel();
            Literal fildsetInicio = new Literal();
            Literal tagBR = new Literal();

            Literal fieldFim = new Literal();
            tagBR.Text = "<br/>";
            fildsetInicio.Text = "<fielset class='loginDisplayLegend'> <legend class='accordionContent'>Avisar Morador Encomenda </legend>";
            pnlBotoes.Controls.Add(fildsetInicio);
            for (int i = 1; i <= 40; i++)
            {
                //btn = new Button();
                //btn.ID = "btn" + i.ToString();
                //btn.Text = "txt" + i.ToString();
                //Panel1.Controls.Add(btn);
                Content cont = new Content();
               
                Literal divInicio = new Literal();
                Literal divFim = new Literal();
             




                
               // titulo.ID = "BLOCO" + i.ToString();
               // titulo.Text = "Issue " + i.ToString();
                tagBR.Text = "<br/>";
                Label titulo = new Label();

                Button btn = new Button();
                
                divInicio.Text = "<div class=" + i + ">";

                divFim.Text = "</div>";
            

                tagBR.Text = "<br/>";



                btn.ID = "ButtonIssue" + i.ToString();
                // btn.Click += new EventHandler();
                btn.Text = "AP " + i.ToString();

                btn.Width = 100; //Largura
                btn.Height = 20; //Altura
                btn.Font.Bold = true;
                btn.CssClass = "botao";
                btn.Click += new EventHandler(btn_Click);

               
                pnlBotoes.Controls.Add(divInicio);
                //pnlBotoes.Controls.Add(titulo);
                pnlBotoes.Controls.Add(btn);
                pnlBotoes.Controls.Add(tagBR);
                pnlBotoes.Controls.Add(divFim);
                pnlBotoes.Controls.Add(divFim);


            }
            fieldFim.Text = "</fildset>";
            pnlBotoes.Controls.Add(fieldFim);

            Page.Master.FindControl("MainContent").Controls.Add(pnlBotoes);


        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btnResult = (Button)sender;

            Response.Write(btnResult.ID);
        }


     protected void Button1_Click(object sender, EventArgs e)
     {
            Button btn = (Button)sender;
            Response.Write("<script>alert('O botao apertado foi: " + btn.ID.ToString() + "')</script>");
      }
      
     
    }
}