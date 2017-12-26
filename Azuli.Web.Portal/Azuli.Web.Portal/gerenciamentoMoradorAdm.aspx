<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true"
    CodeBehind="gerenciamentoMoradorAdm.aspx.cs" Inherits="Azuli.Web.Portal.gerenciamentoMoradorAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div id="dvCadastro" align="center" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Cadastrar Moradores</legend>
            <center>
                <br />
                <table class="accordionContent">
                    <tr>
                        <td>
                            <asp:Label ID="lblcond01" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Morador</asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtCond01" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="273px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCond01"
                                ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblBloco" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Bloco:</asp:Label>
                        </td>
                        <td>
                        <asp:DropDownList ID="drpBloco" runat="server" Height="25px" Width="52px" 
                                            style="font-size: medium; font-weight: 700;" 
                                            CssClass="AlternatingRowStyle">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                        </asp:DropDownList>
                            <%--    <asp:TextBox ID="txtBloco" runat="server" Height="19px" Width="87px"></asp:TextBox>--%>
                            <asp:RequiredFieldValidator ID="rfvName0" runat="server" ControlToValidate="drpBloco"
                                ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblAP" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Apartamento:</asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtAP" runat="server" Height="18px" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName1" runat="server" ControlToValidate="txtAP"
                                ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">E-mail</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="200" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"
                                Width="144px">Não tem no momento</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTelefone" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Telefone:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefone" runat="server" MaxLength="200" 
                                AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"
                                Width="144px">Não tem no momento</asp:TextBox>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="lstRadioButton" runat="server" style="font-size: 9pt" 
                                Width="169px">
                                <asp:ListItem Selected="True" Value="Proprietário">Proprietário</asp:ListItem>
                                <asp:ListItem Value="Locatário">Locatário</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:ImageButton ID="ibtAddSave" runat="server" ImageUrl="~/images/add.png" ValidationGroup="InputValidationGroup"
                    OnClick="ibtAddSave_Click" Width="23px" Height="23px" />
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ibtCancel" runat="server" ImageUrl="~/Images/cancel.png" OnClick="ibtCancel_Click"
                    Height="20px" Width="18px" />
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ibtSearch" runat="server" ImageUrl="~/images/search.png" OnClick="ibtSearch_Click"
                    Width="20px" />
                <br />
                <br />
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
        </fieldset>
    </div>
    <div id="dvGridAll" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Gerenciamento de Moradores</legend>
            <br />
    
    <center>
        
            <asp:GridView ID="grdGerenciamentoMoradores" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CssClass="gridl" DataKeyNames="PROPRIETARIO_BLOCO,PROPRIETARIO_AP"
                DataSourceID="SqlDataSourceGerenciamentoUser" Height="86px" Width="852px" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="NOME_PROPRIETARIO1" HeaderText="Condomino 01" SortExpression="NOME_PROPRIETARIO1" />
                    <asp:BoundField DataField="PROPRIETARIO_BLOCO" HeaderText="Bloco" ReadOnly="True"
                        SortExpression="PROPRIETARIO_BLOCO">
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PROPRIETARIO_AP" HeaderText="Apartamento" ReadOnly="True"
                        SortExpression="PROPRIETARIO_AP">
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                    <asp:BoundField HeaderText="Senha" DataField="PASSWORD">
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" />
                    <asp:BoundField DataField="PROPRIETARIO_IMOVEL" HeaderText="Sobre o Imóvel" />
                    <asp:CheckBoxField DataField="STATUS" HeaderText="ATIVO" SortExpression="STATUS" />
                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png"
                        EditImageUrl="~/images/edit.png" ShowEditButton="True" UpdateImageUrl="~/images/save.png" />
                </Columns>
            </asp:GridView>
    </center>  </fieldset></div>
  
    <asp:SqlDataSource ID="SqlDataSourceGerenciamentoUser" runat="server" ConnectionString="<%$ ConnectionStrings:azulli %>"
        DeleteCommand="DELETE FROM [PROPRIETARIO] WHERE [PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO AND [PROPRIETARIO_AP] = @PROPRIETARIO_AP"
        InsertCommand="INSERT INTO [PROPRIETARIO] ([NOME_PROPRIETARIO1], [PROPRIETARIO_BLOCO], [PROPRIETARIO_AP], [email],[STATUS],[TELEFONE],[PROPRIETARIO_IMOVEL]) VALUES (@NOME_PROPRIETARIO1, @PROPRIETARIO_BLOCO, @PROPRIETARIO_AP, @email, @STATUS,[TELEFONE],[PROPRIETARIO_IMOVEL])"
        SelectCommand="SELECT [NOME_PROPRIETARIO1],[PROPRIETARIO_BLOCO], [PROPRIETARIO_AP],[PASSWORD] ,[email],[STATUS],[TELEFONE],[proprietario_imovel] FROM [PROPRIETARIO] WHERE [STATUS] = 1  ORDER BY [DataCadastro] DESC"
        UpdateCommand="UPDATE [PROPRIETARIO] SET [NOME_PROPRIETARIO1] = @NOME_PROPRIETARIO1, [email] = @email, [TELEFONE] = @telefone, [PROPRIETARIO_IMOVEL]=@PROPRIETARIO_IMOVEL, [STATUS] = @STATUS WHERE [PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO AND [PROPRIETARIO_AP] = @PROPRIETARIO_AP">
        <DeleteParameters>
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="NOME_PROPRIETARIO1" Type="String" />
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="STATUS" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="NOME_PROPRIETARIO1" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="STATUS" Type="Boolean" />
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
             <asp:Parameter Name="TELEFONE" Type="String" />
            <asp:Parameter Name="PROPRIETARIO_IMOVEL" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    
    
        <div id="dvPesquisa" runat="server">
            <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Pesquisando por:
                <asp:Label ID="lblPesquisa" runat="server"></asp:Label></legend>
         <center>   <asp:GridView ID="grdPesquisa" CssClass="gridl" EmptyDataText="Não existe dados para sua pesquisa!!" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Morador1">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("proprietario1") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("proprietario1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Morador2">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("proprietario2") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("proprietario2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bloco">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ap.bloco") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ap.bloco") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apartamento">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ap.apartamento") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ap.apartamento") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="E-mail">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Senha">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("senha") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("senha") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnFechar" runat="server" Text="Fechar" CssClass="btGeral" 
                onclick="btnFechar_Click" /> </center></fieldset>
        </div>
   
</asp:Content>
