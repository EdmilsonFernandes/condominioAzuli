<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="anunciarClassificado.aspx.cs" Inherits="Azuli.Web.Portal.anunciarClassificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            height: 8px;
        }
        .style5
        {
            font-size: x-small;
            font-weight: bold;
        }
        .style6
        {
            background-color: #BFCBD6;
            border-left: 1px dotted #999999;
            border-right: 1px dotted #999999;
            border-bottom: 1px dotted #999999;
            padding: 3px 3px 3px 3px;
            font-family: Verdana;
            font-size: small;
            color: #0000FF;
            border-radius: 1em;
            width: 520px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    
   
    <fieldset class="loginDisplayLegend">
                <legend title="Abrir Ocorrência" class="accordionContent" align="left"> O que deseja anunciar? - Bloco:
                    <asp:Label ID="lblDescBloco" runat="server" Text="Label"></asp:Label>
      - Apartamento:
                    <asp:Label ID="lblDescApartamento" runat="server" Text="Label"></asp:Label></legend>
        <div id="dvGrupo" runat="server" align="left" dir="ltr">
           
                  
                <br />

           
          <center>  <table  class="watermarked" cellpadding="-2px" align="center">
                    <tr>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgImoveis"  runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/imoveis.jpg"
                                Width="155px" CssClass="Border" onclick="imgImoveis_Click" />
                            &nbsp;
                            <br />
                            <asp:Label ID="lblImoveis" runat="server" CssClass="style5"></asp:Label>
                        </td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgVeiculos" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/veiculo.jpg"
                                Width="155px" CssClass="Border" onclick="imgVeiculos_Click" />
                            &nbsp;
                            <br />
                            <asp:Label ID="lblVeiculos" runat="server" CssClass="style5"></asp:Label>
                        </td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgNegocios" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/neogico2.jpg"
                                Width="155px" CssClass="Border" onclick="imgNegocios_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblNegocio" runat="server" CssClass="style5"></asp:Label>
                        </td>
                    </tr>
                   
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgEletronicoCelulares" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/eletronico.jpg"
                                Width="155px" CssClass="Border" onclick="imgEletronicoCelulares_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lbleletronico" runat="server" CssClass="style5"></asp:Label>
                        </td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgCasa" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/parasuacasa.jpg"
                                Width="155px" CssClass="Border" onclick="imgCasa_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblParaSuaCasa" runat="server" CssClass="style5"></asp:Label>
                        </td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgModaBeleza" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/modabeleza2.jpg"
                                Width="155px" CssClass="Border" onclick="imgModaBeleza_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblModa" runat="server" CssClass="style5"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgMusicaHobbie" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/musicaHobie.jpg"
                                Width="155px" CssClass="Border" onclick="imgMusicaHobbie_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblMusica" runat="server" CssClass="style5"></asp:Label>
                        </td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgAnimaisAcessorios" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/animais.jpg"
                                Width="155px" CssClass="Border" onclick="imgAnimaisAcessorios_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblAnimal" runat="server" CssClass="style5"></asp:Label>
                        </td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgBebeCrianca" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/bebeCrianca.jpg"
                                Width="155px" CssClass="Border" onclick="imgBebeCrianca_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblCrianca" runat="server" CssClass="style5"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" align="center">
                            &nbsp;
                        </td>
                        <td class="style4">
                        </td>
                        <td class="style4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="imgSport" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/doacao.gif"
                                Width="155px" CssClass="Border" onclick="imgSport_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblSport" runat="server" CssClass="style5"></asp:Label>
                            <br />
                            <br />
                            <br />
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="imgDiversos" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/diversos.jpg"
                                Width="155px" CssClass="Border" onclick="imgDiversos_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblDiversos" runat="server" CssClass="style5"></asp:Label>
                           <br />
                            <br />
                            <br />
                        </td>
                        
                    </tr>
                  
                </table> </center></div>
                
            </fieldset>
<center><div  id="dvAnunciar"  runat="server" align="center" dir="ltr">
       
   <center>  <fieldset class="loginDisplayLegend">
         <legend class="accordionContent" align="left"><strong>Seus Classifcados Ativos</strong></legend>
            <br />
        <center>  
            <asp:GridView ID="grdClassificado" runat="server" AutoGenerateColumns="False" 
                CssClass="gridl" Width="756px" 
                EmptyDataText="Você não tem Anúncios publicados!!">
                <Columns>
                    <asp:TemplateField HeaderText="Código" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" 
                                Text='<%# Bind("idClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("idClassificado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField DataImageUrlField="classificadoimg1" HeaderText="Foto" 
                        DataImageUrlFormatString="~/ServerFile/Classificados/{0}">
                        <ControlStyle Width="40px" />
                    </asp:ImageField>
                    <asp:TemplateField HeaderText="Descrição">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" 
                                Text='<%# Bind("assuntoClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" 
                                Text='<%# Bind("assuntoClassificado") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="True" Font-Size="X-Small" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor R$">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" 
                                Text='<%# Bind("valorVendaClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" 
                                Text='<%# Bind("valorVendaClassificado","{0:N2}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data do anúncio">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" 
                                Text='<%# Eval("dataClassificado", "{0:dddd}") + " / " + Eval("dataClassificado","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server"  Text='<%# Eval("dataClassificado", "{0:dddd}") + " - " + Eval("dataClassificado","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="idClassificado" 
                        DataNavigateUrlFormatString="~/GerenciarClassificadoMorador.aspx?codigo={0}" 
                        Text="Ver ...">
                    <HeaderStyle Font-Bold="False" />
                    <ItemStyle ForeColor="#0033CC" />
                    </asp:HyperLinkField>
                </Columns>
            </asp:GridView> </center> 
       
   </fieldset></center>   </div></center>
</asp:Content>
