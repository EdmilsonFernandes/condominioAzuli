<%@ Page Language="C#"  Title="Portal do Condiminio" AutoEventWireup="true" CodeBehind="LoginAzulli.aspx.cs" Inherits="Azuli.Web.Portal.Account.LoginAzulli" %>

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
   <link href="css/bootstrap-responsive.css" rel="stylesheet">
	<link href="css/charisma-app.css" rel="stylesheet">
	<link href="css/jquery-ui-1.8.21.custom.css" rel="stylesheet">
	<link href='css/fullcalendar.css' rel='stylesheet'>
	<link href='css/fullcalendar.print.css' rel='stylesheet'  media='print'>
	<link href='css/chosen.css' rel='stylesheet'>
	<link href='css/uniform.default.css' rel='stylesheet'>
	<link href='css/colorbox.css' rel='stylesheet'>
	<link href='css/jquery.cleditor.css' rel='stylesheet'>
	<link href='css/jquery.noty.css' rel='stylesheet'>
	<link href='css/noty_theme_default.css' rel='stylesheet'>
	<link href='css/elfinder.min.css' rel='stylesheet'>
	<link href='css/elfinder.theme.css' rel='stylesheet'>
	<link href='css/jquery.iphone.toggle.css' rel='stylesheet'>
	<link href='css/opa-icons.css' rel='stylesheet'>
	<link href='css/uploadify.css' rel='stylesheet'>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            font-size: x-small;
        }
        .style4
        {
            color: #0092D2;
        }
        .style5
        {
            width: 67px;
            height: 23px;
        }
        #tbPassword
        {
            width: 309px;
        }
    </style>
</head>
<body>
<div id="fb-root" class="container-fluid"></div>
    <form id="Form1" runat="server">
    <div class="pageLogin">
        <div class="header">
            <div class="title">
                <div class="title">
                    <img alt="" src="images/sgcv3.jpg" style="height: 100px; width: 965px;border-radius: 1em" />
                </div>
            </div>
        </div>
        <div class="main">
            <br /><br />
            <center>
                <h2>
                    Tela de Acesso
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
                <div class="row-fluid" id="dvLogin" runat="server">
                    <fieldset class="login">
                        <legend  class="accordionContent">Entre com seu Bloco/Apartamento e Senha:</legend>
                        <table id="tbPassword" class="accordionContent"  runat="server" frame="border">
                            <tr>
                                <td>
                                    <p>
                                        <asp:Label ID="UserNameLabel" runat="server" Font-Bold="True" 
                                            style="font-size: medium" CssClass="style4">Bloco: </asp:Label>
                                        &nbsp;<asp:DropDownList ID="drpBloco" runat="server" Height="25px" Width="52px" 
                                            style="font-size: medium; font-weight: 700;" 
                                            CssClass="AlternatingRowStyle">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="requiredBloco" runat="server" ControlToValidate="drpBloco"
                                            CssClass="failureNotification" ErrorMessage="Favor Digite seu Bloco!" ToolTip="Favor Digite seu Bloco!"
                                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </p>
                                </td>
                                <td align="left">
                                    <p>
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                                            style="font-size: medium" CssClass="style4">AP: </asp:Label>
                                        <asp:TextBox ID="txtAP" runat="server" onKeyPress="return Decimal(this,event);" 
                                            CssClass="textEntry" Width="40px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="requiredAP" runat="server" ControlToValidate="txtAP"
                                            CssClass="failureNotification" ErrorMessage="Favor informe o número do Apartamento"
                                            ToolTip="Favor informe o número do Apartamento" ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </p>
                                </td>

                              
                            </tr>
                            <tr>
                              <td colspan="2" align="center">
                                 <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                                      Font-Bold="True" CssClass="style4">Senha
                               </asp:Label>
                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" 
                                      TextMode="Password" Width="92px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                CssClass="failureNotification" ErrorMessage="Favor digite sua senha!" ToolTip="Favor digite sua senha!"
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                
                                </td>
                            
                            </tr>
                            <tr align="center">
                            <td colspan="2" align="center">
                             &nbsp;<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="LoginUserValidationGroup"
                                CssClass="botao" OnClick="LoginButton_Click" Width="65px" />
                            </td>
                            </tr>
                        </table>
                        <p>
                           
                        </p>
                        <p>
                           
                        </p>
                        <p>
                            <asp:LinkButton ID="LinkBtnEsqueci" runat="server" OnClick="lnkBtnEsqueci_Click">Esqueci minha senha</asp:LinkButton>
                        </p>
                        <asp:LinkButton ID="lnkBtnTeste"  CssClass="btn" runat="server" OnClick="lnkBtnTeste_Click">Solicite aqui seu Acesso!</asp:LinkButton>
                        <br />
                   
                        <br />
                    </fieldset>
                    <asp:Label ID="lblEsqueciSenha" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                   
                  <center>  
                      <div style="position:absolute; top: 563px; left: 594px; width: 138px;"  
                 class="fb-like" data-href="https://www.facebook.com/Sgcondominio" 
                 data-send="true" data-width="450" data-show-faces="false" data-font="arial">
                          <img alt="" class="style5" src="images/chrome_logo_2x.png" /></div>  </center>
                    
                   
                    </div>
                <div id="dvDadosMorador" style="position:absolute; top: 170px; left: 395px;" 
                     runat="server">

                      <center> <fieldset class="login">
              <legend class="accordionContent">Solicitação de Acesso</legend> 
                  <br />
                    <table>
                            <tr>
                                <td class="style11" align="center" style="margin-left: 40px">
                                    <table class="style1" border='0'>
                                        <tr>
                                            <td class="style6">
                                                <asp:Label ID="lblProprietario" runat="server" Font-Bold="True" Text="Nome:"></asp:Label>
                                            </td>
                                            <td class="style6">
                                                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="style9">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
                                                    ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="solicitaAcesso"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style6">
                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Apartamento: "></asp:Label>
                                            </td>
                                            <td class="style6">
                                                <asp:TextBox ID="txtSolicitaAP" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="style9">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSolicitaAP"
                                                    ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="solicitaAcesso"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style6">
                                                <asp:Label ID="lblBloco" runat="server" Font-Bold="True" Text="Bloco:"></asp:Label>
                                            </td>
                                            <td class="style6" align="left">
                                                <asp:DropDownList ID="drpBlocoSolicita" runat="server" CssClass="conteudo" 
                                                    Font-Bold="True" Font-Size="Small" ForeColor="Blue" Height="17px" Width="44px">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style9">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style6">
                                                <asp:Label ID="lblEmail" runat="server" Font-Bold="True">E-mail</asp:Label>
                                            </td>
                                            <td class="style6">
                                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="style9">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                                                    ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="solicitaAcesso"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <asp:Button ID="btnOkSolicita" runat="server" CssClass="botao" Text="Ok" Width="63px"
                                        OnClick="btnOkPesquisa_Click" ValidationGroup="solicitaAcesso" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel0" runat="server" CssClass="botao" Text="Voltar" 
                                        OnClick="btnCancel0_Click1" />
                                </td>
                            </tr>
                        </table> 
                  
               </fieldset>  <asp:Label ID="lblMsg" runat="server" ForeColor="Blue" Font-Size="Medium"></asp:Label></div></center>
             
           
        </div>
        <center>
            <br />
        <div class="footerLogin" 
                style="position:absolute; top: 596px; left: 341px; width: 622px;">
            <span class="accordionContent"> &nbsp;Utilize o navegador Chrome para melhor visualização do site!
             </span><span class="style2"><span class="style4">
            <br />
            <br />
            © EL2 Soluções em Sistemas. INC 2015. Todos os direitos reservados</span>
            </span> &nbsp;<asp:Image ID="Image2" runat="server" Height="29px" 
                ImageUrl="~/images/logoteste.png" Width="73px" />
        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" CssClass="Border" 
                ImageUrl="~/images/ico_facebook.png" onclick="ImageButton1_Click" />
        <a href="mailto:edmls@ig.com.br"> <asp:ImageButton ID="ImageButton2" runat="server" Height="33px" 
                ImageUrl="~/images/email.jpg" Width="39px" /></a>
        </div></center>
    </div>
    </form>
</body>
</html>