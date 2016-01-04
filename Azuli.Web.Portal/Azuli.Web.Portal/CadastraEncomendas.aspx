<%@ Page Title="" Language="C#" MasterPageFile="~/PageAcessControl.Master" AutoEventWireup="true" 
    CodeBehind="CadastraEncomendas.aspx.cs" Inherits="Azuli.Web.Portal.CadastraEncomendas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 118px;
        }
        .style2
        {
            width: 780px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <br />
                <br />
                <div>
                
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                    <table style="width:100%;">
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label1" runat="server" Text="Bloco"></asp:Label>
                            </td>

                            <td class="style2">
                                <asp:TextBox ID="txtBloco" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label2" runat="server" Text="Apartamento"></asp:Label>
                            </td>
                            
                            <td class="style2">
                                <asp:TextBox ID="txtApartamento" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label3" runat="server" Text="Data Recebimento"></asp:Label>
                            </td>
                            
                            <td class="style2">
                                <asp:TextBox ID="txtDataRecebimento" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label4" runat="server" Text="Descrição da encomenda"></asp:Label>
                            </td>
                            
                            <td class="style2">
                                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label5" runat="server" Text="Encomenda Entregue?"></asp:Label>
                            </td>
                            
                            <td class="style2">
                                <asp:TextBox ID="txtEntregue" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label6" runat="server" Text="Quem pegou"></asp:Label>
                            </td>
                            
                            <td class="style2">
                                <asp:TextBox ID="txtQuemPegou" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label7" runat="server" Text="Quando Pegou"></asp:Label>
                            </td>
                            
                            <td class="style2">
                                <asp:TextBox ID="txtQuandoPegou" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label8" runat="server" Text="Usuário que baixou"></asp:Label>
                            </td>
                            
                            <td class="style2">
                                <asp:TextBox ID="txtQuemBaixou" runat="server"></asp:TextBox></td>
                        </tr>  
                        <tr>
                            <td class="style1">
                               <asp:Button ID="btnSalvar" runat="server" Text="Finalizar Cadastro" 
                                OnClick="btnSalvar_Click" CssClass="btGeral" Font-Bold="True" Height="37px" 
                                Width="135px" BackColor="#CCCCCC" />
                            </td>
                            
                            <td class="style2">
                                <asp:Button ID="btnVoltar" runat="server" Height="31px" Text="Voltar" 
                                    CssClass="btGeral" Font-Bold="True" 
                                    Width="135px" BackColor="#CCCCCC" />
                                </td>
                        </tr>                                                                                                                                               
                    </table>
                <br />
                <br />



                </div>

                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
