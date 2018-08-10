<%@ Page Title="" Language="C#" MasterPageFile="~/PageAcessControl.Master" AutoEventWireup="true" CodeBehind="controlePortaria.aspx.cs" Inherits="Azuli.Web.Portal.controlePortaria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            border-radius: 1em;
            text-align: center;
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <br /><br />
  <div id="dvMsg" align="center"  runat="server"> 
  

  <fieldset class="loginDisplayLegend" >
   <legend class="accordionContent">CONTROLE DE PORTARIA SPAZIO CAMPO AZULI</legend>
   <br />
      <table class="style1">
          <tr>
              <td>
                  <asp:Button ID="btnConsultaVisitantePrestador" runat="server" 
                      CssClass="style2" Font-Bold="True" Height="43px" 
                      Text="CONSULTA VISITANTE - PRESTADOR DE SERVIÇO" Width="346px" 
                      onclick="btnConsultaVisitantePrestador_Click" />
              </td>
              <td>
                  <asp:Button ID="btnCadastrarVP" runat="server" CssClass="style2" 
                      Font-Bold="True" Height="43px" 
                      Text="CADASTRAR VISITANTE / PRESTADOR DE SERVIÇOS" Width="346px" />
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  <asp:Button ID="btnConsultarMorador" runat="server" CssClass="style2" 
                      Font-Bold="True" Height="43px" Text="CONSULTAR MORADORES" Width="346px" />
              </td>
              <td>
                  <asp:Button ID="Button5" runat="server" CssClass="style2" Font-Bold="True" 
                      Height="43px" Text="AVISAR ECOMENDA PARA MORADOR" Width="346px" />
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  <asp:Button ID="btnListaEventos" runat="server" CssClass="style2" 
                      Font-Bold="True" Height="43px" Text="CONSULTAR LISTA DE EVENTO FESTA" 
                      Width="346px" />
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
      </table>
      <br />
   </fieldset>
   
   </div>
</asp:Content>
