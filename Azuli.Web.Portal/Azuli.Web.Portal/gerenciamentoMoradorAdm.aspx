<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="gerenciamentoMoradorAdm.aspx.cs" Inherits="Azuli.Web.Portal.gerenciamentoMoradorAdm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /> 
 <div id="dvCadastro" align="center" runat="server" >
 <fieldset class="loginDisplayLegend">  
   <legend class="accordionContent">Cadastrar Moradores</legend>
   <center> 
   <br />


 <table class="accordionContent" >
     
         <tr>
            <td>
                <asp:Label ID="lblcond01" runat="server" CssClass="Field" style="font-weight: bold; font-size: 9pt" 
                   >Morador</asp:Label>
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
                <asp:Label ID="lblBloco" runat="server" CssClass="Field" style="font-weight: bold; font-size: 9pt" 
                   >Bloco:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBloco" runat="server" Height="19px" Width="87px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName0" runat="server" ControlToValidate="txtBloco" 
                   ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
               
            </td>
            <td>
                <asp:Label ID="lblAP" runat="server" CssClass="Field" style="font-weight: bold; font-size: 9pt" 
                   >Apartamento:</asp:Label>
            &nbsp;
                <asp:TextBox ID="txtAP" runat="server" Height="18px" Width="70px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName1" runat="server" ControlToValidate="txtAP" 
                   ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
               
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" CssClass="Field" 
                    meta:resourcekey="lblActivity" style="font-weight: bold; font-size: 9pt">E-mail</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="200" AutoPostBack="True" 
                    ontextchanged="txtEmail_TextChanged" Width="144px">Não tem no momento</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" 
                   ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table><br />
    <asp:ImageButton ID="ibtAddSave" runat="server" ImageUrl="~/images/add.png" 
        ValidationGroup="InputValidationGroup" onclick="ibtAddSave_Click" 
           Width="23px" />
    &nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="ibtCancel" runat="server" ImageUrl="~/Images/cancel.png" 
           onclick="ibtCancel_Click" Height="20px" Width="18px"  />
    &nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="ibtSearch" runat="server" ImageUrl="~/images/search.png" 
           onclick="ibtSearch_Click" Width="20px"  />
       <br />
       <br />
       <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
       </fieldset>  </div>
       <div id="dvManager" align="center" runat="server">
       <fieldset class="loginDisplayLegend">
   <legend class="accordionContent">Gerenciamento de Moradores</legend>
   <br /><center>
  
       <asp:GridView ID="grdGerenciamentoMoradores" runat="server" AllowPaging="True" 
           AllowSorting="True" AutoGenerateColumns="False" CssClass="gridl" 
           DataKeyNames="PROPRIETARIO_BLOCO,PROPRIETARIO_AP" 
           DataSourceID="SqlDataSourceGerenciamentoUser" Height="86px" Width="852px">
           <Columns>
               <asp:BoundField DataField="NOME_PROPRIETARIO1" HeaderText="Condomino 01" 
                   SortExpression="NOME_PROPRIETARIO1" />
               <asp:BoundField DataField="NOME_PROPRIETARIO2" HeaderText="Condomino 02" 
                   SortExpression="NOME_PROPRIETARIO2" />
               <asp:BoundField DataField="PROPRIETARIO_BLOCO" HeaderText="Bloco" 
                   ReadOnly="True" SortExpression="PROPRIETARIO_BLOCO" >
               <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" 
                   ForeColor="White" />
               </asp:BoundField>
               <asp:BoundField DataField="PROPRIETARIO_AP" HeaderText="Apartamento" 
                   ReadOnly="True" SortExpression="PROPRIETARIO_AP" >
               <ItemStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
               </asp:BoundField>
               <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
               <asp:BoundField HeaderText="Senha" DataField="PASSWORD" >
               <ItemStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
               </asp:BoundField>
               <asp:CheckBoxField DataField="STATUS" HeaderText="ATIVO" 
                   SortExpression="STATUS" />
               <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" 
                   DeleteImageUrl="~/images/delete.png" EditImageUrl="~/images/edit.png" ShowEditButton="True" 
                   UpdateImageUrl="~/images/save.png" />
           </Columns>
       </asp:GridView></center></fieldset></div> 
       <asp:SqlDataSource ID="SqlDataSourceGerenciamentoUser" runat="server" 
           ConnectionString="<%$ ConnectionStrings:azulli %>" 
           DeleteCommand="DELETE FROM [PROPRIETARIO] WHERE [PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO AND [PROPRIETARIO_AP] = @PROPRIETARIO_AP" 
           InsertCommand="INSERT INTO [PROPRIETARIO] ([NOME_PROPRIETARIO1], [NOME_PROPRIETARIO2], [PROPRIETARIO_BLOCO], [PROPRIETARIO_AP], [email], [STATUS]) VALUES (@NOME_PROPRIETARIO1, @NOME_PROPRIETARIO2, @PROPRIETARIO_BLOCO, @PROPRIETARIO_AP, @email, @STATUS)" 
           SelectCommand="SELECT [NOME_PROPRIETARIO1], [NOME_PROPRIETARIO2], [PROPRIETARIO_BLOCO], [PROPRIETARIO_AP],[PASSWORD] ,[email], [STATUS] FROM [PROPRIETARIO] WHERE [STATUS] = 1  ORDER BY [DataCadastro] DESC" 
           
           
         UpdateCommand="UPDATE [PROPRIETARIO] SET [NOME_PROPRIETARIO1] = @NOME_PROPRIETARIO1, [NOME_PROPRIETARIO2] = @NOME_PROPRIETARIO2, [email] = @email, [STATUS] = @STATUS WHERE [PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO AND [PROPRIETARIO_AP] = @PROPRIETARIO_AP">
           <DeleteParameters>
               <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
               <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
           </DeleteParameters>
           <InsertParameters>
               <asp:Parameter Name="NOME_PROPRIETARIO1" Type="String" />
               <asp:Parameter Name="NOME_PROPRIETARIO2" Type="String" />
               <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
               <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
               <asp:Parameter Name="email" Type="String" />
               <asp:Parameter Name="STATUS" Type="Boolean" />
           </InsertParameters>
           <UpdateParameters>
               <asp:Parameter Name="NOME_PROPRIETARIO1" Type="String" />
               <asp:Parameter Name="NOME_PROPRIETARIO2" Type="String" />
               <asp:Parameter Name="email" Type="String" />
               <asp:Parameter Name="STATUS" Type="Boolean" />
               <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
               <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
           </UpdateParameters>
       </asp:SqlDataSource>
    
 
</asp:Content>
