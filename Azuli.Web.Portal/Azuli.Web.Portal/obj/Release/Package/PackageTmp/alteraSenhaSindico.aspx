<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true"
    CodeBehind="alteraSenhaSindico.aspx.cs" Inherits="Azuli.Web.Portal.alteraSenhaSindico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            font-weight: bold;
            font-size: 11pt;
        }
        .style4
        {
            width: 160px;
        }
        .style6
        {
            width: 168px;
            height: 132px;
        }
        .style7
        {
            font-weight: bold;
            font-size: 10pt;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <center>
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Alterar sua Senha: Administrador</legend>
            <br />
            <center>
                <div id="dvProprietario" align="center" runat="server">
                    <table class="style3">
                        <tr>
                            <td class="style4">
                                <img alt="" class="style6" src="images/senha2.jpg" />
                            </td>
                            <td align="justify">
                                <table class="accordionContent" dir="ltr" frame="border" style="width: 417px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Escolha uma senha de 4 digitos:" CssClass="style7"></asp:Label>
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
                                                Width="126px" OnClick="btnAlteraSenha_Click" ValidationGroup="alteraSenha" Style="font-size: 10pt" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
            </center>
            <br />

           
      
            
           <center>      <asp:Label ID="lblMensagem" runat="server" 
                   CssClass="accordionContent" Font-Bold="True"
                Font-Size="Small" ForeColor="#CC3300" Visible="False"></asp:Label></center>

           
      
            
        </fieldset>
        <br /><br /><br />
                   
    </center>
</asp:Content>
