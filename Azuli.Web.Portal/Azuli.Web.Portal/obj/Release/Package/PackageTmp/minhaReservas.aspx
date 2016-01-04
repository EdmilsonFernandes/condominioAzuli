<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="minhaReservas.aspx.cs" Inherits="Azuli.Web.Portal.minhaReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <fieldset class="loginDisplayLegend">
        <legend  class="accordionContent">Reserva do Mês Geral: </legend><br />
        <table style="width: 565px">
            <tr>
                <td >
                    <asp:Label ID="lblMes" runat="server" Font-Bold="True" Text="Mês:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="drpMeses" runat="server" CssClass="btGeral" Font-Bold="True"
                        Height="16px" Width="101px" AutoPostBack="True" 
                        onselectedindexchanged="drpMeses_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td  >
                    <asp:Label ID="lblAno" runat="server" Font-Bold="True" Text="Ano:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="drpAno" runat="server" CssClass="btGeral" Font-Bold="True"
                        Height="16px" Width="111px" AutoPostBack="True" 
                        onselectedindexchanged="drpAno_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="lbSalao" runat="server" Font-Bold="True" Text="Área :"></asp:Label>
                    <asp:DropDownList ID="drpSalao" runat="server" CssClass="btGeral" Font-Bold="True"
                        Height="19px" Width="127px" AutoPostBack="True" OnSelectedIndexChanged="drpSalao_SelectedIndexChanged">
                        <asp:ListItem Value="1">todas</asp:ListItem>
                        <asp:ListItem>Festa</asp:ListItem>
                        <asp:ListItem>Churrasqueira</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </fieldset>



    <div id="dvFesta" runat="server" align="left" dir="ltr">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">São de Festas - <asp:Label ID="lblMesAnoFesta" runat="server" CssClass="FooterStyle"></asp:Label></legend>
               
            <center>
                <br />
                &nbsp;<br />
                &nbsp;<asp:GridView ID="grdAgendaMorador" runat="server" EmptyDataText="Você não tem reserva para o salão de festa nesta data"
                    AutoGenerateColumns="False" Font-Bold="False" OnRowCommand="grdAgendaMorador_RowCommand"
                    DataKeyNames="dataAgendamento" OnRowDeleting="grdAgendaMorador_RowDeleting" OnRowDataBound="grdAgendaMorador_RowDataBound"
                    CssClass="GridView">
                    <Columns>
                        <asp:TemplateField HeaderText="Data de Agendamento">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("dataAgendamento") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("dataAgendamento", "{0:dddd}") + " / " + Eval("dataAgendamento","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bloco">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ap.bloco") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apartamento">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ap.apartamento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/delete.png" />
                    </Columns>
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="#CC3300" />
                </asp:GridView></center>
                <br />
                &nbsp;
                <br />
        </fieldset>
    </div>


    <div id="dvChurrasco" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Área de Churrasco -
                <asp:Label ID="lbMesAnoChurras" runat="server" CssClass="FooterStyle"></asp:Label></legend>
            <center>
                <br />
                &nbsp;<asp:GridView ID="grdChurras" runat="server" AutoGenerateColumns="False" EmptyDataText="Você não tem reserva de churrasqueira para esta data"
                    OnRowCommand="grdChurras_RowCommand" OnRowDeleting="grdChurras_RowDeleting" DataKeyNames="dataAgendamento"
                    CssClass="GridView">
                    <Columns>
                        <asp:TemplateField HeaderText="Data de Agendamento">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("dataAgendamento") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("dataAgendamento", "{0:dddd}") + " / " + Eval("dataAgendamento","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bloco">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ap.bloco") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apartamento">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ap.apartamento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/delete.png" />
                    </Columns>
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="#CC3300" />
                </asp:GridView></center>
        </fieldset>
    </div>
  
    <center>
        <br />
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </center>
</asp:Content>
