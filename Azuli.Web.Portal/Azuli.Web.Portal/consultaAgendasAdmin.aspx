<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="consultaAgendasAdmin.aspx.cs" Inherits="Azuli.Web.Portal.consultaAgendasAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
    <fieldset class="login">
        <legend>Consulta de Reservas: </legend>

        <table class="style1">
        <tr>
            <td class="style3">
                <asp:Label ID="lblMes" runat="server" Font-Bold="True" Text="Mês:"></asp:Label><asp:DropDownList ID="drpMeses" runat="server" CssClass="btGeral" Font-Bold="True" 
                    Height="16px" Width="101px">
                </asp:DropDownList>
            </td>
            <td class="style3">
                <asp:Label ID="lblAno" runat="server" Font-Bold="True" Text="Ano:"></asp:Label>
                <asp:DropDownList ID="drpAno" runat="server" CssClass="btGeral" 
                    Font-Bold="True" Height="16px" Width="101px">
                </asp:DropDownList>
                </td>
            <td>
                <asp:Label ID="lbSalao" runat="server" Font-Bold="True" Text="Salão de:"></asp:Label>
                <asp:DropDownList ID="drpSalao" runat="server" CssClass="btGeral" 
                    Font-Bold="True" Height="19px" Width="127px">
                    <asp:ListItem Value="0">Selecione</asp:ListItem>
                    <asp:ListItem>Festa</asp:ListItem>
                    <asp:ListItem>Churrasqueira</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnPesquisar" runat="server" CssClass="botao" 
                    Text="Pesquisar" onclick="btnPesquisar_Click" />
            </td>
        </tr>
    </table>
    </fieldset>
    <center><div id="dvFesta" runat="server">&nbsp;<asp:GridView ID="grdAgendaMorador" runat="server" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="dataAgendamento" HeaderText="Data de Agendamento" 
                DataFormatString="{0:dd/MM/yyyy}" />
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
            <asp:BoundField DataField="salaoFesta" HeaderText="Salão de Festa" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                DeleteImageUrl="~/images/delete.png" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
&nbsp; </div></center>

<center><div id="dvChurrasco" runat="server">   

&nbsp;<asp:GridView ID="grdChurras" runat="server" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="dataAgendamento" HeaderText="Data de Agendamento" 
                DataFormatString="{0:dd/MM/yyyy}" />
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
            <asp:BoundField DataField="salaoChurrasco" HeaderText="Churrasqueira" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                DeleteImageUrl="~/images/delete.png" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>




</div></center>

</asp:Content>
