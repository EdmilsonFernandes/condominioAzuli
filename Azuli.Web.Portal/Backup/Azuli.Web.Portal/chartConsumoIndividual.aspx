<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="chartConsumoIndividual.aspx.cs" Inherits="Azuli.Web.Portal.chartConsumoIndividual" %>
<%@ Register TagPrefix="highchart"  Namespace="Highchart.UI" Assembly="Highchart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center><legend align="bottom" class="accordionContent">CONDOMÍNIO RESIDENCIAL SPAZIO CAMPO AZULI</legend></center>
  
  
  
  
  <div id="container" align="center" runat="server"> 
    
       <highchart:columnchart id="hcConsumoGeral" width="500" height="400" runat="server"></highchart:columnchart>
       </div>
</asp:Content>
