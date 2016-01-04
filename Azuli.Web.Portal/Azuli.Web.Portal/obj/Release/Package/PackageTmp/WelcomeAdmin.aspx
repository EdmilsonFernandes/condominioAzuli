<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true"
    CodeBehind="WelcomeAdmin.aspx.cs" Inherits="Azuli.Web.Portal.WelcomeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 155px;
        }
        .style4
        {
            width: 22px;
        }
        .style5
        {
            width: 184px;
            height: 28px;
        }
        .style6
        {
            width: 22px;
            height: 28px;
        }
        .style7
        {
            height: 28px;
        }
        .controleCalendario
        {
        }
        .style8
        {
            width: 731px;
        }
        .style9
        {
            font-size: small;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

   <div id="Div1" runat="server" align="center">
                <fieldset class="loginDisplayLegend">
                    <legend class="accordionContent">Gerenciador de Tarefas</legend>
                   
                        
                            <asp:Label ID="Label4" runat="server" Text="Gerenciamento de Reservas" CssClass="accordionContent"
                                Font-Bold="True"></asp:Label>
                          <br /> <br />
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="Black" Height="200px" Width="220px" BorderWidth="1px"
                        OnDayRender="Calendar1_DayRender" ShowGridLines="True">
                        <DayHeaderStyle Font-Bold="True" Height="1px" BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="9pt" ForeColor="#666666" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#E0E0E0" Font-Bold="True" Font-Size="9pt" ForeColor="Black" />
                        <TodayDayStyle ForeColor="#009900" />
                    </asp:Calendar>
               
    <br /><br /><br /><br />
            <div id="dvPendencia" 
                        style="position:absolute; top: 200px; left: 712px; height: 201px;">
      
                <table style="border-spacing: 10px 10px; width: 450px;">
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="lblPendente" runat="server" Text="Tarefas Pendentes" CssClass="accordionContent"
                                Font-Bold="True"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" align="left">
                            <asp:Image ID="Image1" runat="server" Height="30px" ImageUrl="~/images/clientes.jpg"
                                Width="35px" />
                            &nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Liberação de Morador" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td class="style6">
                            <br />
                            <asp:Label ID="lblLiberarMorador" runat="server" Text="0"></asp:Label>
                        </td>
                        <td class="style7">
                            <br />
                            <asp:ImageButton ID="imgLiberarMorador" CssClass="Border" runat="server" ImageUrl="~/images/cliqueAqui.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" align="left">
                            <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="~/images/reserva.jpg"
                                Width="35px" />
                            &nbsp;
                            <asp:Label ID="lblReservaDesc" runat="server" Text="Liberação de Reserva" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td class="style4">
                            <br />
                            <asp:Label ID="lblLiberarReserva" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:ImageButton ID="imgLiberarReserva" CssClass="Border" runat="server" ImageUrl="~/images/cliqueAqui.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" align="left">
                            <asp:Image ID="Image3" runat="server" Height="30px" ImageUrl="~/images/mensagem.jpg"
                                Width="35px" />
                            &nbsp;
                            <asp:Label ID="lblMsgRecDesc" runat="server" Text="Mensagem Recebida" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td class="style4">
                            <br />
                            <asp:Label ID="lblMsgRecebida" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:ImageButton ID="imgMsgRecebida" CssClass="Border" runat="server" ImageUrl="~/images/cliqueAqui.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" align="left">
                            <asp:Image ID="Image4" runat="server" Height="30px" ImageUrl="~/images/ocoor.jpg"
                                Width="35px" />
                            &nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Ocorrência Abertas" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td class="style4">
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:ImageButton ID="ImageButton1" CssClass="Border" runat="server" ImageUrl="~/images/cliqueAqui.jpg" />
                        </td>
                    </tr>
                </table></div>
            
        </fieldset></div>
    
    <div id="dvLegend" runat="server" style="position: absolute; top: 432px; left: 197px;
        height: 77px; width: 246px;">
        <table runat="server" align="center" style="width: 227px" class="btGeral">
            <tr>
                <td align="justify">
                    <asp:ImageButton ID="imgFesta" runat="server" Height="8px" ImageUrl="~/images/azul.jpg"
                        Width="8px" />
                <span class="style8"><span class="style8">&nbsp;Salão de Festa Locado&nbsp;</span>
                        </span>
                </td>
            </tr>
            <tr>
                <td align="justify">
                  
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="8px" ImageUrl="~/images/amarelo.jpg"
                        Width="8px" />
                   <span class="style8">&nbsp;Área de Churrasco Locada&nbsp;</span>
                </td>
            </tr>
            <tr>
                <td align="justify">
                   
                    <asp:ImageButton ID="imgFesta1" runat="server" Height="8px" ImageUrl="~/images/vermelho.jpg"
                        Width="8px" />
                  <span class="style8"> &nbsp; Festa e Churrasqueira reservada</span>
                </td>
            </tr>
        </table>
    </div>

    <br /></br>
    
   
    
</asp:Content>
