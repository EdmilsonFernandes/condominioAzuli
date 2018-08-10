<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AuxliaryChart1.aspx.cs" Inherits="Azuli.Web.Portal.AuxliaryChart1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .form
    {
        font-weight: 700;
        font-size: large;
    }
    .style3
    {
        width: 100%;
    }
    .style4
    {
        width: 109px;
    }
    .style5
    {
        width: 143px;
    }
        .style6
        {
            width: 177px;
            height: 123px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table ></table>
    <br />

  <center>  <fieldset  class="loginDisplayLegend">
  
        <legend class="accordionContent">Gráficos de Gestão de consumo de Água </legend>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
     <center> <table class="accordionContent">
            <tr>
                <td class="style4">
                    <img alt="" class="style6" src="images/chart.jpg" /></td>
                <td class="style4">
        <asp:Label ID="lblConsultaAno" runat="server" CssClass="accordionContent" 
            Text="ANO BASE: "></asp:Label>
                </td>
                <td class="style5">
        <asp:DropDownList ID="drpAno" runat="server" CssClass="form" Height="26px" 
            Width="123px" AutoPostBack="True">
        </asp:DropDownList>
                </td>
                <td>
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
