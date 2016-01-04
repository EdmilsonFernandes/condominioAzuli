<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consultaCircular.aspx.cs" Inherits="Azuli.Web.Portal.consultaCircular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <fieldset  class="loginDisplayLegend">
  
        <legend class="accordionContent">Consulta de Publicações de Circulares: </legend>
        <br />
        <asp:Label ID="lblConsultaAno" runat="server" CssClass="failureNotification"
            Text="Ano de Consulta:"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="drpAno" runat="server" CssClass="container" Height="26px" 
            Width="123px" AutoPostBack="True" 
            onselectedindexchanged="drpAno_SelectedIndexChanged" Font-Bold="True">
        </asp:DropDownList>
        <br />
        <br />
        
         <center>   <asp:Label ID="lblMsg" runat="server" CssClass="MasterMenu" 
                 Font-Bold="True" Font-Size="Small"></asp:Label></center>
        
        <br />

        <div id="dvPublicacao" runat="server">
      <table width="100%" cellpadding="5" 
            style="background-color: White; border: Outset 2px Silver; text-align: center;" 
            class="dysplayLogin">
        
       
        <tr>
          <td>
                <b><asp:Label ID="lblMeses" runat="server" Text="Clique no Mês desejado: " CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth1" runat="server" CssClass="Text" onclick="lbtMonth_Click">1</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth2" runat="server" CssClass="Text" 
                    onclick="lbtMonth2_Click">2</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth3" runat="server" CssClass="Text" 
                    onclick="lbtMonth3_Click">3</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth4" runat="server" CssClass="Text" 
                    onclick="lbtMonth4_Click">4</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth5" runat="server" CssClass="Text" 
                    onclick="lbtMonth5_Click">5</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth6" runat="server" CssClass="Text" 
                    onclick="lbtMonth6_Click">6</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth7" runat="server" CssClass="Text" 
                    onclick="lbtMonth7_Click">7</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth8" runat="server" CssClass="Text" onclick="lbtMonth_Click8">8</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth9" runat="server" CssClass="Text" onclick="lbtMonth_Click9">9</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth10" runat="server" CssClass="Text" onclick="lbtMonth_Click10">10</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth11" runat="server" CssClass="Text" onclick="lbtMonth_Click11">11</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth12" runat="server" CssClass="Text" onclick="lbtMonth_Click12">12</asp:LinkButton>
            </td>
        </tr>

          <tr>
           <td>
                <b><asp:Label ID="lblQuantidadesArquivos" runat="server" Text="Qtd de Arquivos Publicados no mês: " CssClass="Text"></asp:Label></b>
            </td>

            <td>
                <b><asp:Label ID="lblPercentage1" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage2" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage3" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage4" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage5" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage6" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage7" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage8" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage9" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage10" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage11" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <b><asp:Label ID="lblPercentage12" runat="server" Text="0" CssClass="Text"></asp:Label></b>
            </td>
        </tr>
        </table>
        </div>
        
        </fieldset>
        <center>
        <div id="dvArquivosPublicados" runat="server">
        
            <fieldset  class="login">
        <legend class="accordionContent">Arquivos publicado em: <asp:Label id="lblmesAno" runat="server"></asp:Label> </legend>
        <br />
            <asp:GridView ID="grdCircular" runat="server" AutoGenerateColumns="False" 
                Height="39px" Width="907px" DataKeyNames="nameFile" 
                onrowcommand="grdCircular_RowCommand" CssClass="gridl" 
                    EmptyDataText="Não foram encontrados arquivos publicados!!">
                <Columns>
                    <asp:BoundField DataField="assunto" HeaderText="Assunto" />
                    <asp:BoundField DataField="mes" HeaderText="Mês" />
                    <asp:BoundField DataField="ano" HeaderText="Ano" />
                    <asp:BoundField DataField="nomeAreaPublicacao" 
                        HeaderText="Tipo de Publicação" />
                    <asp:TemplateField HeaderText="Data da Publicação">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataPublicacao") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("dataPublicacao", "{0:dddd}") + " - " + Eval("dataPublicacao","{0:dd/MM/yyyy hh:mm:ss}") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" DataTextField="nameFile" 
                        HeaderText="Arquivos" ImageUrl="~/images/pdf.jpg">
                    <ControlStyle Height="25px" Width="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
       
     </fieldset>   </div></center><br /><center>
    <asp:Button ID="btnOk" runat="server" Text="Ok" Width="58px" CssClass="btGeral" 
            onclick="btnOk_Click" /></center>
        
</asp:Content>
