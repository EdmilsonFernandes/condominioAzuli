<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detalheOcorrencia.aspx.cs" Inherits="Azuli.Web.Portal.detalheOcorrencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
   
   
 <fieldset class="loginDisplayLegend">
  <asp:Label ID="lblMeses" runat="server" 
        Text="Ocorrência no mês de:" Font-Bold="True" ForeColor="Black"></asp:Label>
&nbsp;<asp:DropDownList ID="drpMeses" runat="server" Height="18px" Width="243px" 
                CssClass="btGeral" AutoPostBack="True" 
                onselectedindexchanged="drpMeses_SelectedIndexChanged" 
         Font-Bold="True">
    </asp:DropDownList>
            &nbsp;<asp:Label ID="lblAno" runat="server" Font-Bold="True" Text="Ano:" 
         ForeColor="Black"></asp:Label>
                    <asp:DropDownList ID="drpAno" runat="server" CssClass="btGeral" Font-Bold="True"
                        Height="16px" Width="101px" AutoPostBack="True" onselectedindexchanged="drpAno_SelectedIndexChanged" 
                        >
                    </asp:DropDownList>
            <br />
            <br />
   
    <legend title="Abrir Ocorrência" class="accordionContent"> Abrir Reclamação</legend>
    <br />
    <asp:GridView ID="grdOcorrencias" runat="server" 
                CssClass="GridView" Width="809px" AutoGenerateColumns="False" 
         onrowcommand="grdOcorrencias_RowCommand" DataKeyNames="codigoOcorrencia" 
         EmptyDataText="Não existem Reclamações aberta neste mês !!"> 
        <Columns>
            <asp:BoundField  DataField="codigoOcorrencia" HeaderText="Ocorrência" />
            <asp:TemplateField HeaderText="Data">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataOcorrencia") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"  Text='<%# Eval("dataOcorrencia", "{0:dddd}") + " / " + Eval("dataOcorrencia","{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="descricaoOcorrencia" HeaderText="Assunto" />
            <asp:BoundField DataField="statusOcorrencia" HeaderText="Status" />
            <asp:ButtonField ButtonType="Image" ImageUrl="~/images/ico_search.gif" 
                Text="Button" />
        </Columns>
    </asp:GridView>
    </fieldset>
  
</asp:Content>
