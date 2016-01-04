<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilMorador.aspx.cs" Inherits="Azuli.Web.Portal.PerfilMorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            height: 17px;
        }
        .style5
        {
            height: 17px;
            font-weight: bold;
            font-size: 10pt;
        }
        .style6
        {
            font-size: 10pt;
            font-weight: bold;
        }
        .style7
        {
            font-weight: bold;
            color: #3BA4CB;
            font-size: 10pt;
        }
        .style8
        {
            width: 100%;
        }
        .style9
        {
            color: #3BA4CB;
            font-size: 10pt;
        }
        .gridl
        {}
        .style10
        {
            width: 73px;
            height: 51px;
        }
        .style11
        {
            border: 1px solid #0093d4;
            background-color: #F0F0F0;
            padding: 5px 5px 5px 5px;
            font-family: Verdana;
            font-size: 9pt;
            color: #666666;
            behavior: url(border-radius.htc);
            border-radius: 1em;
            height: 15px;
        }
        .style12
        {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
<fieldset class="">    
<legend class="style11">Minhas Informações</legend>
   
    <table class="style8">
        <tr>
            <td align="left" class="style12" colspan="2">
                <img alt="" class="style10" src="images/cadastro.jpg" />
                <asp:Label ID="Label3" runat="server" CssClass="accordionContent" 
                    Font-Bold="True" Font-Size="Medium" Text="Seu Perfil "></asp:Label>
                <br />
                   <br />
                    
    
            </td>
            
        </tr>
        <tr>
            <td align="center">
<table class="accordionContent">
        <tr>
            <td class="style5" align="right">
                Nome:</td>
            <td class="style4" align="justify">
                <asp:Label ID="lblNome" runat="server" CssClass="style9" 
                    style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6" align="right">
                Bloco:</td>
            <td align="justify">
                <asp:Label ID="lblBloco" runat="server" CssClass="style7"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6" align="right">
                Apto:</td>
            <td align="justify">
                <asp:Label ID="lblApto" runat="server" CssClass="style7"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6" align="right">
                E-mail:</td>
            <td align="justify">
                <asp:Label ID="lblEmail" runat="server" CssClass="style9" 
                    style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        </table>
    
            </td>
            
            <td align="center" class="accordionContent">
          
            
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridl" 
                    DataKeyNames="PROPRIETARIO_BLOCO,PROPRIETARIO_AP" 
                    DataSourceID="sqlSourcePerfil" onrowcommand="GridView1_RowCommand" 
                    Width="690px" onrowediting="GridView1_RowEditing" 
                    onrowupdated="GridView1_RowUpdated" onrowupdating="GridView1_RowUpdating">
        <Columns>
            <asp:BoundField DataField="PROPRIETARIO_BLOCO" HeaderText="Bloco" 
                ReadOnly="True" SortExpression="PROPRIETARIO_BLOCO" >
            <ItemStyle Font-Bold="True" Height="30px" Width="30px" />
            </asp:BoundField>
            <asp:BoundField DataField="PROPRIETARIO_AP" HeaderText="Apto" 
                ReadOnly="True" SortExpression="PROPRIETARIO_AP" >
            <ItemStyle Font-Bold="True" Height="30px" Width="30px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Nome" SortExpression="NOME_PROPRIETARIO1">
                <EditItemTemplate>
                    <asp:TextBox Font-Bold="true" CssClass="accordionContent" ID="TextBox2" runat="server" 
                        Text='<%# Bind("NOME_PROPRIETARIO1") %>'></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="Campo Obrigatório!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("NOME_PROPRIETARIO1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                <EditItemTemplate>
                    <asp:TextBox Font-Bold="true" Width="210px" CssClass="accordionContent" ID="TextBox1" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="E-mail Inválido" Font-Bold="True" 
                        ForeColor="Red" 
                        ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"></asp:RegularExpressionValidator>
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                        ForeColor="#FF3300" ShowMessageBox="True" ShowSummary="False" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="180px" />
            </asp:TemplateField>
            <asp:CommandField CancelText="Cancelar" EditText="Alterar meus dados" 
                ShowEditButton="True" UpdateText="Salvar" ButtonType="Button" >
            <ControlStyle BackColor="#3BA4CB" Font-Bold="True" Font-Size="Small" 
                ForeColor="White" Height="40px" Width="140px" />
            <ItemStyle Font-Bold="True" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    

            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sqlSourcePerfil" runat="server" 
        ConnectionString="<%$ ConnectionStrings:azulli %>" 
        DeleteCommand="DELETE FROM [PROPRIETARIO] WHERE [PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO AND [PROPRIETARIO_AP] = @PROPRIETARIO_AP" 
        InsertCommand="INSERT INTO [PROPRIETARIO] ([NOME_PROPRIETARIO1], [PROPRIETARIO_BLOCO], [PROPRIETARIO_AP], [email], [DataCadastro]) VALUES (@NOME_PROPRIETARIO1, @PROPRIETARIO_BLOCO, @PROPRIETARIO_AP, @email, @DataCadastro)" 
        SelectCommand="SELECT [NOME_PROPRIETARIO1], [PROPRIETARIO_BLOCO], [PROPRIETARIO_AP], [email], [DataCadastro] FROM [PROPRIETARIO] WHERE (([PROPRIETARIO_AP] = @PROPRIETARIO_AP) AND ([PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO))" 
        UpdateCommand="UPDATE [PROPRIETARIO] SET [NOME_PROPRIETARIO1] = @NOME_PROPRIETARIO1, [email] = @email, [DataCadastro] = @DataCadastro WHERE [PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO AND [PROPRIETARIO_AP] = @PROPRIETARIO_AP">
        <DeleteParameters>
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="NOME_PROPRIETARIO1" Type="String" />
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="DataCadastro" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="PROPRIETARIO_AP" SessionField="Ap" 
                Type="Int32" />
            <asp:SessionParameter DefaultValue="0" Name="PROPRIETARIO_BLOCO" 
                SessionField="Bloco" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="NOME_PROPRIETARIO1" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="DataCadastro" Type="DateTime" />
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    </fieldset>


</asp:Content>
