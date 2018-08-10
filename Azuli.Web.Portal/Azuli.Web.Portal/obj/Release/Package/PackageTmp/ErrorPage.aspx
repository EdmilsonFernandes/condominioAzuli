<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Azuli.Web.Portal.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
 
</head>
<body>
    <form id="Form1" runat="server">
   
  
    <div class="page">
        <div class="header">
            <div class="">
             
                     <img alt=""src="images/sgcv3.jpg" 
                         style="height: 86px; width: 959px; margin-left: 0px;" />
               
            </div>

              </div>
              <br /><br />
              
        <div class="main">
         <fieldset> <legend>Página com Problemas</legend>
             <center> 
            <h2>
                &nbsp;</h2>
                 <h2>
                     &nbsp;</h2>
                 <h2>
                &nbsp;<asp:Label ID="lblNotifacao" runat="server" Font-Size="Medium" 
                    Text="Desculpe, ocorreu um erro inesperado no site!!"></asp:Label>
            </h2>
            <h2>
                <asp:Label ID="lblTecnico" runat="server" Text="Resumo Técnico:" 
                    Font-Size="Small"></asp:Label> &nbsp;</h2>
                <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label> &nbsp;<br />
                 <br />
                 <asp:Button 
                     ID="btnHome" runat="server" CssClass="botao" Height="25px" 
                      Text="Home" Width="64px" onclick="btnHome_Click" />
                 </h2>
            <p>
                &nbsp;</p>
                 <p>
                     &nbsp;</p>
                 <p>
                     &nbsp;</p>
                 <p>
                     &nbsp;</p>
                 <p>
                     &nbsp;</p>
                 <p>
                     &nbsp;</p>
                 <p>
                     &nbsp;</p>
                 <p>
                     &nbsp;</p>
                 <p>
                     &nbsp;</p>
            </center>
             </fieldset>
          
        </div>
         
        <div class="clear">
        </div>
    </div>
    <div class="footer">
        
    </div>

    </form>
</body>
</html>