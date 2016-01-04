<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="resetSenha.aspx.cs" Inherits="Azuli.Web.Portal.resetSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<fieldset class="loginDisplayLegend">
        <legend class="accordionContent">Alterar sua Senha:</legend>
 <br />
  <center><div id="dvProprietario" runat="server" >
   
        <br />
        <table class="btGeral" dir="ltr" frame="border" style="width: 349px" >
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" 
                        Text="Escolha uma senha de 6 digitos:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNovaSenha" runat="server" Height="21px" TextMode="Password" 
                        Width="95px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNovaSenha" runat="server" 
                        CssClass="failureNotification" ErrorMessage="*" 
                        ValidationGroup="alteraSenha" ControlToValidate="txtNovaSenha"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Confirme a senha:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRepitaNovaSenha" runat="server" Height="21px" 
                        TextMode="Password" Width="95px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRepitaNovaSenha" runat="server" 
                        CssClass="failureNotification" ErrorMessage="*" 
                        ValidationGroup="alteraSenha" ControlToValidate="txtRepitaNovaSenha"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td>
                    <asp:Button ID="btnAlteraSenha" runat="server" CssClass="botao" Text="Ok" 
                        Width="44px" onclick="btnAlteraSenha_Click" 
                        ValidationGroup="alteraSenha" />
                </td>  </tr>
              
        </table>
    </div></center><br /><center><asp:Label ID="lblMensagem" runat="server" CssClass="failureNotification"></asp:Label></center> </fieldset>
    
   
       
     
</asp:Content>