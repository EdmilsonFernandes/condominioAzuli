<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true"
    CodeBehind="TelaAgendamentoAdmin.aspx.cs" Inherits="Azuli.Web.Portal.TelaAgendamentoAdmin"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            background-color: #ADD8E6;
            font-style: normal;
        }
                 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <br /><br />
    <br />
    <div id="dvProprietario" align="center" runat="server" class="GridViewPager">
        <fieldset class="loginDisplayLegend">
           <legend class="accordionContent"> RESERVANDO PARA:</legend>
                   
             
            
                 Morador:
                <asp:Label ID="lblProprietarioDesc" runat="server" CssClass="bold"></asp:Label><br />
                <br />
                Bloco:
                <asp:Label ID="lblBlocoDesc" runat="server" CssClass="bold"></asp:Label>
                <br />
                <br />
                Apartamento:
                <asp:Label ID="lblApartDesc" runat="server" CssClass="bold"></asp:Label>
          
        </fieldset>
    </div>
    <div id="dvAlugar" runat="server" align="center">
        <fieldset class="loginDisplayLegend">
           <legend class="accordionContent"> Escolha a opção desejada e clique em Finalizar Reserva:</legend>
                   
            
            
                <table style="width: 878px; height: 104px;">
                    <tr>
                        <td class="">
                            
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Data: "></asp:Label>
                                <asp:Label ID="lblData" runat="server" Font-Bold="True" style="color: #0000FF"></asp:Label>
                            &nbsp;
                                <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" dir="ltr">
                            <asp:CheckBox ID="chkSalaoFesta" runat="server" Text=" Salão de Festas" Font-Bold="True"
                                EnableTheming="True" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            <asp:CheckBox ID="chkChurrascaria" runat="server" Text=" Área de churrasco" Font-Bold="True" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" align="center">
                            <center>
                                <asp:Label ID="lblReserva" runat="server" CssClass="failureNotification"></asp:Label></center>
                        </td>
                    </tr>
                </table>
                <p>
                    <br />
                    <asp:Button ID="LoginButton" runat="server" Text="Finalizar Reserva" CssClass="botao"
                        Font-Bold="True" Height="28px" OnClick="LoginButton_Click" />
                </p>
           
        </fieldset>
    </div>
    <div id="dvCalendar" align="center" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent"><span class="style4">Escolha a Data que o morador deseja reservar:</span></legend>
            <asp:Label ID="lblMsgData" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            <br />
            <table style="width:auto">
                <tr>
                    <td class="" align="left">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="UpdateTimer" Interval="5000" OnTick="UpdateTimer_Tick1" runat="server" />
                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" OnSelectionChanged="Calendar1_SelectionChanged"
                                    BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana"
                                    Font-Size="9pt" ForeColor="Black" Height="258px" NextPrevFormat="ShortMonth"
                                    Width="440px" OnDayRender="Calendar1_DayRender">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                                    <DayStyle BackColor="#CCCCCC" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle ForeColor="White" />
                                    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
                                        ForeColor="White" Height="12pt" />
                                    <TodayDayStyle ForeColor="White" />
                                </asp:Calendar>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style4">
                        &nbsp;<br />
                    </td>
                    <td class="style3">
                        <asp:ImageButton ID="imgFesta" runat="server" Height="16px" ImageUrl="~/images/azul.jpg"
                            Width="27px" />
                        <br />
                        <br />
                        <asp:ImageButton ID="imgFesta0" runat="server" Height="16px" ImageUrl="~/images/amarelo.jpg"
                            Width="27px" />
                        <br />
                        <br />
                        <asp:ImageButton ID="imgFesta1" runat="server" Height="16px" ImageUrl="~/images/vermelho.jpg"
                            Width="27px" /></td>
                        <td align="left">
                            <b>Salão de Festa Locado </b>
                            <br />
                            <br />
                            <b>Área de Churraco Locada </b>
                            <br />
                            <br />
                            <b>Salão de Festa e Área de churrasco Locado</b>
                        </td>
                    
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="DivConfirma" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Reserva Efetuada com Sucesso Para o:</legend>
            <table id="tbConfirma" style="width: 884px" runat="server">
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="lblBocoTitle" runat="server" Font-Bold="True" Text="Bloco:"></asp:Label>
                        &nbsp;<asp:Label ID="lblBlocoConfirma" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblApTitle" runat="server" Font-Bold="True" Text="Ap:"></asp:Label>
                        <asp:Label ID="lblApConfirma" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblDataConfirma" runat="server" Font-Bold="True" Text="Data: "></asp:Label>
                        &nbsp;<asp:Label ID="lblConfirmaData" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr> </table>
   
    <hr />
    <p style="color: #3A5FCD; font-weight: bold;">
        &nbsp;</p>
    <p style="color: #3A5FCD; font-weight: bold;" class="style14">
        Favor atentar às informações abaixo:
    </p>
    <table style="text-align: justify;">
        <tr>
            <td class="style13">
                <ul style="color: #3A5FCD">
                    <li>É permitido cancelar o agendamento somente com 2 dias de antencedencias </li>
                </ul>
                <ul style="color: #3A5FCD">
                    <li>Algumas regras</li>
                </ul>
                <ul style="color: #3A5FCD">
                    <li>Algumas regras</li>
                </ul>
                <ul style="color: #3A5FCD">
                    <li>Algumas regras</li>
                </ul>
                <ul style="color: #3A5FCD">
                    <li>Algumas regras</li>
                </ul>
                <p>
                    &nbsp;</p>
                <p>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="27px" ImageUrl="~/images/print.jpg"
                        OnClick="ImageButton1_Click1" />
                </p>
                <p>
                    &nbsp;</p>
                <p>
                    <asp:Button ID="btnOKConfirma" runat="server" CssClass="botao" OnClick="btnOKConfirma_Click1"
                        Text="Ok" Width="63px" />
                    &nbsp;</p>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img alt="" src="images/azuli.jpg" style="height: 146px; width: 161px;" />
            </td>
        </tr>
    </table>
  </fieldset> </div>
</asp:Content>
