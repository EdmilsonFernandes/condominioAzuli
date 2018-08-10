<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="meuClassificados.aspx.cs" Inherits="Azuli.Web.Portal.meuClassificados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            background-color: #BFCBD6;
            border-left: 1px dotted #999999;
            border-right: 1px dotted #999999;
            border-bottom: 1px dotted #999999;
            padding: 3px 3px 3px 3px;
            font-family: Verdana;
            font-size: small;
            color: #0000FF;
            border-radius: 1em;
            width: 520px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br /><br /><br />

<fieldset class="loginDisplayLegend">
         <legend class="accordionContent" align="left"><strong>Gerenciar seus Classificados: </strong></legend>
<div  id="dvAnunciar"  runat="server" align="center" dir="ltr">
       
   <center>  
            <br />
        <center>  
            <asp:GridView ID="grdClassificado" runat="server" AutoGenerateColumns="False" 
                CssClass="gridl" Width="756px" 
                EmptyDataText="Você não tem anúncios Publicados!!">
                <Columns>
                    <asp:TemplateField HeaderText="Código" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" 
                                Text='<%# Bind("idClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("idClassificado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField DataImageUrlField="classificadoimg1" HeaderText="Foto" 
                        DataImageUrlFormatString="~/ServerFile/Classificados/{0}">
                        <ControlStyle Width="40px" />
                    </asp:ImageField>
                    <asp:TemplateField HeaderText="Descrição">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" 
                                Text='<%# Bind("assuntoClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" 
                                Text='<%# Bind("assuntoClassificado") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="True" Font-Size="X-Small" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor R$">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" 
                                Text='<%# Bind("valorVendaClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" 
                                Text='<%# Bind("valorVendaClassificado","{0:N2}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data do anúncio">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" 
                                Text='<%# Eval("dataClassificado", "{0:dddd}") + " / " + Eval("dataClassificado","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server"  Text='<%# Eval("dataClassificado", "{0:dddd}") + " - " + Eval("dataClassificado","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="idClassificado" 
                        DataNavigateUrlFormatString="~/GerenciarClassificadoMorador.aspx?codigo={0}" 
                        Text="Ver ...">
                    <HeaderStyle Font-Bold="False" />
                    <ItemStyle ForeColor="#0033CC" />
                    </asp:HyperLinkField>
                </Columns>
            </asp:GridView> </center> 
       
  </center>   </div> </fieldset>
</asp:Content>
