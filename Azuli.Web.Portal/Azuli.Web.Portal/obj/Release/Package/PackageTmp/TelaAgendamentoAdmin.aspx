<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true"
    CodeBehind="TelaAgendamentoAdmin.aspx.cs" Inherits="Azuli.Web.Portal.TelaAgendamentoAdmin"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
                         
        .style4
        {
            font-size: 13pt;
        }
                 
        .style5
        {
            width: 444px;
        }
        .style6
        {
        }
        .style7
        {
        }
        .style8
        {
            font-weight: bold;
            width: 896px;
            font-size: 13pt;
            color: #000099;
        }
        .style9
        {
            width: 743px;
        }
                 
        .style11
        {
            font-size: 12pt;
            color: #000000;
        }
                 
        .style13
        {
            background-color: #F0F0F0;
            border-left: 2px solid #999999;
            border-right: 2px solid #999999;
            border-botom: 2px solid #999999;
            padding: 5px 5px 5px 5px;
            font-family: Verdana;
            font-size: 8pt;
            color: #666666;
            border-radius: 1em;
            height: 18px;
            width: 654px;
        }
                 
        .style14
        {
            width: 100%;
        }
                 
        .style16
        {
            font-size: medium;
            color: #006600;
        }
                 
        .style17
        {
            font-size: medium;
        }
                 
    </style>

     <script type="text/javascript">
         function ShowInfo(id) {
             var div = document.getElementById(id);
             div.style.display = "block";
         }
         function HideInfo(id) {
             var div = document.getElementById(id);
             div.style.display = "none";
         }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
   <br />
   
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" 
        DescriptionUrl="Voltar Calendario" Height="24px" 
        ImageUrl="~/images/calendario.png" onclick="ImageButton1_Click2" Width="29px" />
    <div id="dvProprietario" align="center" runat="server" class="GridViewPager">
        <fieldset class="loginDisplayLegend">
         
             <table style="font-size: small" class="accordionContent">
            <tr>
            <td class="style4">
                 Reservando para o Morador:</td>
                 <td class="style4">
                <asp:Label ID="lblProprietarioDesc" runat="server" CssClass="style8"></asp:Label><br /></td>
             <td class="style17">
                Bloco:</td>
               <td><asp:Label ID="lblBlocoDesc" runat="server" CssClass="style8"></asp:Label></td> 
                
              <td class="style17">  Apartamento:</td>
               <td> <asp:Label ID="lblApartDesc" runat="server" CssClass="style8"></asp:Label></td>
                </tr>
                
          </table>
            <br />
            <table style="width: 938px; height: 171px;" class="accordionContent" 
                cellpadding="3">
                    <tr>
                        <td class="style6" colspan="2">
                            
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Data da Reserva: " 
                                    CssClass="style4"></asp:Label>
                                <asp:Label ID="lblData" runat="server" Font-Bold="True" style="color: #0000FF" 
                                    CssClass="style4"></asp:Label>
                            &nbsp;
                                <br />
                        </td>
                    </tr>
                    <tr>
                        <td dir="ltr" class="style7" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td dir="ltr" class="style9">
                            <asp:CheckBox ID="chkSalaoFesta" runat="server" Text=" Salão de Festas" Font-Bold="True"
                                EnableTheming="True" CssClass="style4" AutoPostBack="True" 
                                oncheckedchanged="chkSalaoFesta_CheckedChanged" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblVlFesta" runat="server" CssClass="accordionContent" 
                                Font-Bold="True" ForeColor="#006600" Text="Label"></asp:Label>
                        </td>
                        <td dir="ltr" align="center" class="style5" rowspan="4">
                            <asp:TextBox ID="txtObservacao" runat="server" Height="57px" 
                                style="font-weight: 700; font-size: 14pt" TextMode="MultiLine" Width="295px"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label2" runat="server" style="font-weight: 700; font-size: 13pt" 
                                Text="Observação:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style9" rowspan="1">
                            <asp:CheckBox ID="chkChurrascaria" runat="server" Text=" Área de churrasco" 
                                Font-Bold="True" CssClass="style4" AutoPostBack="True" 
                                oncheckedchanged="chkChurrascaria_CheckedChanged" />
                        &nbsp;<asp:Label ID="lblVlrChurras" runat="server" CssClass="accordionContent" 
                                Font-Bold="True" ForeColor="#006600" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style9">
                            <asp:CheckBox ID="chkPG" runat="server" Font-Bold="True" Text=" Pago" 
                                CssClass="style4" AutoPostBack="True" 
                                oncheckedchanged="chkPG_CheckedChanged" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            <asp:Label ID="lblDesconto" runat="server" CssClass="accordionContent" 
                                Font-Bold="True" ForeColor="Blue" Text="Label" Font-Size="Medium"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="style9" align="center">
                            <center style="width: 321px">
                                <asp:Label ID="lblReserva" runat="server" CssClass="failureNotification"></asp:Label></center>
                        </td>
                    </tr>
                       <tr>
                        <td align="left" class="style6" colspan="2">
                            
                            <asp:Label ID="lblDataPG" runat="server" 
                                style="font-weight: 700; color: #009933"></asp:Label>
                            <br />
                            
                    <asp:Button ID="LoginButton" runat="server" Text="Reservar" CssClass="botao"
                        Font-Bold="True" Height="28px" OnClick="LoginButton_Click" Width="128px" />
                    
            
                        &nbsp;<asp:Button ID="btnCancelaReserva" runat="server" Text="Cancelar" CssClass="botao"
                        Font-Bold="True" Height="28px" OnClick="btnCancelaReserva_Click" Width="128px" />
                    
            
                        </td>
                    </tr>
                   
                </table>
              
        </fieldset>
    </div>
 
    <div id="DivConfirma" runat="server" class="">
        <fieldset class="login">
            <legend class="accordionContent">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <span class="style16">Reserva Efetuada com Sucesso!</span></legend>
            <br />
    <center>     <table id="tbConfirma" runat="server" 
                class="style13">
                <tr>
                    <td align="center" class="accordionContent">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblBocoTitle" runat="server" Font-Bold="False" Text="Bloco:" 
                            Font-Italic="False" style="font-size: 11pt; color: #000000"></asp:Label>
                        &nbsp;<asp:Label ID="lblBlocoConfirma" runat="server" Font-Bold="True" 
                            CssClass="style11"></asp:Label>
                        &nbsp;<asp:Label ID="lblApTitle" runat="server" Font-Bold="False" Text="Ap:" 
                            style="font-size: 12pt; color: #000000"></asp:Label>
                        <asp:Label ID="lblApConfirma" runat="server" Font-Bold="True" 
                            CssClass="style11"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="lblDataConfirma" runat="server" Font-Bold="False" Text="Data: " 
                            style="font-size: 12pt; color: #000000"></asp:Label>
                        &nbsp;<asp:Label ID="lblConfirmaData" runat="server" Font-Bold="True" 
                            CssClass="style11"></asp:Label>
                        <br />
                            <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table class="style14">
                            <tr>
                                <td align="center">
                            <asp:Button ID="btnOKConfirma" runat="server" CssClass="botao" OnClick="btnOKConfirma_Click"
                                Text="Ok" Width="95px" Height="30px" />
                                </td>
                                <td>
                                    <asp:Button ID="btnRecibo" runat="server" CssClass="btForm" OnClick="btnRecibo_Click"
                                Text="Gerar Recibo" Width="127px" Height="30px" Font-Bold="True" 
                            ForeColor="#006600" />
                                </td>
                                <td>
    <asp:ImageButton ID="imgCalendar" runat="server" 
        DescriptionUrl="Voltar Calendario" Height="36px" 
        ImageUrl="~/images/calendario.png" onclick="ImageButton1_Click2" Width="42px" />
                                </td>
                                <td>
                        <asp:HyperLink ID="hplnkWelcomeAdmin" runat="server" ForeColor="Blue" 
                            NavigateUrl="~/WelcomeAdmin.aspx">Clique aqui para voltar ao calendário</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
&nbsp;</td>
                </tr>
        
           </table> </center>   </fieldset> </div> 
</asp:Content>
