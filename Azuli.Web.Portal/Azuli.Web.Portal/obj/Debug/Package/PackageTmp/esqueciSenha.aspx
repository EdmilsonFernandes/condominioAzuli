<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="esqueciSenha.aspx.cs" Inherits="Azuli.Web.Portal.esqueciSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/ScriptAzuli.js" type="text/javascript"></script>
 
    <style type="text/css">
        .style1
        {
            color: #4884CD;
            font-weight: bold;
        }
    </style>
 
</head>
<body>
    <form id="Form1" runat="server">
    <div class="page">
        <div class="header">
            <div class="title">
                <div class="title">
                
                <img src="images/sgcv3.jpg" style="height: 100px; width: 1070px;border-radius: 1em"/>
           
            </div>
             
            </div>

              </div>
        <div class="main">
       <p></p>
            <asp:Button ID="btnHome" runat="server" CssClass="botao" 
                        Text="Voltar" onclick="btnHome_Click" Height="18px" Width="67px" />
    <br /><br /><br />
 
<fieldset>
   
    <legend title="Abrir Ocorrência" class="accordionContent"> Solicitação de senha para: <span class="style1">&nbsp;Bloco:
        <asp:Label ID="lblBloco" runat="server"></asp:Label>
&nbsp;Apartamento:
        <asp:Label ID="lblAp" runat="server"></asp:Label>
        </span></legend><br />
   
      
  <center> <h3>ESQUECI A SENHA</h3></center><br />
  <center>
   
        
        <table class="accordionContent" dir="ltr" frame="border" 
            style="width: 432px; height: 101px;" >
            <tr>
                <td>
                   
                    <asp:Label ID="Label2" runat="server" Text="Informe seu e-mail:"></asp:Label>
                </td>
                <td class="style1">
                    <br />
                    <asp:TextBox ID="txtEm" runat="server" Height="21px" Width="274px" 
                        style="margin-left: 0px" ValidationGroup="esqueciSenha"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEsqueciSenha" runat="server" 
                        CssClass="failureNotification" ErrorMessage="*" ValidationGroup="esqueciSenha" 
                        ControlToValidate="txtEm"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnEsqueci" runat="server" CssClass="botao" 
                        Text="Solicitar Senha" onclick="btnEsqueci_Click" 
                        ValidationGroup="esqueciSenha" />
                </td>
            </tr>
            <tr>
               
            </tr>
        </table>
</center>
    
   <center>
       <br />
       <br />
       <asp:Label ID="lblMsg" runat="server" CssClass="modalHeader" Visible="False"></asp:Label></center> 
     
                 
    </div>
     
       <div class="footer">
   
      © FernandesVilela Soluções de TI. INC 2013. Todos os direitos reservados 
           <a href="mailto:edmls@ig.com.br">
               <img src="images/correio.jpg" style="height: 17px; width: 29px" /></a> 

    </div>
        </div>
         </fieldset>
 
    </form>

 
</body>
</html>







