<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OcorrenciaMorador.aspx.cs" Inherits="Azuli.Web.Portal.OcorrenciaMorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 211px;
            margin-top: 0px;
        }
        .style5
        {
            font-weight: bold;
            background-color: #FFFFFF;
        }
        .style6
        {
            background-color: #FFFFFF;
        }
        .style14
        {
            height: 65px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<fieldset class="loginDisplayLegend">
   
    <legend title="Abrir Ocorrência" class="accordionContent"> Abrir Reclamação</legend><br />
   <center><asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label></center>
      
   
  <div id="dvCadastro" runat="server" align="left" > 
   
      <table>
            <tr>
                <td class="" align="center">
                    <table border='0' class="GridView">
                        <tr>
                            <td class="">
                                <asp:Label ID="lblOcorrencia" runat="server" style="font-weight: 700" 
                                    Text="Reclamação aberta será para:"></asp:Label>
                            </td>
                            <td class="" align="left">
                                <asp:Label ID="lblBloco" runat="server" CssClass="style5" Text="Bloco:"></asp:Label>
&nbsp;<asp:Label ID="lblDescBloco" runat="server" CssClass="style5"></asp:Label>
&nbsp;-
                                <asp:Label ID="lblAp" runat="server" CssClass="style6" style="font-weight: 700" 
                                    Text="Apartamento:"></asp:Label>
&nbsp;<asp:Label ID="lblDescApartamento" runat="server" CssClass="style5"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="">
                                <asp:Label ID="lblAssunto" runat="server" Font-Bold="True" Text="Assunto:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpListSubject" runat="server" Height="29px" Width="609px" 
                                    DataSourceID="SqlDataSourceTipoOcorrencia" DataTextField="DescricaoOcorrencia" 
                                    DataValueField="idTipoOcorrencia" CssClass="btGeral" 
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Value="-1">Selecionar assunto ..</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                <asp:Label ID="lblDescricao" runat="server" Font-Bold="True" 
                                    Text="Descrição da Reclamação:"></asp:Label>
                            </td>
                            <td class="style14">
                                 <asp:TextBox ID="txtDescription" runat="server" Height="88px" TextMode="MultiLine" 
                                     Width="602px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="">
                                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" 
                                    Text="Evidência/Imagem"></asp:Label>
                            </td>
                            <td class="">
                                <asp:FileUpload ID="fileImagem" runat="server" Height="24px" Width="387px" 
                                    CssClass="botao" />
                            </td>
                            
                        </tr>
                        </table>
                    <br />
                    
                    <asp:Button ID="btnOcorrencia" runat="server" CssClass="botao" Text="Gerar ocorrência" 
                        Width="150px"  
                        ValidationGroup="validaDescricao" onclick="btnOcorrencia_Click" />
&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="btnLimpar" runat="server" CssClass="botao" 
                        Text="Limpar Campos" />
                </td>
            </tr>
        </table>
                                 </div>   <br />
                             <center><asp:RequiredFieldValidator ID="rfvDescription" runat="server" 
                                     ControlToValidate="txtDescription" ErrorMessage="Favor descrever a Ocorrência" 
                                     Font-Bold="True" ForeColor="Red" 
          ValidationGroup="validaDescricao"></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="SqlDataSourceTipoOcorrencia" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:azulli %>" 
                                    SelectCommand="SELECT * FROM [TIPO_OCORRENCIA]"></asp:SqlDataSource></center>
      
    
  
  </fieldset>

</asp:Content>
