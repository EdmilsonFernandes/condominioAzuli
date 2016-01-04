using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Azuli.Web.Portal
{
    public partial class RelatorioEmailRecibo : System.Web.UI.Page
    {
        DateTime data = DateTime.Now;
        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSessionAdmin())
                {


                    this.lbtMonth1.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(1).ToUpper();
                    this.lbtMonth2.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(2).ToUpper();
                    this.lbtMonth3.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(3).ToUpper();
                    this.lbtMonth4.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(4).ToUpper();
                    this.lbtMonth5.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(5).ToUpper();
                    this.lbtMonth6.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(6).ToUpper();
                    this.lbtMonth7.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(7).ToUpper();
                    this.lbtMonth8.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8).ToUpper();
                    this.lbtMonth9.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(9).ToUpper();
                    this.lbtMonth10.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(10).ToUpper();
                    this.lbtMonth11.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(11).ToUpper();
                    this.lbtMonth12.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToUpper();
                    preencheAno();
                    drpAno.SelectedItem.Text = data.Year.ToString();
                }
            }


        }

        public void preencheAno()
        {
            int anoAuxiliar = 2010; // irá receber o ano do banco.
            // Pegar o ano anterior de acordo com o ano do ultimo circular publicado, por enquanto está estático.
            for (int ano = data.Year; ano >= anoAuxiliar; ano--)
            {
                drpAno.Items.Add(ano.ToString());
            }

        }

    }
}