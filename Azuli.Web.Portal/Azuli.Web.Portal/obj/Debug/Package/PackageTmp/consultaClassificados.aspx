<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consultaClassificados.aspx.cs" Inherits="Azuli.Web.Portal.consultaClassificados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            height: 3px;
        }
        .style5
        {
            font-size: small;
            font-weight: bold;
            color: #577EA7;
           
        }
      .style6
      {
          font-size: x-small;
      }
        .style7
        {
            background-color: #BFCBD6;
            border-left: 1px solid #0093d4;
    border-right: 1px solid #0093d4;
    border-bottom: 1px solid #0093d4;
    border-top:  1px solid #0093d4;
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
 <div id="dvGrupo" runat="server" align="left" dir="ltr">
     <fieldset class="loginDisplayLegend">
                <legend title="Abrir Ocorrência" class="accordionContent"> O que você está procurando?</legend>
       
          <center> 
                <br />

           
          <center>  <table  class="watermarked" cellpadding="-2px" align="center">
                    <tr>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgImoveis" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/imoveis.jpg"
                                Width="155px" CssClass="Border" onclick="imgImoveis_Click1" />
                            &nbsp;
                            <br />
                            <asp:Label ID="lblImoveis" runat="server" CssClass="style5" ></asp:Label>
                                
                        </td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgVeiculos" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/veiculo.jpg"
                                Width="155px" CssClass="Border" onclick="imgVeiculos_Click" />
                            &nbsp;
                            <br />
                            <asp:Label ID="lblVeiculos" runat="server" CssClass="style5"></asp:Label>
                            <strong><span class="style6">&nbsp;</span></strong></td>
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
                        &nbsp;</td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgCasa" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/parasuacasa.jpg"
                                Width="155px" CssClass="Border" onclick="imgCasa_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblParaSuaCasa" runat="server" CssClass="style5"></asp:Label>
                        &nbsp;</td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgModaBeleza" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/modabeleza2.jpg"
                                Width="155px" CssClass="Border" onclick="imgModaBeleza_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblModa" runat="server" CssClass="style5"></asp:Label>
                        &nbsp;</td>
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
                        &nbsp;</td>
                        <td align="center">
                            <br />
                            <asp:ImageButton ID="imgBebeCrianca" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/bebeCrianca.jpg"
                                Width="155px" CssClass="Border" onclick="imgBebeCrianca_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblCrianca" runat="server" CssClass="style5"></asp:Label>
                            <span class="style6">&nbsp;</span></td>
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
                            &nbsp;<br />
                            <br />
                            <br />
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="imgDiversos" runat="server" Height="44px" ImageUrl="~/ServerFile/Classificados/diversos.jpg"
                                Width="155px" CssClass="Border" onclick="imgDiversos_Click" />
                            &nbsp;<br />
                            <asp:Label ID="lblDiversos" runat="server" CssClass="style5"></asp:Label>
                            <br />
                        &nbsp;</td>
                        
                    </tr>
                  
                </table> </center>
                
           </center></div> </fieldset>
<center>



<div  id="dvAnunciar"  runat="server" align="center" dir="ltr">
       
   <center>  <fieldset class="loginDisplayLegend">
   <div id="dvVeiculo" 
           
           
           
           
           style="position:absolute; top: 150px; left: 269px; color: #0033CC; font-weight: 700; height: 20px;">
       <asp:Label ID="lblGrupo" runat="server" style="color: #333333"></asp:Label></div>
             
         <legend class="accordionContent"> 
            <div id="imgAnuncio"   
                 
                 style="position:absolute; top: 157px; left: 897px; color: #0033CC; font-weight: 700;"> <asp:Image ID="imgGrupo" runat="server" 
                    Height="44px" Width="155px" />  </div>
               </legend><br />
        <center>  
           
            <asp:GridView ID="grdClassificado" runat="server" AutoGenerateColumns="False"  EmptyDataText="Não existem Anúncios para esta consulta"
                CssClass="gridl">
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
                        <ControlStyle Width="60px" />
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
                        <ItemStyle Font-Bold="True" ForeColor="Black" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor R$">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" 
                                Text='<%# Bind("valorVendaClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" 
                                Text='<%# Bind("valorVendaClassificado","{0:N2}")%>'></asp:Label>
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
                        DataNavigateUrlFormatString="~/detalheClassificado.aspx?codigo={0}" 
                        Text="Clique para ver  o Anúncio">
                    <HeaderStyle Font-Bold="False" />
                    <ItemStyle ForeColor="Blue" Font-Bold="True" />
                    </asp:HyperLinkField>
                </Columns>
            </asp:GridView> </center> 
       
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       
    <asp:Button ID="Button1" runat="server" Text="Voltar" 
        CssClass="btGeral" onclick="Button1_Click" Width="86px" /> </fieldset></center>  </div></center>
</asp:Content>
