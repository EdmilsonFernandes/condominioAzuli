<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="enviaMensagemMorador.aspx.cs" Inherits="Azuli.Web.Portal.enviaMensagemMorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style5
    {
        width: 634px;
    }
    .style6
    {
        width: 636px;
    }
        .style9
        {
            width: 780px;
        }
        .style10
        {
            height: 28px;
        width: 44px;
    }
        .style11
        {
            border-style: outset;
            border-color: inherit;
            border-width: 2px;
            background-color: White;
            font-family: Verdana;
            font-size: 12px;
            color: Black;
            margin-top: 0px;
            margin-right: 0px;
            width: 1049px;
        }
    .style12
    {
        width: 44px;
    }
    .style13
    {
        width: 75px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  

   
    
 
   <br /><br />
  <div id="dvMsg" align="center"  runat="server"> 
  

  <fieldset class="loginDisplayLegend" >
   <legend class="accordionContent">Enviar mensagem para Morador:</legend>
   <br />
   
  
      <center>
          <table>
          
            <tr>
                <td class="style11">
                    <table border='0'>
                        <tr>
                            <td class="style13">
                                <asp:Label ID="lblPara" runat="server" style="font-weight: 700" 
                                    Text="Para:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblBloco" runat="server" CssClass="style5" Text="Bloco:"></asp:Label>
&nbsp;<asp:DropDownList ID="drpBloco" runat="server" DataSourceID="SqlDataSourceBloco" 
                                    DataTextField="BLOCO" DataValueField="BLOCO" Height="25px" 
                                    CssClass="AlternatingRowStyle" Width="108px"  AppendDataBoundItems="True" 
                                    AutoPostBack="True" onselectedindexchanged="drpBloco_SelectedIndexChanged">
                                      <asp:ListItem Value="T">Todos</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                                <asp:Label ID="lblAp" runat="server" CssClass="style6" style="font-weight: 700" 
                                    Text="Apartamento:"></asp:Label>
&nbsp;<asp:DropDownList ID="drpMsg" runat="server" DataSourceID="SqlDataSourceAP" 
                                    DataTextField="APARTAMENTO" DataValueField="APARTAMENTO" Height="25px" 
                                    CssClass="AlternatingRowStyle" Width="103px"  AppendDataBoundItems="True" 
                                    AutoPostBack="True" onselectedindexchanged="drpMsg_SelectedIndexChanged">
                                      <asp:ListItem Value="T">Todos</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;
                                &nbsp;
                                </td>
                            
                        </tr>
                        <tr>
                        <td>
                                <asp:Label ID="lblAssunto0" runat="server" Font-Bold="True" 
                                Text="Dados do Morador:"></asp:Label>
                        </td>
                            <td align="left">
                                <asp:Label ID="lblMorador" runat="server" style="font-weight: 700"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblEmailResult" runat="server" style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                <asp:Label ID="lblAssunto" runat="server" Font-Bold="True" Text="Assunto:"></asp:Label>
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="txtAssunto" runat="server" Height="16px" Width="593px"></asp:TextBox>
                            </td>
                            <td class="style10">
                                 <asp:RequiredFieldValidator ID="rfvDescription0" runat="server" 
                                     ControlToValidate="txtAssunto" ErrorMessage="*" 
                                     Font-Bold="True" ForeColor="Red" ValidationGroup="validaDescricao"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                <asp:Label ID="lblMensagem" runat="server" Font-Bold="True" 
                                    Text="Mensagem"></asp:Label>
                            </td><br />
                            <td class="style9">
                                 <asp:TextBox ID="txtDescription" runat="server" Height="95px" TextMode="MultiLine" 
                                     Width="593px"></asp:TextBox>
                            </td>
                            <td class="style12">
                                 <asp:RequiredFieldValidator ID="rfvDescription" runat="server" 
                                     ControlToValidate="txtDescription" ErrorMessage="*" 
                                     Font-Bold="True" ForeColor="Red" ValidationGroup="validaDescricao"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                &nbsp;</td>
                            <td class="style9">
                                &nbsp;</td>
                            <td class="style12">
                                &nbsp;</td>
                        </tr>
                        </table>
                   
                    <br />
                                <asp:SqlDataSource ID="SqlDataSourceAP" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:azulli %>" 
                                    SelectCommand="LISTA_APARTAMENTO" SelectCommandType="StoredProcedure">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSourceBloco" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:azulli %>" SelectCommand="LISTA_BLOCO" 
                                    SelectCommandType="StoredProcedure"></asp:SqlDataSource>
               <center>    
                
                   <asp:Button ID="btnMensagem" runat="server" CssClass="botao" Text="Enviar mensagem" 
                        Width="150px"  
                        ValidationGroup="validaDescricao" onclick="btnMensagem_Click" 
                       Height="17px" />
&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="btnLimpar" runat="server" CssClass="botao" 
                        Text="Limpar Campos" Height="19px" Width="121px" /></center>
                </td>
            </tr>
        </table><br /><br /><br />
           <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label> 
     
      <br />
     </center><br />
   
  </fieldset>  </div>

     
</asp:Content>
