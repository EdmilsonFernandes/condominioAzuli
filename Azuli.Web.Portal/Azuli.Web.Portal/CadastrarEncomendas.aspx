<%@ Page Title="" Language="C#" MasterPageFile="~/PageAcessControl.Master" AutoEventWireup="true" 
    CodeBehind="CadastrarEncomendas.aspx.cs" Inherits="Azuli.Web.Portal.CadastrarEncomendas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 163px;
        }
        .style4
        {
            font-weight: bold;
        }
        .style5
        {
            height: 28px;
        }
        </style>
    <script type="text/javascript" language="javascript">

        function MascaraMoeda(objTextBox, SeparadorMilesimo, SeparadorDecimal, e) {

            var sep = 0;

            var key = '';

            var i = j = 0;

            var len = len2 = 0;

            var strCheck = '0123456789';

            var aux = aux2 = '';

            var whichCode = (window.Event) ? e.which : e.keyCode;

            if (whichCode == 13) return true;

            key = String.fromCharCode(whichCode)

            if (strCheck.indexOf(key) == -1) return false; // Chave invlida

            len = objTextBox.value.length;

            for (i = 0; i < len; i++)

                if ((objTextBox.value.charAt(i) != '0') && (objTextBox.value.charAt(i) != SeparadorDecimal)) break;

            aux =

'';

            for (; i < len; i++)

                if (strCheck.indexOf(objTextBox.value.charAt(i)) != -1) aux += objTextBox.value.charAt(i);

            aux += key;

            len = aux.length;

            if (len == 0) objTextBox.value = '';

            if (len == 1) objTextBox.value = '0' + SeparadorDecimal + '0' + aux;

            if (len == 2) objTextBox.value = '0' + SeparadorDecimal + aux;

            if (len > 2) {

                aux2 =

'';

                for (j = 0, i = len - 3; i >= 0; i--) {

                    if (j == 3) {

                        aux2 += SeparadorMilesimo;

                        j = 0;

                    }

                    aux2 += aux.charAt(i);

                    j++;

                }

                objTextBox.value =

'';

                len2 = aux2.length;

                for (i = len2 - 1; i >= 0; i--)

                    objTextBox.value += aux2.charAt(i);

                objTextBox.value += SeparadorDecimal + aux.substr(len - 2, len);

            }

            return false;

        }

    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <table class="style1">
        <tr>
            <td class="style3">Bloco:</td>
            <td class="style5"><asp:TextBox ID="txtBloco" runat="server" Width="45px"></asp:TextBox></td>
            <td class="style4">Apartamento:</td>
            <td><asp:TextBox ID="txtApto" runat="server" Width="45px"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <div id="imgAnuncio" 
        style="position: absolute; top: 183px; left: 218px; color: #0033CC; width: 160px;">
        <asp:Image ID="imgGrupo" runat="server" Height="44px" Width="156px" />
    </div>
    <div id="dvAnunciar" runat="server" align="center">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent" align="left">Cadastrar Anúncio - Bloco:
                <asp:Label ID="lblDescBloco" runat="server" Text=""></asp:Label>
                - Ap:
                <asp:Label ID="lblDescApartamento" runat="server" Text=""></asp:Label></legend>
            <br />
            <table class="form" cellspacing="9px">
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label1" runat="server" Text="Descrição: " CssClass="style4"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescricao" runat="server" Height="63px" TextMode="MultiLine"
                            Width="472px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style5" colspan="2">
                        <asp:Button ID="btnCadastrar" runat="server" CssClass="btGeral" Height="28px" OnClick="btnCadastrar_Click"
                            Text="Cadastrar" Width="80px" ValidationGroup="validaClassificado" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btGeral" Height="28px" Text="Cancelar"
                            Width="82px" />
                    </td>
                </tr>
            </table>
            <br />
        </fieldset>
    </div>
    <div id="dvGravou" style="position: absolute; top: 221px; left: 660px; font-weight: 700;
        font-size: small;" runat="server">
        <center>
            <asp:Label ID="lblAnuncio" runat="server" CssClass="main" ForeColor="#009900"></asp:Label></center>
    </div>
    </asp:Content>

