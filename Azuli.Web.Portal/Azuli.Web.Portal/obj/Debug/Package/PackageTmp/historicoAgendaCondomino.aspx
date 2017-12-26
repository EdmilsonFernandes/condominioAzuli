<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="historicoAgendaCondomino.aspx.cs" Inherits="Azuli.Web.Portal.historicoAgendaCondomino" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<fieldset id="Fieldset1" class="login" runat="server"> 
        <legend class="accordionContent">Histórico de cancelamentos: </legend>
        <br />
      <div id="dvReservaMes" runat="server" align="left">
      
     <center>  <table class="accordionContent">
            <tr>
                <td class="style3">
                    <asp:Label ID="lblMes" runat="server" Font-Bold="True" Text="Mês:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="drpMeses" runat="server" CssClass="dropdown" Font-Bold="True"
                        Height="16px" Width="101px" AutoPostBack="True" >
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    <asp:Label ID="lblAno" runat="server" Font-Bold="True" Text="Ano:"></asp:Label>
                    <asp:DropDownList ID="drpAno" runat="server" CssClass="dropdown" Font-Bold="True"
                        Height="16px" Width="101px" AutoPostBack="True" > 
                       
                    </asp:DropDownList>
                   
                </td>
                
                 
            </tr>
        </table></center> </div>
        <br />
        <hr />
   
  <center><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CssClass="gridl" DataSourceID="SqlDataSourceCancelamento"  EmptyDataText="Não existem cancelamentos para esta consulta" >
        <Columns>
            <asp:BoundField DataField="bloco" HeaderText="Bloco" SortExpression="bloco" >
             <ItemStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
            </asp:BoundField>


            <asp:BoundField DataField="ap" HeaderText="Apartamento" SortExpression="ap">
             <ItemStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
             </asp:BoundField>

            <asp:BoundField DataField="area" HeaderText="Descrição do Cancelamento" SortExpression="area" />
            <asp:TemplateField HeaderText="Data de Agendamento" 
                SortExpression="data_agendameto">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("data_agendameto", "{0:ddd}") + "-" + Eval("data_agendameto","{0:dd/MM/yy}") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("data_agendameto", "{0:ddd}") + "-" + Eval("data_agendameto","{0:dd/MM/yy}") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle BackColor="#339933" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Data de Cancelamento" 
                SortExpression="data_cancelamento">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        Text='<%# Eval("data_cancelamento", "{0:ddd}") + "-" + Eval("data_cancelamento","{0:dd/MM/yy}") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_cancelamento", "{0:ddd}") + "-" + Eval("data_cancelamento","{0:dd/MM/yy}") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle BackColor="Red" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView></center>  
     </fieldset>
   
<asp:SqlDataSource ID="SqlDataSourceCancelamento" runat="server" 
    ConnectionString="<%$ ConnectionStrings:azulli %>" 
    SelectCommand="SP_buscaHistoricoCancelamento" 
    SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="drpMeses" DefaultValue="1" Name="mes" 
            PropertyName="SelectedValue" Type="Int32" />
        <asp:ControlParameter ControlID="drpAno" DefaultValue="2013" Name="ano" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
   
</asp:Content>


