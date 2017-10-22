<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="PendenciaAgendamentos.aspx.cs" Inherits="Azuli.Web.Portal.PendenciaAgendamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .accordionContent
        {
            width: 982px;
            
        }
        .style16
        {
            font-weight: bold;
            font-size: 12pt;
        }
        .style17
        {
            font-weight: bold;
            font-size: 10pt;
            color: #0000FF;
        }
        #DvConfirma
        {
            width: 977px;
        }
        .style19
        {
            border-botom: 2px solid #999999;
            font-family: Verdana;
            font-size: 12pt;
            color: #666666;
            border-radius: 1em;
            height: 15px;
            width: 982px;
            border-left: 2px solid #999999;
            border-right: 2px solid #999999;
            padding: 5px;
            background-color: #F0F0F0;
        }
        .style20
        {
            font-size: 13pt;
            font-weight: bold;
        }
        .style21
        {
            width: 114%;
        }
        .style30
        {
            height: 45px;
            width: 298px;
        }
        .style35
        {
            width: 328px;
        }
        .style36
        {
            width: 298px;
        }
        .style37
        {
            font-family: Verdana;
            font-size: small;
            color: #666666;
            behavior: url(border-radius.htc);
            border-radius: 1em;
            height: 15px;
            font-weight: 700;
            width: 982px;
            border: 2px solid #0093d4;
            padding: 5px;
            background-color: #F0F0F0;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br /><br /><br /><br />
     <div id="dvPesquisaMorador" runat="server">
    
      <fieldset class="loginDisplayLegend">
     <legend align="left" class="style37">Cancelamento de Reservas:
          </legend>


          <asp:Label ID="Label9" runat="server" 
              style="color: #006AB2; font-weight: 700; font-size: 12pt" 
              Text="Cancelamento de reserva para: "></asp:Label>
      <asp:Label ID="lblDataReservaEtapa1" runat="server" CssClass="accordionContent" 
          style="font-weight: 700; font-family: Calibri; font-size: 14pt"></asp:Label>
          <br />


          <br />


          <table class="headerEnqueteClass" border="1">
              <tr>
                  <td class="style35" style="border-style: groove; border-width: thin" 
                      bgcolor="#FFFFCC">
                      <asp:Label ID="Label7" runat="server" CssClass="style16" Text="Bloco:"></asp:Label>
                      <asp:Label ID="lblBloco" runat="server" CssClass="style17"></asp:Label>
                      &nbsp;
                      <asp:Label ID="Label8" runat="server" CssClass="style16" Text="Apto.:"></asp:Label>
                      <asp:Label ID="lblApto" runat="server" CssClass="style17"></asp:Label>
                  </td>
                 <%-- <td align="center" class="style7" 
                      style="border-style: groove; border-width: thin">
                      <asp:Label ID="lblPg" runat="server" CssClass="style16" Text="Pagamento"></asp:Label>
                  </td>--%>
                  <td align="center" class="style36" 
                      style="border-style: groove; border-width: thin" bgcolor="#FFFFCC">
                      <asp:Label ID="lblCancel" runat="server" CssClass="style16" Text="Cancelamento"></asp:Label>
                  </td>
                  <%--<td align="center" class="style13" 
                      style="border-style: groove; border-width: thin">
                      <asp:Label ID="lblDiasAtraso" runat="server" CssClass="style16" 
                          Text="Dias em Atraso"></asp:Label>
                  </td>--%>
              </tr>
              <tr>
                  <td align="center" 
                      
                     
                      class="style35">
                      &nbsp;
                      <asp:Label ID="lblChurras" runat="server" CssClass="style16" 
                          Text="Churrasqueira"></asp:Label>
                  </td>
<%--                  <td align="center" 
                      style="border-right-style: groove; border-left-style: groove; border-width: thin; border-bottom-style: groove;">
                      <asp:Button ID="btnConfirmaChurras" runat="server" CssClass="botao" 
                          Text="Confirma Churrasqueira" BackColor="#006600" ForeColor="White" 
                          onclick="btnConfirmaChurras_Click" Height="29px" />
                  </td>--%>
                  <td align="center"  
                      class="style36">
                      <asp:Button ID="btnCancelarChurras" runat="server" CssClass="botao" 
                          Text="Cancelar Churraqueira" BackColor="#CC3300" ForeColor="White" 
                          onclick="btnCancelarChurras_Click" Height="30px" />
                  </td>
<%--                  <td align="center" 
                      
                      style="border-left-style: groove; border-width: thin; border-bottom-style: groove;" 
                      class="style14">
                      <asp:Label ID="lblDiasAtrasoChurras" runat="server" CssClass="style8" Text="8"></asp:Label>
                  </td>--%>
              </tr>
              <tr>
                  <td  align="center" 
                      class="style35">
                      &nbsp;
                      <asp:Label ID="lblSalaoFesta" runat="server" CssClass="style16" 
                          Text="Salão de Festa"></asp:Label>
                  </td>
                 <%-- <td align="center" 
                      style="border-right-style: groove; border-left-style: groove; border-width: thin">
                      <asp:Button ID="btnConfirmaSalao" runat="server" CssClass="botao" 
                          Text="Confirma Salão de Festa" BackColor="#006600" ForeColor="White" 
                          onclick="btnConfirmaSalao_Click" Height="26px" />
                  </td>--%>
                  <td align="center" class="style36">
                      <asp:Button ID="btnCancelaFesta" runat="server" CssClass="botao" 
                          Text="Cancelar Festa" BackColor="#CC0000" ForeColor="White" 
                          onclick="btnCancelaFesta_Click" Height="26px" />
                  </td>
<%--                  <td align="Center" style="border-left-style: groove; border-width: thin" 
                      class="style14">
                      <asp:Label ID="lblDiasAtrasoFesta" runat="server" CssClass="style8" Text="4"></asp:Label>
                  </td>--%>
              </tr>
              <tr>
                  <td  class="style35">
                      </td>
                 <%-- <td style="border: thin groove #CCCCCC;" align="center" 
                      class="style11">
                      <asp:Button ID="btnConfirmALL" runat="server" CssClass="botao" Text="Confirma tudo" 
                          BackColor="#006600" ForeColor="White" Height="34px" 
                          style="font-size: 11pt" onclick="btnConfirmALL_Click" />
                  </td>--%>
                  <td  align="center" 
                      class="style30">
                      <asp:Button ID="btnCancelAll" runat="server" CssClass="botao" Text="Cancelar todos" 
                          BackColor="#CC0000" ForeColor="White" Height="36px" 
                          style="font-size: 11pt" onclick="btnCancelAll_Click" />
                  </td>
              </tr>
              </table>




   </fieldset>
   </div>



    <center> <div id="DvConfirma" align="center" runat="server">
    
    <fieldset class="loginDisplayAdmin">
   <legend class="accordionContent"> 
       <asp:Label ID="lblStatus" runat="server" Text="Label" Font-Bold="True" 
           Font-Size="Large"></asp:Label>
        </legend>
  <center> <br /> <br />
   <br />
      <span class="style20">Cancelamento para:&nbsp; </span>
      <asp:Label ID="lblDataReserva" runat="server" CssClass="accordionContent" 
          style="font-weight: 700; font-family: Calibri; font-size: 14pt"></asp:Label>
      <br />
      <br />
      <span class="style20">Bloco e Apto:</span>
      <asp:Label ID="lblBlocoApto" runat="server" CssClass="accordionContent" 
          style="font-weight: 700; font-family: Calibri; font-size: 14pt"></asp:Label>
      <br />
      <br />
      <span class="style20">Observação:</span>
      <asp:TextBox ID="txtObs" runat="server" Height="59px" TextMode="MultiLine"></asp:TextBox>
      <br />
    <br />
      <br />
     <asp:Button ID="btnCadastrar" runat="server" CssClass="botao" Text="Finalizar Cancelamento" 
         Width="200px" Height="35px" onclick="btnCadastrar_Click" />
&nbsp;
     <asp:Button ID="btnCancelar" runat="server" CssClass="botao" 
         Text="Desistir" Width="89px" Height="35px" onclick="btnCancelar_Click" />
          <br />

     <br /></center></fieldset>
   </div></center>

   <div id="DvVoltar" align="center" runat="server">
    
    <fieldset class="loginDisplayAdmin">
   <legend class="style19"> 
       <asp:Label ID="lblSucess" runat="server" Text="Ação efetuada com Sucesso!!" 
           style="color: #006600"></asp:Label>
        </legend>
  <center> <br /> <br />
      <table class="style21">
          <tr>
              <td align="right">
                  <asp:ImageButton ID="ImageButton1" runat="server" Height="91px" 
                      ImageUrl="~/images/calendario.png" Width="109px" />
              </td>
              <td>
                  <asp:HyperLink ID="hplSucess" runat="server" 
                      style="font-weight: 700; font-size: 12pt" CssClass="accordionContent" 
                      Font-Bold="False" NavigateUrl="~/WelcomeAdmin.aspx">Clique aqui para voltar para o Calendário</asp:HyperLink>
              </td>
          </tr>
      </table>
          <br />

     <br /></center></fieldset>
   </div>
</asp:Content>
