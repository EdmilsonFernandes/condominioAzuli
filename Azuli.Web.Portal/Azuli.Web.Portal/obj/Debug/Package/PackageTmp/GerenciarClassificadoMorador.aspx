<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciarClassificadoMorador.aspx.cs" Inherits="Azuli.Web.Portal.GerenciarClassificadoMorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">

        function MascaraMoeda(objTextBox, SeparadorMilesimo, SeparadorDecimal, e) {

            var sep = 0;

            var key = '';

            var i = j = 0;

            var len = len2 = 0;

            var strCheck = '0123456789';

            var aux = aux2 = '';

            var whichCode = (window.Event) ? e.which : e.keyCode;

            if (whichCode == 13) return true;

            key = String.fromCharCode(whichCode)

            if (strCheck.indexOf(key) == -1) return false; // Chave invlida

            len = objTextBox.value.length;

            for (i = 0; i < len; i++)

                if ((objTextBox.value.charAt(i) != '0') && (objTextBox.value.charAt(i) != SeparadorDecimal)) break;

            aux =

'';

            for (; i < len; i++)

                if (strCheck.indexOf(objTextBox.value.charAt(i)) != -1) aux += objTextBox.value.charAt(i);

            aux += key;

            len = aux.length;

            if (len == 0) objTextBox.value = '';

            if (len == 1) objTextBox.value = '0' + SeparadorDecimal + '0' + aux;

            if (len == 2) objTextBox.value = '0' + SeparadorDecimal + aux;

            if (len > 2) {

                aux2 =

'';

                for (j = 0, i = len - 3; i >= 0; i--) {

                    if (j == 3) {

                        aux2 += SeparadorMilesimo;

                        j = 0;

                    }

                    aux2 += aux.charAt(i);

                    j++;

                }

                objTextBox.value =

'';

                len2 = aux2.length;

                for (i = len2 - 1; i >= 0; i--)

                    objTextBox.value += aux2.charAt(i);

                objTextBox.value += SeparadorDecimal + aux.substr(len - 2, len);

            }

            return false;

        }
        </script>
    <style type="text/css">
        .style2
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
    <br />
    <br />
  
     <fieldset class="loginDisplayLegend" >
   <legend class="style2">Alterar Anúncio:</legend><br />
   <center>
       <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        CssClass="GridView" Height="50px" Width="675px" 
           onitemcommand="DetailsView1_ItemCommand" DataKeyNames="idClassificado" 
           onitemupdating="DetailsView1_ItemUpdating" EmptyDataText="Este classificado já não existe mais..">
        <Fields>

            <asp:TemplateField HeaderText="Grupo Classificado" Visible ="false">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("grpClassificado.grupoClassificado") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("grpClassificado.grupoClassificado") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("grpClassificado.grupoClassificado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id Classificado" Visible ="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("idClassificado") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("idClassificado") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("idClassificado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Título">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" width="495px" runat="server" 
                        Text='<%# Bind("assuntoClassificado") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" 
                        Text='<%# Bind("assuntoClassificado") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("assuntoClassificado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descrição">
                <EditItemTemplate>
               
                    <asp:TextBox TextMode="MultiLine" ID="TextBox2" Height="90px" Width="495px" runat="server" 
                        Text='<%# Bind("descricaoClassificado") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        Text='<%# Bind("descricaoClassificado") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" 
                        Text='<%# Bind("descricaoClassificado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefone">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        Text='<%# Bind("classificadoTelefone1") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        Text='<%# Bind("classificadoTelefone1") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" 
                        Text='<%# Bind("classificadoTelefone1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Celular">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" 
                        Text='<%# Bind("classificadoTelefone2") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" 
                        Text='<%# Bind("classificadoTelefone2") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" 
                        Text='<%# Bind("classificadoTelefone2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="E-mail">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        Text='<%# Bind("emailClassificadoContato") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        Text='<%# Bind("emailClassificadoContato") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" 
                        Text='<%# Bind("emailClassificadoContato") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor">
                <EditItemTemplate>
                  <asp:Label id="lblReais" runat="server" Text="R$ "></asp:Label>  <asp:TextBox ID="TextBox6" Width="90px" onKeyPress="return(MascaraMoeda(this,'.',',',event))" runat="server" 
                        Text='<%# Bind("valorVendaClassificado") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox6" Width="30px" onKeyPress="return(MascaraMoeda(this,'.',',',event))" runat="server" 
                        Text='<%# Bind("valorVendaClassificado") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" onKeyPress="return(MascaraMoeda(this,'.',',',event))"  Text='<%# Bind("valorVendaClassificado") %>'></asp:Label>
                       
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status Classificado" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" Width="10px" runat="server" 
                        Text='<%# Bind("statusClassificado") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" 
                        Text='<%# Bind("statusClassificado") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("statusClassificado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IMG1" Visible ="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" 
                        Text='<%# Bind("classificadoimg1") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" 
                        Text='<%# Bind("classificadoimg1") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("classificadoimg1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IMG2" Visible ="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" 
                        Text='<%# Bind("classificadoimg2") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" 
                        Text='<%# Bind("classificadoimg2") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("classificadoimg2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IMG3" Visible ="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox12" runat="server" 
                        Text='<%# Bind("classificadoimg3") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox12" runat="server" 
                        Text='<%# Bind("classificadoimg3") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("classificadoimg3") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IMG4" Visible ="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox13" runat="server" 
                        Text='<%# Bind("classificadoimg4") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox13" runat="server" 
                        Text='<%# Bind("classificadoimg4") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("classificadoimg4") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Data Venda" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox14" runat="server" 
                        Text='<%# Bind("classificadoDataVenda") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox14" runat="server" 
                        Text='<%# Bind("classificadoDataVenda") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label14" runat="server" 
                        Text='<%# Bind("classificadoDataVenda") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:Button  CssClass="botao" ID="btnAtualizar" runat="server" CausesValidation="True" 
                        CommandName="Update" Text="Salvar Alterações" />
                   

                        <asp:Button CssClass="botao" ID="btnVendido" runat="server" CausesValidation="True" 
                        CommandName="Vendido" Text="Vendido" />
                    

                        <asp:Button CssClass="botao" ID="btnDesativar" runat="server" CausesValidation="True" 
                        CommandName="Desativar" Text="Desativar Classificado" />

                         <asp:Button CssClass="botao" ID="btnVoltar" runat="server" CausesValidation="True" 
                        CommandName="voltar" Text="Voltar" />
                 
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView></center> 
    <br />
      <center>  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" 
              ForeColor="#009933"></asp:Label></center> 
    </fieldset>
    <asp:SqlDataSource ID="SqlDataSourceEditClassificado" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:azulli %>" 
        DeleteCommand="DELETE FROM [Classificados] WHERE [Classificado_id] = @original_Classificado_id AND (([Classificado_Grupo] = @original_Classificado_Grupo) OR ([Classificado_Grupo] IS NULL AND @original_Classificado_Grupo IS NULL)) AND (([Classificado_Data] = @original_Classificado_Data) OR ([Classificado_Data] IS NULL AND @original_Classificado_Data IS NULL)) AND (([Classificado_Bloco] = @original_Classificado_Bloco) OR ([Classificado_Bloco] IS NULL AND @original_Classificado_Bloco IS NULL)) AND (([Classificado_AP] = @original_Classificado_AP) OR ([Classificado_AP] IS NULL AND @original_Classificado_AP IS NULL)) AND (([Classificado_Descricao] = @original_Classificado_Descricao) OR ([Classificado_Descricao] IS NULL AND @original_Classificado_Descricao IS NULL)) AND (([Classificado_Status] = @original_Classificado_Status) OR ([Classificado_Status] IS NULL AND @original_Classificado_Status IS NULL)) AND (([Classificado_Validade] = @original_Classificado_Validade) OR ([Classificado_Validade] IS NULL AND @original_Classificado_Validade IS NULL)) AND (([Classificado_Img1] = @original_Classificado_Img1) OR ([Classificado_Img1] IS NULL AND @original_Classificado_Img1 IS NULL)) AND (([Classificado_Img2] = @original_Classificado_Img2) OR ([Classificado_Img2] IS NULL AND @original_Classificado_Img2 IS NULL)) AND (([Classificado_Img3] = @original_Classificado_Img3) OR ([Classificado_Img3] IS NULL AND @original_Classificado_Img3 IS NULL)) AND (([Classificado_Img4] = @original_Classificado_Img4) OR ([Classificado_Img4] IS NULL AND @original_Classificado_Img4 IS NULL)) AND (([Classificado_email_contato] = @original_Classificado_email_contato) OR ([Classificado_email_contato] IS NULL AND @original_Classificado_email_contato IS NULL)) AND (([Classificado_Tel1] = @original_Classificado_Tel1) OR ([Classificado_Tel1] IS NULL AND @original_Classificado_Tel1 IS NULL)) AND (([Classificado_Tel2] = @original_Classificado_Tel2) OR ([Classificado_Tel2] IS NULL AND @original_Classificado_Tel2 IS NULL)) AND (([Classificado_Data_Venda] = @original_Classificado_Data_Venda) OR ([Classificado_Data_Venda] IS NULL AND @original_Classificado_Data_Venda IS NULL)) AND (([Classificado_Valor] = @original_Classificado_Valor) OR ([Classificado_Valor] IS NULL AND @original_Classificado_Valor IS NULL)) AND (([Classificado_Contato] = @original_Classificado_Contato) OR ([Classificado_Contato] IS NULL AND @original_Classificado_Contato IS NULL)) AND (([Classificado_assunto] = @original_Classificado_assunto) OR ([Classificado_assunto] IS NULL AND @original_Classificado_assunto IS NULL))" 
        InsertCommand="INSERT INTO [Classificados] ([Classificado_Grupo], [Classificado_Data], [Classificado_Bloco], [Classificado_AP], [Classificado_Descricao], [Classificado_Status], [Classificado_Validade], [Classificado_Img1], [Classificado_Img2], [Classificado_Img3], [Classificado_Img4], [Classificado_email_contato], [Classificado_Tel1], [Classificado_Tel2], [Classificado_Data_Venda], [Classificado_Valor], [Classificado_Contato], [Classificado_assunto]) VALUES (@Classificado_Grupo, @Classificado_Data, @Classificado_Bloco, @Classificado_AP, @Classificado_Descricao, @Classificado_Status, @Classificado_Validade, @Classificado_Img1, @Classificado_Img2, @Classificado_Img3, @Classificado_Img4, @Classificado_email_contato, @Classificado_Tel1, @Classificado_Tel2, @Classificado_Data_Venda, @Classificado_Valor, @Classificado_Contato, @Classificado_assunto)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Classificados] WHERE ([Classificado_id] = @Classificado_id)" 
        UpdateCommand="UPDATE [Classificados] SET [Classificado_Grupo] = @Classificado_Grupo, [Classificado_Data] = @Classificado_Data, [Classificado_Bloco] = @Classificado_Bloco, [Classificado_AP] = @Classificado_AP, [Classificado_Descricao] = @Classificado_Descricao, [Classificado_Status] = @Classificado_Status, [Classificado_Validade] = @Classificado_Validade, [Classificado_Img1] = @Classificado_Img1, [Classificado_Img2] = @Classificado_Img2, [Classificado_Img3] = @Classificado_Img3, [Classificado_Img4] = @Classificado_Img4, [Classificado_email_contato] = @Classificado_email_contato, [Classificado_Tel1] = @Classificado_Tel1, [Classificado_Tel2] = @Classificado_Tel2, [Classificado_Data_Venda] = @Classificado_Data_Venda, [Classificado_Valor] = @Classificado_Valor, [Classificado_Contato] = @Classificado_Contato, [Classificado_assunto] = @Classificado_assunto WHERE [Classificado_id] = @original_Classificado_id AND (([Classificado_Grupo] = @original_Classificado_Grupo) OR ([Classificado_Grupo] IS NULL AND @original_Classificado_Grupo IS NULL)) AND (([Classificado_Data] = @original_Classificado_Data) OR ([Classificado_Data] IS NULL AND @original_Classificado_Data IS NULL)) AND (([Classificado_Bloco] = @original_Classificado_Bloco) OR ([Classificado_Bloco] IS NULL AND @original_Classificado_Bloco IS NULL)) AND (([Classificado_AP] = @original_Classificado_AP) OR ([Classificado_AP] IS NULL AND @original_Classificado_AP IS NULL)) AND (([Classificado_Descricao] = @original_Classificado_Descricao) OR ([Classificado_Descricao] IS NULL AND @original_Classificado_Descricao IS NULL)) AND (([Classificado_Status] = @original_Classificado_Status) OR ([Classificado_Status] IS NULL AND @original_Classificado_Status IS NULL)) AND (([Classificado_Validade] = @original_Classificado_Validade) OR ([Classificado_Validade] IS NULL AND @original_Classificado_Validade IS NULL)) AND (([Classificado_Img1] = @original_Classificado_Img1) OR ([Classificado_Img1] IS NULL AND @original_Classificado_Img1 IS NULL)) AND (([Classificado_Img2] = @original_Classificado_Img2) OR ([Classificado_Img2] IS NULL AND @original_Classificado_Img2 IS NULL)) AND (([Classificado_Img3] = @original_Classificado_Img3) OR ([Classificado_Img3] IS NULL AND @original_Classificado_Img3 IS NULL)) AND (([Classificado_Img4] = @original_Classificado_Img4) OR ([Classificado_Img4] IS NULL AND @original_Classificado_Img4 IS NULL)) AND (([Classificado_email_contato] = @original_Classificado_email_contato) OR ([Classificado_email_contato] IS NULL AND @original_Classificado_email_contato IS NULL)) AND (([Classificado_Tel1] = @original_Classificado_Tel1) OR ([Classificado_Tel1] IS NULL AND @original_Classificado_Tel1 IS NULL)) AND (([Classificado_Tel2] = @original_Classificado_Tel2) OR ([Classificado_Tel2] IS NULL AND @original_Classificado_Tel2 IS NULL)) AND (([Classificado_Data_Venda] = @original_Classificado_Data_Venda) OR ([Classificado_Data_Venda] IS NULL AND @original_Classificado_Data_Venda IS NULL)) AND (([Classificado_Valor] = @original_Classificado_Valor) OR ([Classificado_Valor] IS NULL AND @original_Classificado_Valor IS NULL)) AND (([Classificado_Contato] = @original_Classificado_Contato) OR ([Classificado_Contato] IS NULL AND @original_Classificado_Contato IS NULL)) AND (([Classificado_assunto] = @original_Classificado_assunto) OR ([Classificado_assunto] IS NULL AND @original_Classificado_assunto IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_Classificado_id" Type="Decimal" />
            <asp:Parameter Name="original_Classificado_Grupo" Type="Int32" />
            <asp:Parameter Name="original_Classificado_Data" Type="DateTime" />
            <asp:Parameter Name="original_Classificado_Bloco" Type="Int32" />
            <asp:Parameter Name="original_Classificado_AP" Type="Int32" />
            <asp:Parameter Name="original_Classificado_Descricao" Type="String" />
            <asp:Parameter Name="original_Classificado_Status" Type="String" />
            <asp:Parameter Name="original_Classificado_Validade" Type="DateTime" />
            <asp:Parameter Name="original_Classificado_Img1" Type="String" />
            <asp:Parameter Name="original_Classificado_Img2" Type="String" />
            <asp:Parameter Name="original_Classificado_Img3" Type="String" />
            <asp:Parameter Name="original_Classificado_Img4" Type="String" />
            <asp:Parameter Name="original_Classificado_email_contato" Type="String" />
            <asp:Parameter Name="original_Classificado_Tel1" Type="String" />
            <asp:Parameter Name="original_Classificado_Tel2" Type="String" />
            <asp:Parameter Name="original_Classificado_Data_Venda" Type="DateTime" />
            <asp:Parameter Name="original_Classificado_Valor" Type="Decimal" />
            <asp:Parameter Name="original_Classificado_Contato" Type="String" />
            <asp:Parameter Name="original_Classificado_assunto" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Classificado_Grupo" Type="Int32" />
            <asp:Parameter Name="Classificado_Data" Type="DateTime" />
            <asp:Parameter Name="Classificado_Bloco" Type="Int32" />
            <asp:Parameter Name="Classificado_AP" Type="Int32" />
            <asp:Parameter Name="Classificado_Descricao" Type="String" />
            <asp:Parameter Name="Classificado_Status" Type="String" />
            <asp:Parameter Name="Classificado_Validade" Type="DateTime" />
            <asp:Parameter Name="Classificado_Img1" Type="String" />
            <asp:Parameter Name="Classificado_Img2" Type="String" />
            <asp:Parameter Name="Classificado_Img3" Type="String" />
            <asp:Parameter Name="Classificado_Img4" Type="String" />
            <asp:Parameter Name="Classificado_email_contato" Type="String" />
            <asp:Parameter Name="Classificado_Tel1" Type="String" />
            <asp:Parameter Name="Classificado_Tel2" Type="String" />
            <asp:Parameter Name="Classificado_Data_Venda" Type="DateTime" />
            <asp:Parameter Name="Classificado_Valor" Type="Decimal" />
            <asp:Parameter Name="Classificado_Contato" Type="String" />
            <asp:Parameter Name="Classificado_assunto" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="Classificado_id" 
                QueryStringField="codigo" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Classificado_Grupo" Type="Int32" />
            <asp:Parameter Name="Classificado_Data" Type="DateTime" />
            <asp:Parameter Name="Classificado_Bloco" Type="Int32" />
            <asp:Parameter Name="Classificado_AP" Type="Int32" />
            <asp:Parameter Name="Classificado_Descricao" Type="String" />
            <asp:Parameter Name="Classificado_Status" Type="String" />
            <asp:Parameter Name="Classificado_Validade" Type="DateTime" />
            <asp:Parameter Name="Classificado_Img1" Type="String" />
            <asp:Parameter Name="Classificado_Img2" Type="String" />
            <asp:Parameter Name="Classificado_Img3" Type="String" />
            <asp:Parameter Name="Classificado_Img4" Type="String" />
            <asp:Parameter Name="Classificado_email_contato" Type="String" />
            <asp:Parameter Name="Classificado_Tel1" Type="String" />
            <asp:Parameter Name="Classificado_Tel2" Type="String" />
            <asp:Parameter Name="Classificado_Data_Venda" Type="DateTime" />
            <asp:Parameter Name="Classificado_Valor" Type="Decimal" />
            <asp:Parameter Name="Classificado_Contato" Type="String" />
            <asp:Parameter Name="Classificado_assunto" Type="String" />
            <asp:Parameter Name="original_Classificado_id" Type="Decimal" />
            <asp:Parameter Name="original_Classificado_Grupo" Type="Int32" />
            <asp:Parameter Name="original_Classificado_Data" Type="DateTime" />
            <asp:Parameter Name="original_Classificado_Bloco" Type="Int32" />
            <asp:Parameter Name="original_Classificado_AP" Type="Int32" />
            <asp:Parameter Name="original_Classificado_Descricao" Type="String" />
            <asp:Parameter Name="original_Classificado_Status" Type="String" />
            <asp:Parameter Name="original_Classificado_Validade" Type="DateTime" />
            <asp:Parameter Name="original_Classificado_Img1" Type="String" />
            <asp:Parameter Name="original_Classificado_Img2" Type="String" />
            <asp:Parameter Name="original_Classificado_Img3" Type="String" />
            <asp:Parameter Name="original_Classificado_Img4" Type="String" />
            <asp:Parameter Name="original_Classificado_email_contato" Type="String" />
            <asp:Parameter Name="original_Classificado_Tel1" Type="String" />
            <asp:Parameter Name="original_Classificado_Tel2" Type="String" />
            <asp:Parameter Name="original_Classificado_Data_Venda" Type="DateTime" />
            <asp:Parameter Name="original_Classificado_Valor" Type="Decimal" />
            <asp:Parameter Name="original_Classificado_Contato" Type="String" />
            <asp:Parameter Name="original_Classificado_assunto" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
