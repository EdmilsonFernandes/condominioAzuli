<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="resetSenha.aspx.cs" Inherits="Azuli.Web.Portal.resetSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 341px;
        }
        .style5
        {
            color: #333333;
        }
        .style6
        {
            width: 131px;
            height: 109px;
        }
        .style7
        {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
        <div  id="dvProprietario"  runat="server">
   <fieldset class="loginDisplayLegend">
        <legend class="accordionContent"><span class="style5">Alterar sua Senha</span>:</legend>
      <br />
        
                <table class="style3" align="center">
                    <tr>
                        <td class="style4" align="right">
                            <img alt="" class="style6" src="images/senha2.jpg" />
                        </td>
                        <td align="justify">
                            <table class="accordionContent" dir="ltr" frame="border" style="width: 439px">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Digite sua nova senha com 4 digitos:"
                                            CssClass="style7"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNovaSenha" runat="server" Height="21px" TextMode="Password" Width="95px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNovaSenha" runat="server" CssClass="failureNotification"
                                            ErrorMessage="*" ValidationGroup="alteraSenha" ControlToValidate="txtNovaSenha"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Confirme a nova senha:" CssClass="style7"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRepitaNovaSenha" runat="server" Height="21px" TextMode="Password"
                                            Width="95px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRepitaNovaSenha" runat="server" CssClass="failureNotification"
                                            ErrorMessage="*" ValidationGroup="alteraSenha" ControlToValidate="txtRepitaNovaSenha"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAlteraSenha" runat="server" CssClass="botao" Text="Mudar Senha"
                                            Width="105px" OnClick="btnAlteraSenha_Click" ValidationGroup="alteraSenha" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br /><br /><br />
                      <center>  <asp:Label ID="lblMensagem" runat="server" CssClass="accordionContent" Font-Bold="True"
                Font-Size="Small" ForeColor="#CC3300" Visible="False"></asp:Label></center>
                </fieldset>
          </div>
     
     
      
    
    
      
</asp:Content>
