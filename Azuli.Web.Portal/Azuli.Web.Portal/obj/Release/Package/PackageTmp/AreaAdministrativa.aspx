<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AreaAdministrativa.aspx.cs" Inherits="Azuli.Web.Portal.AreaAdministrativa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    
     <div id="dvPesquisaMorador" align="center" runat="server">
    
      <fieldset class="loginDisplayLegend">
     <legend align="left" class="accordionContent">Agendar para Moradores</legend>
   
        <br /><br />
            <center>
             <table  style="border: thin solid #C0C0C0;">
                        <tr>
                            <td class="style2">
                                <asp:Label ID="lblSelecioneBloco" runat="server" Font-Bold="True" 
                                    Text="Selecione o Bloco:"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:DropDownList ID="drpBloco" runat="server" Height="20px" Width="46px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                             <asp:ListItem>6</asp:ListItem>
                        </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="lblApart" runat="server" Font-Bold="True" 
                                    Text="Digite o Apartamento:"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="txtAp" runat="server" onKeyPress="return Decimal(this,event);"  Width="58px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPesquisaAP" runat="server" 
                                    ControlToValidate="txtAp" CssClass="failureNotification" ErrorMessage="*" 
                                    ValidationGroup="pesquisaAP"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                &nbsp;</td>
                            <td class="style5">
                                <asp:Button ID="btnOk" runat="server" CssClass="botao" Text="Pesquisar" 
                                    Width="67px" onclick="btnOk_Click" ValidationGroup="pesquisaAP" />
&nbsp;</td>
                        </tr>
               
        </table></center>
  </fieldset> </div> 
  
  <asp:Label ID="lblMsgCadastro" runat="server" CssClass="failureNotification" 
         ForeColor="#0066FF"></asp:Label>

 
    <div id="dvNewUser" align="center" runat="server">
    <fieldset class="loginDisplayLegend">
      <legend align="left" class="accordionContent">Novo Cadastro</legend>
   
  <center> <br /> <br />
     <asp:Label ID="lblMsg" runat="server" CssClass="failureNotification" 
         Text="Label"></asp:Label>
   <br /><br />
     <asp:Button ID="btnCadastrar" runat="server" CssClass="botao" Text="Sim" 
         Width="70px" onclick="btnCadastrar_Click" />
&nbsp;
     <asp:Button ID="btnCancelar" runat="server" CssClass="botao" 
         onclick="btnCancelar_Click" Text="Cancelar" />
          <br />
          <br />
          <br />
   <br /> 
     <br /></center></fieldset></div>

        <div id="dvDadosMorador" align="center" runat="server">
     <fieldset class="loginDisplayLegend">
     <legend align="left" class="accordionContent">Dados do Morador</legend>
  
    <br /> <br />
    
      <center>  <table style="border: thin solid #C0C0C0; height: auto; width: auto;">
            <tr>
                <td class="style11" align="center" style="margin-left: 40px">
                    <table class="style1" border='0'>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="lblProprietario" runat="server" Font-Bold="True" Text="Nome:"></asp:Label>
                            </td>
                            <td class="style9">
                                <asp:Label ID="lblProprietarioDesc" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Apartamento: "></asp:Label>
                            </td>
                            <td class="style9">
                                <asp:Label ID="lblApartDesc" runat="server" Text="301"></asp:Label>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="style6">
                                <asp:Label ID="lblBloco" runat="server" Font-Bold="True" Text="Bloco:"></asp:Label>
                            </td>
                            <td class="style9">
                                <asp:Label ID="lblBlocoDesc" runat="server" Text="6"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:Button ID="btnOkPesquisa" runat="server" CssClass="botao" Text="Ok" 
                        Width="63px" onclick="btnOkPesquisa_Click" />
&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="btnCancel0" runat="server" CssClass="botao" 
                        Text="Cancelar" onclick="btnCancel0_Click1"  />
                </td>
            </tr>
        </table></center><br />
   </fieldset> </div>
    <br />
 <br />
 
  <div id="dvCadastro"  runat="server" align="center" >
 <fieldset class="loginDisplayLegend"> 
 <legend class="accordionContent">Cadastrar Moradores</legend>
 
      <table>
            <tr>
                <td class="style11" align="center">
                    <table class="style1" border='0'>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="lblPropre1" runat="server" Font-Bold="True" Text="Morador 1"></asp:Label>
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="txtMorador1" runat="server" Width="167px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMorador1" runat="server" 
                                    ControlToValidate="txtMorador1" CssClass="failureNotification" ErrorMessage="*" 
                                    ValidationGroup="cadastraMorador"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="lblPropre02" runat="server" Font-Bold="True" Text="Morador 2"></asp:Label>
                            </td>
                            <td class="style9">
                                 <asp:TextBox ID="txtMorador2" runat="server" Width="165px"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvMorador2" runat="server" 
                                     ControlToValidate="txtMorador2" CssClass="failureNotification" ErrorMessage="*" 
                                     ValidationGroup="cadastraMorador"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Text="E-mail"></asp:Label>
                            </td>
                            <td class="style8">
                            <asp:TextBox ID="txtEmail" runat="server" Width="165px"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rqfEmail" runat="server" 
                                     ControlToValidate="txtEmail" CssClass="failureNotification" ErrorMessage="*" 
                                     ValidationGroup="cadastraMorador"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Apartamento: "></asp:Label>
                            </td>
                            <td class="style9">
                                 <asp:TextBox ID="txtApartamento" runat="server" onKeyPress="return Decimal(this,event);"  Width="53px"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvAp" runat="server" 
                                     ControlToValidate="txtApartamento" CssClass="failureNotification" 
                                     ErrorMessage="*" ValidationGroup="cadastraMorador"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Bloco:"></asp:Label>
                            </td>
                            <td class="style9">
                                 <asp:TextBox ID="txtBlocos" runat="server" onKeyPress="return Decimal(this,event);"  Width="53px" />
                                 <asp:RequiredFieldValidator ID="rfvBloco" runat="server" 
                                     ControlToValidate="txtBlocos" CssClass="failureNotification" ErrorMessage="*" 
                                     ValidationGroup="cadastraMorador"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnCadastroMorador" runat="server" CssClass="botao" Text="Efetuar Cadastro" 
                        Width="150px" onclick="btnCadastroMorador_Click" 
                        ValidationGroup="cadastraMorador" />
&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="btnCancelarCadastro" runat="server" CssClass="botao" 
                        Text="Cancelar cadastro" onclick="btnCancelarCadastro_Click"  />
                </td>
            </tr>
        </table>
      
  </fieldset>   </div>


</asp:Content>
