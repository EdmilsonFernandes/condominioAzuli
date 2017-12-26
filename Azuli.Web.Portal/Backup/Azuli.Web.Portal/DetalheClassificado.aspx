<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DetalheClassificado.aspx.cs" Inherits="Azuli.Web.Portal.DetalheClassificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            height: 21px;
        }
        .style5
        {
            font-weight: bold;
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
    
    <div id="imgAnuncio" style="position:absolute;top: 138px; left: 696px;">
    
    <asp:Image style='position:absolute; top:43px; left:285px;' ID="imgGrupo" 
            runat="server" Height="44px" Width="153px" />
    </div>
    <center>
    <div id="dvAnunciar" runat="server" align="center">
    
      <center>  <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Detalhes do Anúncio: &nbsp;&nbsp;&nbsp;<font 
                    size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </font>
                
            </legend>
            <table class="accordionContent" style="width: 798px">
                <tr>
                    <td>
                        <asp:Label ID="lblAssunto" runat="server" 
                            style="font-weight: 700; font-size: small; color: #666666;"></asp:Label>
                    </td>
                    <td align="right" class="">
                        &nbsp;
                        <asp:Label ID="lblValor" runat="server" 
                            style="font-weight: 700; font-size: medium; color: #666666;" 
                            ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                
            </table>
      
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            
           
  
    
    <div id="Div1" 
        style="position:absolute; top: 559px; left: 946px; width: 190px;" 
        runat="server"> 
        <asp:Label ID="lblContador" runat="server" 
            Text="Anúncio visto 0 veze(s)" Font-Bold="True" ForeColor="Blue" 
            CssClass="accordionContent"></asp:Label></div>
    <div id="dvImagens" 
        style="position:absolute; top: 244px; left: 244px; width: 548px;" 
        runat="server">
    
    
    
    
        <table id="tbImagem" runat="server" class="style2">
            <tr>
                <td>
                    <asp:ImageButton ID="ImageButton4" CssClass="foto left" runat="server" Height="70px" Width="70px" />
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton3" CssClass="foto left" runat="server" Height="70px" Width="70px" />
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton2" CssClass="foto left" runat="server" Height="70px" Width="70px" />
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton1" CssClass="foto left" runat="server" Height="70px" Width="70px" />
                </td>
            </tr>
        </table>
    
    
  
    
    
        
         
    
        
       
    
    </div>
        <br /> 
         <table class="ContextMenuPanel">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblDescricao" runat="server" style="font-weight: 700"></asp:Label>
                
                    <hr />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Apartamento:
                   <asp:Label ID="lblApartamento" runat="server" CssClass="style5"></asp:Label></td>
                <td>
                    Bloco:
                    <asp:Label ID="lblBloco" runat="server" CssClass="style5"></asp:Label></td>
            </tr>
            <tr>
                <td class="style3">
                    Telefone:
                    <asp:Label ID="lblTel" runat="server" CssClass="style5"></asp:Label></td>
                <td class="style3">
                    Celular:
                    <asp:Label ID="lblCel" runat="server" CssClass="style5"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    E-mail: <asp:Label ID="lblEmail" runat="server" CssClass="style5"></asp:Label></td>
                <td>
                    Data:
                    <asp:Label ID="lblData" runat="server" CssClass="style5"></asp:Label></td>
            </tr>
        </table>
      <br />
             <br />
                    <br />
                 
    <asp:Button ID="Button1" runat="server" Text="Voltar" 
        CssClass="btGeral" onclick="Button1_Click" Width="86px" /> 
    
    <div id="dvVeiculo" style="position: absolute; top: 151px; left: 398px; color: #0033CC;
        height: 23px; width: 205px; font-weight: 700;">
    </div>
        <br />
                    <br />
                    <br />
                        <br />
                  
                  
      </fieldset></center>
          </div></center>
</asp:Content>
