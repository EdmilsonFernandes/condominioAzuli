<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="telaAgendamento.aspx.cs" Inherits="Azuli.Web.Portal.telaAgendamento" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style5
        {
            width: 567px;
        }
        .menu
        {
        }
        .style16
        {
            width: 892px;
        }
        #dvCalendar
        {
            height: 364px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div id="dvProprietario" runat="server">
    <br /><br /><br />
    <fieldset class="login">
    
        <legend class="accordionContent">Reservas feita em:  <asp:Label ID="lblMesAtual" runat="server" Style="font-weight: 700; color: #0033CC"></asp:Label></legend>
        <table style="height: 150px; width: 903px;" class="loginDisplay">
            <tr align="center">
          
                <td >
                 
                    <div style="position: absolute; top: 223px; left: 398px;">
                    <asp:FormView ID="formVwChurrasco" runat="server" CellPadding="4"
                        Width="125px" CssClass="btGeral" AllowPaging="True" Height="76px" 
                        EmptyDataText="Você não tem Reservas para Churrasqueira neste mês!!" 
                        onpageindexchanging="formVwChurrasco_PageIndexChanging" 
                        DataKeyNames="dataAgendamento">
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderTemplate>
                            Churrasqueira</HeaderTemplate>
                        <ItemTemplate>
                            <table id="tbAgendaMes" runat="server">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("dataAgendamento","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Image ID="Image1" ImageUrl="~/images/ok.jpg" Width="30px" runat="server" />
                                    </td>
                                </tr>
                                <br></br>
                            </table>
                            <br />
                         
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <PagerSettings PageButtonCount="6" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                    </asp:FormView>  
                    </div>                  
                                       
                 <div style="position: absolute; top: 224px; left: 701px;">
                    <asp:FormView ID="frvSalaoFesta" runat="server" CellPadding="4" 
                        Width="125px" CssClass="btGeral" AllowPaging="True" Height="76px" 
                        EmptyDataText="Você não tem Reservas para o salão de Festa neste mês!!" 
                        onpageindexchanging="frvSalaoFesta_PageIndexChanging" 
                        DataKeyNames="dataAgendamento"> 
                    
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderTemplate>
                            Salão de Festa</HeaderTemplate>
                        <ItemTemplate>
                            <table id="tbAgendaMes0" runat="server">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("dataAgendamento","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Image ID="Image1" ImageUrl="~/images/ok.jpg" Width="30px" runat="server" />
                                    </td>
                                </tr>
                                <br></br>
                            </table>
                            <br />
                     
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                        <PagerSettings PageButtonCount="6" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                    </asp:FormView>
                    </div>
                 
                </td>
            </tr>
             </table>

        <br />

        <asp:Label ID="lblMgs" runat="server" 
                     Font-Bold="False" ForeColor="Red"></asp:Label>
    </fieldset> </div>

    <!-- Opção para churrasqueira / Salão de Festa -->
    <div id="dvOpcao" runat="server">
        <fieldset class="login">
            <legend class="accordionContent">Escolha a área a reservar: </legend>
            <table style="width: 643px; height: 152px;">
                <tr>
                    <td class="style5">
                        <div id="dvData" runat="server" style="border-width: thin; border-style: groove;
                            width: 205px;">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Data: "></asp:Label>
                            <asp:Label ID="lblData" runat="server" Font-Bold="True"></asp:Label></div>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:CheckBox ID="chkSalaoFesta" runat="server" Text="Salão de Festas" Font-Bold="True"
                            EnableTheming="True" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style5">
                        <br />
                        <asp:CheckBox ID="chkChurrascaria" runat="server" Text="Área de churrasco" Font-Bold="True" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style5">
                     <center> 
                         <asp:Label ID="lblReserva" runat="server" CssClass="failureNotification"></asp:Label>
                        </center>  
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <p>
                <br />
                <asp:Button ID="LoginButton" runat="server" Text="Finalizar Reserva" CssClass="botao"
                    Font-Bold="True" Height="28px" OnClick="LoginButton_Click" 
                    ValidationGroup="finalizaReserva" />
            &nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botao"
                    Font-Bold="True" Height="28px" OnClick="btnCancelar_Click" 
                    ValidationGroup="finalizaReserva" />
            </p>
        </fieldset>
    </div>
    <!-- Fim opção -->

    <!-- Calendario para reserva -->
    <div id="dvCalendar" align="left" runat="server">
        <fieldset class="login">
           <legend class="accordionContent">Faça sua reserva, clicando 2 vezes na data escolhida:</legend>
            <asp:Label ID="lblMsgData" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
           <center>
            <table>
                <tr>
                    <td  align="center" class="style16">

                         
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
                     
                     <ContentTemplate>

                          <asp:Timer ID="UpdateTimer"  Interval="15000"  ontick="UpdateTimer_Tick1" 
                              runat="server" />
                              
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" OnSelectionChanged="Calendar1_SelectionChanged"
                            BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana"
                            Font-Size="9pt" ForeColor="Black" Height="216px" NextPrevFormat="ShortMonth"
                            Width="410px" OnDayRender="Calendar1_DayRender">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                            <DayStyle BackColor="#CCCCCC" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle ForeColor="White" />
                            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
                                ForeColor="White" Height="12pt" />
                            <TodayDayStyle ForeColor="White" />
                        </asp:Calendar>
                          <br />
                          </ContentTemplate>
                            <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
                            
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    </td>
                </tr>
                <tr>
                    <td  align="left" class="style16">

                         
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                         
                            <asp:ImageButton ID="imgFesta" runat="server" Height="16px" ImageUrl="~/images/azul.jpg"
                            Width="27px" /> <b>&nbsp;Salão de Festa Locado&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="imgFesta0" runat="server" Height="16px" ImageUrl="~/images/amarelo.jpg"
                            Width="27px" /> &nbsp;&nbsp; Área de Churrasco Locada&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="imgFesta1" runat="server" Height="16px" ImageUrl="~/images/vermelho.jpg"
                            Width="27px" />&nbsp;&nbsp;&nbsp;&nbsp; Salão de Festa e Área de churrasco Locado </b>

                    </td>
                </tr>
            </table></center> 
        </fieldset>
    </div>
 <!-- Fim calendario -->

    
</asp:Content>
