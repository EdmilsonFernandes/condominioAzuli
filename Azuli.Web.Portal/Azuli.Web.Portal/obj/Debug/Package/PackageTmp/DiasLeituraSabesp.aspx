<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true"
    CodeBehind="DiasLeituraSabesp.aspx.cs" Inherits="Azuli.Web.Portal.DiasLeituraSabesp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .dropdown
        {
            font-weight: 700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="loginDisplayLegend">
        <legend class="accordionContent">Leitura Sabesp:</legend>
        <center>
            <div id="dvProprietario" runat="server">
                <br />
                <table class="accordionContent" dir="ltr" frame="border" style="width: 373px">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Mês de referência:" Style="font-weight: 700;
                                font-size: 10pt"></asp:Label>
                        </td>
                        <td class="left">
                            <asp:DropDownList ID="drpListaMes" runat="server" CssClass="dropdown">
                                <asp:ListItem Selected="True">Selecione o mês ...</asp:ListItem>
                                <asp:ListItem Value="01">Janeiro</asp:ListItem>
                                <asp:ListItem Value="02">Fevereiro</asp:ListItem>
                                <asp:ListItem Value="03">Março</asp:ListItem>
                                <asp:ListItem Value="04">Abril</asp:ListItem>
                                <asp:ListItem Value="05">Maio</asp:ListItem>
                                <asp:ListItem Value="06">Junho</asp:ListItem>
                                <asp:ListItem Value="07">Julho</asp:ListItem>
                                <asp:ListItem Value="08">Agosto</asp:ListItem>
                                <asp:ListItem Value="09">Setembro</asp:ListItem>
                                <asp:ListItem Value="10">Outubro</asp:ListItem>
                                <asp:ListItem Value="11">Novembro</asp:ListItem>
                                <asp:ListItem Value="12">Dezembro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblLeituraAtual" runat="server" Text="Leitura Atual:" Style="font-weight: 700;
                                font-size: 10pt"></asp:Label>
                        </td>
                        <td class="left">
                            <asp:TextBox ID="txtLeituraAtual" runat="server" Height="19px" Width="179px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRepitaNovaSenha" runat="server" CssClass="failureNotification"
                                ErrorMessage="*" ValidationGroup="validaLeitura" ControlToValidate="txtLeituraAtual"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblAnterior" runat="server" Text="Leitura Anterior:" Style="font-weight: 700;
                                font-size: 10pt"></asp:Label>
                        </td>
                        <td class="left">
                            <asp:TextBox ID="txtLeituraAnterior" runat="server" Height="16px" Width="179px" 
                                OnTextChanged="txtLeituraAnterior_TextChanged" AutoPostBack="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRepitaNovaSenha0" runat="server" CssClass="failureNotification"
                                ErrorMessage="*" ValidationGroup="validaLeitura" ControlToValidate="txtLeituraAnterior"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Periodo:" Style="font-weight: 700; font-size: 10pt"></asp:Label>
                        </td>
                        <td class="left">
                            <asp:TextBox ID="txtPeriodo" runat="server" Height="21px" Width="70px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRepitaNovaSenha1" runat="server" CssClass="failureNotification"
                                ErrorMessage="*" ValidationGroup="validaLeitura" ControlToValidate="txtPeriodo"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnCadastraLeituraSabesp" runat="server" CssClass="botao" Text="Cadastrar"
                                Width="105px" ValidationGroup="validaLeitura" 
                                onclick="btnCadastraLeituraSabesp_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </center>
        <br />
        <center>
            <asp:Label ID="lblMensagem" runat="server" CssClass="failureNotification"></asp:Label>
            <br />
            <br />
            <asp:ObjectDataSource ID="ObjectDataSourceLista" runat="server" 
            
                SelectMethod="buscaLeituraGeral"
                TypeName="Azuli.Web.Business.LeituraSabespBLL"
                DataObjectTypeName="Azuli.Web.Model.LeituraSabesp">

            </asp:ObjectDataSource>


            <asp:GridView ID="grdConfigArea" runat="server" DataSourceID="ObjectDataSourceLista" AutoGenerateColumns="False" CssClass="gridl">
                <Columns>
                    <asp:BoundField DataField="mesReferencia" HeaderText="Mês de referência" SortExpression="MES_REFERENCIA" />
                    <asp:BoundField DataField="dataAtual" HeaderText="Leitura Atual" 
                        SortExpression="DATA_ATUAL" DataFormatString="{0:dd/MM/yy}" />
                    <asp:BoundField DataField="dataAnterior" HeaderText="Leitura Anterior" 
                        SortExpression="DATA_ANTERIOR" DataFormatString="{0:dd/MM/yy}" />
                    <asp:BoundField DataField="dias" HeaderText="Periodo (Dias)" 
                        SortExpression="DIAS" />
                </Columns>
            </asp:GridView>
            <br />
        </center>
    </fieldset>
</asp:Content>
