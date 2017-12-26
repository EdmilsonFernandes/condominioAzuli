<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPortaria.aspx.cs" Inherits="Azuli.Web.Portal.LoginPortaria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/ScriptAzuli.js" type="text/javascript"></script>

     <script>
         (function (d, s, id) {
             var js, fjs = d.getElementsByTagName(s)[0];
             if (d.getElementById(id)) return;
             js = d.createElement(s); js.id = id;
             js.src = "//connect.facebook.net/pt_BR/all.js#xfbml=1";
             fjs.parentNode.insertBefore(js, fjs);
         } (document, 'script', 'facebook-jssdk'));
</script>
    <style type="text/css">
        .style1
        {
            width: 235px;
        }
        #tbPassword
        {
            width: 240px;
        }
        .style2
        {
            font-size: small;
            font-weight: bold;
            color: #0000FF;
        }
    </style>
    </head>
<body>
<div id="fb-root"></div>
    <form id="Form1" runat="server">
    <div class="pageLogin">
        <div class="header">
            <div class="title">
                <div class="title">
                    <img alt="" src="images/sgcv3.jpg" style="height: 86px; width: 965px" />
                </div>
            </div>
        </div>
        <div class="main">
            <br />
            <center>
                <h2>
                    Controle da portaria
                    <asp:Image ID="Image1" runat="server" Height="25px" ImageUrl="~/images/seguranca.jpg"
                        Width="33px" />
                </h2>
                <p>
                    &nbsp;</p>
            </center>
            <center style="height: 464px; width: 936px">
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="LoginUserValidationGroup" Height="43px" Width="427px" />

                <div class="accountInfo" id="dvLogin" runat="server">
                    <fieldset class="login">
                        <legend  class="accordionContent"><span class="style2">Entre com seu Usuário e Senha por favor:</span><br />
                            <br />
                            <br />
                        </legend>
                        <br /><br />
                        <table id="tbPassword" runat="server">
                            <tr>
                                <td class="style1" align="right">
                                   
                                        <asp:Label ID="lblUser" runat="server" Font-Bold="True">Usuário:</asp:Label>
                                        &nbsp;</td>
                                <td class="style1" align="left">
                                   
                                        <asp:TextBox ID="txtUser" runat="server" Width="133px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="requiredBloco" runat="server" ControlToValidate="txtUser"
                                            CssClass="failureNotification" ErrorMessage="Favor Digite seu Bloco!" ToolTip="Favor Digite seu Usúario!"
                                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                 
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" align="right">
                                        <asp:Label ID="lblSenha" runat="server" Font-Bold="True"> Senha:</asp:Label>
                                        &nbsp;
                                </td>
                                <td class="style1" align="left">
                                        <asp:TextBox ID="txtSenha" runat="server" Width="133px" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="requiredAP" runat="server" ControlToValidate="txtSenha"
                                            CssClass="failureNotification" ErrorMessage="Favor informe sua senha"
                                            ToolTip="Favor informe o número do Apartamento" 
                                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" align="center" colspan="2">
                                        &nbsp;<asp:Button ID="LoginButton" 
                                            runat="server" CommandName="Login" 
                                            Text="Entrar" ValidationGroup="LoginUserValidationGroup"
                                CssClass="botao" Width="70px" onclick="LoginButton_Click" />
                                </td>
                            </tr>
                        </table>
                        <p>
                            &nbsp;</p>
                        <p>
                            <asp:LinkButton ID="LinkBtnEsqueci" runat="server" >Esqueci minha senha</asp:LinkButton>
                        </p>
                        
                      <br />
                   
                        <br />
                    </fieldset>
                    <asp:Label ID="lblEsqueciSenha" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                   
                   
                    </div>
            
      
             </div>
        <div class="footerLogin"  >
              
            
        </div>
   
    </form>
</body>
</html>