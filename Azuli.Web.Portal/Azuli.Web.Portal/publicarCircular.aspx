<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="publicarCircular.aspx.cs" Inherits="Azuli.Web.Portal.circular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .register
    {}
        .style3
        {
            font-weight: bold;
            font-size: 9pt;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div id="dvPublicar" runat="server" align="center">
    <fieldset class="loginDisplayLegend">
        <legend  class="accordionContent">Publicações de Circulares: </legend>
        <br />
        
        <table class="accordionContent" align="center">
            <tr>
                <td>
                    <asp:Label ID="lblDesc" runat="server" Text="Assunto:" 
                        style="font-weight: 700; font-size: 9pt"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAssunto" runat="server" 
                        CssClass="register" Height="20px" Width="269px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMesDEsc" runat="server" Text="Mês de publicação:" 
                        style="font-weight: 700; font-size: 9pt"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpMes" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAnoDesc" runat="server" Text="Ano da Publicação:" 
                        CssClass="style3"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpAno" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><br />
                    <asp:Label ID="lblArquivo" runat="server" Text="Arquivo a ser publicado:" 
                        CssClass="style3"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="fileWord" runat="server" Height="23px" Width="341px" 
                        CssClass="btPortaria" />
                </td>
            </tr>
          
            <tr>
                <td colspan="2" align="center">
                    <br />
                    <asp:Button ID="btnPublicar" runat="server" CssClass="btGeral" 
                        Text="Publicar" onclick="btnPublicar_Click" Font-Bold="True" Height="24px" 
                        Width="84px" />
                 </td>
            </tr>
              <tr>
                <td colspan="2" align="center">
                    &nbsp;</td>
            </tr>
               <tr>
                <td colspan="2" align="center">
                   <asp:Label ID="lblMsg" runat="server" ForeColor="#006600" 
                        style="font-weight: 700"></asp:Label>
                 </td>
            </tr>
            </table>
        
        
        </fieldset></div>
</asp:Content>
