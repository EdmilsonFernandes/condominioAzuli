<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listaMensagemMorador.aspx.cs" Inherits="Azuli.Web.Portal.listaMensagemMorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /> <br /><br /><br /><br />
<fieldset class="login">
        <legend> Mensagens do Sindíco: </legend>
<center>
         <div id="dvFesta" runat="server">
             <br />
            <asp:DataList ID="dtListMensagem" runat="server"
                EnableViewState="False" Style="margin-right: 1px" Width="508px" 
                CssClass="SelectedRowStyle" >
                <HeaderTemplate>
                  <asp:Label ID="lblSemregistro" runat="server" Text="Mensagens Abertas" Visible='<%#(dtListMensagem.Items.Count > 0) %>'></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    Código Mensagem:
                    
                    <asp:Label ID="lblCodigo" runat="server" 
                        Text= '<%# Eval("codigoMsg") %>' />
                    <br />

                     Assunto:
                    <asp:Label ID="Label1" runat="server" 
                        Text= '<%# Eval("assunto") %>' />
                    <br />
                     Mensagem:
                    <asp:Label ID="lblMgs" runat="server" 
                        Text='<%# Eval("mensagem") %>'/>
                    <br />
                    Data de Envio:
                    <asp:Label ID="DATA_OCORRENCIALabel" runat="server" 
                        Text='<%# Eval("data_inicio") %>'/>
                    <br />
                    Esta Mensagem Expira dia:
                    <asp:Label ID="STATUSLabel" runat="server" 
                        Text='<%# Eval("data_fim") %>'/>
                    <br />
                    
                   
                    <br />
                </ItemTemplate>
                
                
                <SeparatorTemplate>
                    <hr />
                </SeparatorTemplate>
                <FooterTemplate>
                <asp:Label ID="lblSemregistro" runat="server" Text="Você não possui mensagem " Visible='<%#(dtListMensagem.Items.Count == 0) %>'></asp:Label>
                 </FooterTemplate>
            </asp:DataList></div> </center></fieldset>
</asp:Content>
