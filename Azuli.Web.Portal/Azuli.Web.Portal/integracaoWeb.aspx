<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="integracaoWeb.aspx.cs" Inherits="Azuli.Web.Portal.integracaoWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            width: 331px;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
<legend class="accordionContent">Integração WEB - Recibo - Control Water</legend>

 <center><p>
        <asp:Label ID="lblPasso" runat="server" 
            style="font-weight: 700; font-size: large; color: #006600" 
            Text="1º passo - Importação de dados"></asp:Label>
        <br />
        <table class="accordionContent">
            <tr>
                <td class="style4">
        <asp:FileUpload ID="fupProject" runat="server" CssClass="btGeral" Width="357px" />
                </td>
                <td>
        <asp:Button ID="btnCheck" runat="server" 
            onclick="btnCheck_Click" CssClass="btGeral" Text="Verificar Arquivo" />
                </td>
            </tr>
        </table></center>
        <br />
    <p align="center">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMsgError" runat="server" 
            CssClass="failureNotification"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
    </p>
        <div style="height:285px; width:1012px; overflow:auto" id="divtabela" 
            align="center" class="accordionContent" runat="server">
      
    &nbsp;<asp:GridView ID="grdImport" runat="server" Font-Size="Smaller" 
            CssClass="gridviewImport" GridLines="Vertical" ShowHeader="False">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            
        </asp:GridView> 
   </div>
   <br />
        <p align="left">
            <asp:Label 
            ID="lblDescTotalRead" runat="server" Text="Total de Recibos Lidos =" 
                CssClass="accordionContent" ></asp:Label> <b>&nbsp;</b> <asp:Label ID="lblTotalRead" runat="server" Text="0"   style="font-weight: 700; font-size: medium" CssClass="accordionContent"></asp:Label>
            
           
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSaved" runat="server" meta:resourcekey="lblSaved" 
            Visible="False" Font-Bold="True" ForeColor="#006600" 
            style="font-size: large" CssClass="accordionContent"></asp:Label>
            
           
        </p>
        <p align="center">
        <asp:Button ID="cmdSave" runat="server" Text="Fazer Integração" 
            onclick="cmdSave_Click" Enabled="False" CssClass="btGeral" Width="167px" 
                Height="33px"/> 
        </p>
    <p align="center">
        &nbsp;</p>

    <div class="loading" align="center" runat="server">
    <asp:Label Text="Importando os dados. Por favor espere..." ID="lblImport" runat="server"></asp:Label><asp:Label Text="" ID="lblCountImport" runat="server"></asp:Label>
    <br />
    <br />
    <img src="images/loader.gif" alt="" />
   </div>

   <div id="dvUploadArquivos" runat="server">
      <fieldset>
<legend class="accordionContent">Integração WEB - Recibo - Control Water</legend>
   <br /> <center>
              <br />
              <asp:Label ID="lblPasso0" runat="server" 
                  style="font-weight: 700; font-size: large; color: #006600" 
                  Text="2º passo - Upload das imagens dos Hidrômetro"></asp:Label>
              <br />
              <br />
        <table class="accordionContent">
            <tr>
                <td class="style4">
        <asp:FileUpload ID="fileUploadImagem" runat="server" CssClass="btGeral" Width="357px" />
                </td>
                <td>
        <asp:Button ID="btnUploadImg" runat="server" 
             CssClass="btGeral" Text="Upload de imagem" onclick="btnUploadImg_Click" />
                    <br />
                </td>
            </tr>
        </table>
              <br />
              <br />
        <asp:Label ID="lblSavedImagen" runat="server" meta:resourcekey="lblSaved" 
            Visible="False" Font-Bold="True" ForeColor="#006600" 
            style="font-size: large" CssClass="accordionContent"></asp:Label>
            
           
              <br />
              <br />
              <asp:LinkButton ID="lnkRecibo" runat="server" onclick="lnkRecibo_Click" 
                  style="font-size: medium">Consultar Recibo</asp:LinkButton>
              <br />
              <br />
              <asp:Label ID="lblRegistros" runat="server" 
                  style="font-weight: 700; font-size: medium"></asp:Label>
              <br />
        <br />
        <asp:GridView ID="grZip" runat="server" CssClass="gridl" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="FileName" HeaderText="Nome do Arquivo" />
                <asp:BoundField DataField="CreationTime" HeaderText="Data de Criação" />
            </Columns>
       </asp:GridView></center>
        </fieldset>
   
       
   
   </div>
        </fieldset>

    <br />

</asp:Content>
