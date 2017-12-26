<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ConfigurarValorReserva.aspx.cs" Inherits="Azuli.Web.Portal.ConfigurarValorReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            background-color: #F0F0F0;
            border-left: 2px solid #999999;
            border-right: 2px solid #999999;
            border-botom: 2px solid #999999;
            padding: 5px 5px 5px 5px;
            font-family: Verdana;
            font-size: 10pt;
            color: #666666;
            border-radius: 1em;
            height: 15px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    <fieldset class="loginDisplayLegend">
        <legend class="accordionContent">Cadastrar Área e Valor:</legend>

  <center><div id="dvProprietario" runat="server" >
   
        <br />
        <table class="accordionContent" dir="ltr" frame="border" style="width: 373px" >
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" 
                        Text="Área Comum" style="font-weight: 700; font-size: 10pt"></asp:Label>
                </td>
                <td class="left">
                    <asp:TextBox ID="txtArea" runat="server" Height="15px" 
                        Width="147px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNovaSenha" runat="server" 
                        CssClass="failureNotification" ErrorMessage="*" 
                        ValidationGroup="alteraSenha" ControlToValidate="txtArea"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Valor: " 
                        style="font-weight: 700; font-size: 10pt"></asp:Label>
                </td>
                <td class="left">
                    <asp:TextBox ID="txtValor" runat="server" Height="15px" Width="56px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRepitaNovaSenha" runat="server" 
                        CssClass="failureNotification" ErrorMessage="*" 
                        ValidationGroup="alteraSenha" ControlToValidate="txtValor"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnAlteraSenha" runat="server" CssClass="botao" Text="Cadastrar" 
                        Width="105px" 
                        ValidationGroup="alteraSenha" onclick="btnAlteraSenha_Click" />
                </td>  </tr>
              
        </table>
    </div></center><br /><center><asp:Label ID="lblMensagem" runat="server" CssClass="failureNotification"></asp:Label>
            <br />
            <br />
             <asp:ObjectDataSource ID="ObjectDataSourceLista" runat="server" 
               
                SelectMethod="oListaValorReserva" 
                UpdateMethod="alteraConfiguracaArea"
                DeleteMethod="deletaReserva"
                TypeName="Azuli.Web.Business.ConfiguracaoReservaBLL" 
                DataObjectTypeName="Azuli.Web.Model.ConfiguraReserva">
                </asp:ObjectDataSource>
            <asp:GridView ID="grdConfigArea" runat="server" 
                AutoGenerateColumns="False" CssClass="gridl" 
                DataSourceID="ObjectDataSourceLista" DataKeyNames="id_valor,area,valor">
                <Columns>

                     <asp:BoundField DataField="id_valor" HeaderText="id_valor" 
                        SortExpression="id_valor" Visible="False" />
                    <asp:BoundField DataField="area" HeaderText="Área" SortExpression="area" />
                    <asp:BoundField DataField="valor" HeaderText="Valor (R$)" SortExpression="valor" />
                    <asp:CommandField EditText="Alterar" ShowEditButton="True" ButtonType="Button" 
                        CancelImageUrl="~/images/cancelar.jpg" CancelText="Cancelar" 
                        EditImageUrl="~/images/edit.png" UpdateImageUrl="~/images/save.png" 
                        UpdateText="Salvar" HeaderText="Alteração de Valores" >
                    <ControlStyle BackColor="#0099CC" Font-Bold="True" ForeColor="White" />
                    <ItemStyle HorizontalAlign="Center" Width="180px" Font-Bold="True" 
                        ForeColor="White" />
                    </asp:CommandField>
                     <asp:CommandField ButtonType="Button" DeleteText="Excluir" 
                         ShowDeleteButton="True" HeaderText="Exclução de Área">
                     <ControlStyle BackColor="#0099CC" Font-Bold="True" ForeColor="White" />
                     <ItemStyle ForeColor="White" Width="120px" />
                     </asp:CommandField>
                </Columns>
            </asp:GridView>
           

            <br />



        </center> </fieldset>
</asp:Content>

