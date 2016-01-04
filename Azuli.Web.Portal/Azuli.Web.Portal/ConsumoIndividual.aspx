<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsumoIndividual.aspx.cs" Inherits="Azuli.Web.Portal.ConsumoIndividual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .form
        {
            font-weight: 700;
            font-size: medium;
        }
        .style4
        {
            width: 171px;
            height: 154px;
        }
        .style5
        {
            width: 113px;
            height: 239px;
        }
        .style7
        {
            width: 176px;
        }
        .style8
        {
            width: 177px;
            height: 239px;
        }
        .accordionHeader
        {
            height: 133px;
            width: 136px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <br />

  <center>  <fieldset  class="loginDisplayLegend">
  
        <legend class="accordionContent">Gestão de Consumo Individual </legend>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <center>    <table class="ContextMenuPanel">
            <tr>
                <td class="style4" align="center">
                    <img alt="" class="controleCalendario" src="images/chart.jpg" /></td>
                <td class="style8" align="right">
        <asp:Label ID="lblConsultaAno" runat="server" CssClass="accordionContent" 
            Text="ANO BASE: "></asp:Label>
                </td>
                <td class="style5">
        <asp:DropDownList ID="drpAno" runat="server" CssClass="AlternatingRowStyle" Height="25px" 
            Width="97px" AutoPostBack="True">
        </asp:DropDownList>
                </td>
                <td align="left" class="style7">
                    <asp:Button ID="BtnChart" runat="server" CssClass="AlternatingRowStyle" 
                        onclick="BtnChart_Click" Text="Gerar Gráfico" />
                </td>
            </tr>
        </table></center>
        <br />

         <center>   <asp:Label ID="lblMsg" runat="server" CssClass="failureNotification"></asp:Label></center>
        
        <br />
        </fieldset></center>
</asp:Content>
