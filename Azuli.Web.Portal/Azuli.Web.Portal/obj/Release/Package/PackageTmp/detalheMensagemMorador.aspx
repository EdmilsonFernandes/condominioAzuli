<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="detalheMensagemMorador.aspx.cs" Inherits="Azuli.Web.Portal.detalheMensagemMorador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
        }
        .style2
        {
            text-align: right;
        }
        .style3
        {
            width: 400px;
        }
        .style4
        {
            width: 183px;
        }
        .style6
        {
            width: 400px;
            font-weight: bold;
        }
        .style7
        {
            width: 183px;
            font-weight: bold;
        }
        .style8
        {
            width: 200px;
            font-weight: bold;
        }
        .style9
        {
            width: 200px;
        }
        .style10
        {
            background-color: #f0f0f0;
            border-left: 1px dotted #999999;
            border-right: 1px dotted #999999;
            border-bottom: 1px dotted #999999;
            padding: 5px 5px 5px 5px;
            font-family: Verdana;
            font-size: 8pt;
            color: #666666;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><fieldset class="loginDisplayLegend">
        <legend class="accordionContent">Caixa de Entrada - Mensagem</legend>
    <div id="dvCaixa" runat="server" align="left">
        
        
            <br />
            <asp:Label ID="lblConsultaAno" runat="server" CssClass="footer" Text="Status:  "></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="drpStatusMsg" runat="server" CssClass="FooterStyle" Height="26px"
                Width="189px" AutoPostBack="True" OnSelectedIndexChanged="drpStatusMsg_SelectedIndexChanged">
                <asp:ListItem Value="1" Selected="True">Mensagem Não Lidas</asp:ListItem>
                <asp:ListItem Value="0">Mensagem Lidas</asp:ListItem>
            </asp:DropDownList>
            ou clique
            <asp:Button ID="btnBusca" runat="server" OnClick="btnBusca_Click" Text="Pesquisas Avançadas"
                CssClass="btGeral" Height="23px" Width="196px" />
            <br />
            <br />
            <br />
       
    </div>
     </fieldset>
     <div id="dvAvancada" align="center" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Deseja pesquisar por:</legend>
            <br />
            <table>
                <tr>
                    <td align="center">
                        <b>Assunto</b>
                    </td>
                    <td class="style6" align="center">
                        Mensagem
                    </td>
                    <td class="style7" align="center">
                        Data
                    </td>
                    <td class="style8" align="center">
                        Mensagem
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:TextBox ID="txtAssunto" runat="server" Width="248px"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="txtMsg" runat="server" Width="295px"></asp:TextBox>
                    </td>
                    <td class="style4" align="center">
                        <asp:TextBox ID="txtData" runat="server" Width="87px"></asp:TextBox>
                    </td>
                    <td class="style9" align="center">
                        <asp:DropDownList ID="drpMsgStatus" runat="server">
                            <asp:ListItem Value="L">Lidas</asp:ListItem>
                            <asp:ListItem Value="NL">Não Lidas</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <br />
                        <asp:Button ID="BtnPesquisar" runat="server" OnClick="BtnPesquisar_Click" Text="Pesquisar"
                            CssClass="btGeral" ValidationGroup="avancada" />
                        <asp:Button ID="btnLimpar" runat="server" OnClick="btnLimpar_Click" Text="Limpar Campos"
                            CssClass="btGeral" />
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar"
                            CssClass="btGeral" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
  
    <div id="divGeralMsg" runat="server" class="">
          <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Sua Mensagem:</legend><br />
        <div id="DivlerMsg" style="position: relative;" runat="server">
            <h3 class="AlternatingRowStyle">
                <asp:Label ID="lblDe" runat="server" Text=""></asp:Label>
                &nbsp; Assunto:&nbsp;&nbsp;
                <asp:Label ID="lblAssunto" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data:&nbsp;
                <asp:Label ID="lblData" runat="server" Text=""></asp:Label>
            </h3>
        </div>
        <div style="border: 1px solid #CCC; padding: 20px; margin-bottom: 20px;">
            <br />
            <b>
                <asp:Label ID="lblMsg" runat="server" Style="font-weight: 700"></asp:Label></b>
        </div>
        <center>
            <asp:Button ID="btnOk" runat="server" Text="Ok" Width="58px" CssClass="btGeral" OnClick="btnOk_Click" /></center>
            </fieldset>
    </div>
    <br />
    <br />
     <div id="dvNaoLida" align="center" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Resultado:
                <asp:Label ID="lblLidNL" runat="server"></asp:Label>
            </legend>
            <br />
           <center>  <asp:GridView ID="grdMsg" runat="server" AutoGenerateColumns="False" Height="16px"
                Width="722px" DataKeyNames="codigoMsg" CssClass="GridView" EmptyDataText="Todas mensagem já foram lidas!!"
                OnRowCommand="grdMsg_RowCommand">
                <Columns>
                    <asp:BoundField DataField="codigoMsg" HeaderText="Código Mensagem" Visible="false" />
                    <asp:BoundField HeaderText="De" DataField="deMsg" />
                    <asp:BoundField DataField="assunto" HeaderText="Assunto" />
                    <asp:TemplateField HeaderText="Data de Envio">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data_inicio") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("data_inicio", "{0:dddd}") + " / " + Eval("data_inicio","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/images/ico_search.gif" Text="Button"
                        DataTextField="data_inicio" />
                </Columns>
            </asp:GridView></center>

        </fieldset>
    </div>

    <div id="DvPesquisa" align="center" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="style10">Você pesquisou por:
                <asp:Label ID="lblCondintion" runat="server" style="color: #0000FF"></asp:Label>
            </legend>
            <br />
           <center>  
               <asp:GridView ID="grdPesquisa" runat="server" AutoGenerateColumns="False" Height="16px"
                Width="722px" DataKeyNames="codigoMsg" CssClass="GridView" EmptyDataText="Todas mensagem já foram lidas!!"
                OnRowCommand="grdPesquisa_RowCommand">
                <Columns>
                    <asp:BoundField DataField="codigoMsg" HeaderText="Código Mensagem" Visible="false" />
                    <asp:BoundField HeaderText="De" DataField="deMsg" />
                    <asp:BoundField DataField="assunto" HeaderText="Assunto" />
                    <asp:TemplateField HeaderText="Data de Envio">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data_inicio") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("data_inicio", "{0:dddd}") + " / " + Eval("data_inicio","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/images/ico_search.gif" Text="Button"
                        DataTextField="data_inicio" />
                </Columns>
            </asp:GridView></center>

        </fieldset>
    </div>

   
</asp:Content>
