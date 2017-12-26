<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="listaOcorrenciaMorador.aspx.cs" Inherits="Azuli.Web.Portal.listaOcorrenciaMorador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .newStyle1
        {
            color: #0000FF;
        }
        .style1
        {
            font-weight: bold;
        }
        #dvOconteudo
        {
            width: 909px;
        }
    </style>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
//<![CDATA[
        $(document).ready(function () {
            $('<div id="mascara"></div>')
		.css({
		    opacity: 0.8,
		    width: $(document).width(),
		    height: $(document).height()
		})
		.appendTo('body').hide();
            $('.foto').click(function (event) {
                event.preventDefault();
                $('#mascara').fadeIn(1000);
                $('<img class="foto-ampliada" />')
			.attr('src', $(this).attr('src'))
			.css({
			    left: ($(document).width() / 2 - 250),
			    top: ($(document).height() / 2 - 186)
			}).appendTo('body').click(function () {
			    $(this).fadeOut(1000);
			    $('#mascara').fadeOut(1500);
			});
            });
        });
   // ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div id="dvOcorrencia" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend title="Abrir Ocorrência" class="accordionContent">Reclamação Aberta: </legend>
            <br />
            <strong>Nº</strong><b>&nbsp;&nbsp;</b><asp:Label ID="lblOcorrencia" runat="server"
                Font-Bold="True" CssClass="style1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <div id="dvVoltar" runat="server" style="position: absolute; top: 165px; left: 1005px;">
                <asp:LinkButton ID="lnkVoltar" runat="server" CssClass="accordionContent" Height="16px"
                    OnClick="lnkVoltar_Click" Width="40px">Voltar</asp:LinkButton>
            </div>
            <hr style="border: 1px inset #A6A6A6; background-color: #FFFFFF;" />
            <table width="100%" border="0" cellspacing="0" cellpadding="10">
                <tr>
                    <td width='100' valign="top" style="font-size: 14px;">
                        ASSUNTO:
                    </td>
                    <td valign="top" style="font-size: 14px;">
                        <strong>
                            <asp:Label ID="lblAssunto" runat="server" Text="Label" Font-Bold="False"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="font-size: 14px;">
                        Data Abertura:
                    </td>
                    <td valign="top" style="font-size: 14px;">
                        <asp:Label ID="lblDataAbertura" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="dvCabecalho" style="position: relative;" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent"><span class="icon-article"></span>
                <asp:Label ID="lblMorador" runat="server"></asp:Label>
                Bloco:
                <asp:Label ID="lblBlocoMsg" runat="server"></asp:Label>
                Apartamento:
                <asp:Label ID="lblApartamento" runat="server"></asp:Label>
            </legend>
            <div id="tudo" runat="server">
                <asp:Label ID="lblMensagem" runat="server" Text="lblMensagem"></asp:Label>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="65px" Width="74px" CssClass="foto left" />
                <br />
                <br />
                <br />
                <asp:LinkButton ID="lnkDonwloadEvidencia" runat="server" OnClick="lnkDonwloadEvidencia_Click">  
                    
                   
                   Baixar Imagem </asp:LinkButton>
            </div>
        </fieldset>
    </div>
    <div id="DivRespostaAutomatica" style="position: relative;" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Atendimento Administrador do Condomínio</legend>
            Prezado Morador<br />
            Sua 
            reclamação foi recebida, e em breve retornarei. Obrigado por entrar em contato.
            <br />
            Att<br>
            Administrador
            <h3>
                Administrador do Condomínio</h3>
        </fieldset>
    </div>
    <div style="border: 1px solid #CCC; padding: 20px; margin-bottom: 20px;" runat="server"
        id="DivRespostaSindico1">
        Prezado
        <asp:Label ID="lblMoradorResposta" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblResposta" runat="server" Text=""></asp:Label>
        Att Administrador</div>
</asp:Content>
