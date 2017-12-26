<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SegundaViaContaAguaAzuli.aspx.cs" Inherits="Azuli.Web.Portal.SegundaViaContaAguaAzuli" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
    <style type="text/css">
        .style2
        {
            width: 63px;
        }
    </style>
  
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />

    <fieldset  class="style1" dir="ltr">
  
        <legend class="accordionContent">Consulta de 2ª via conta de Água: </legend>
        <br />
        <asp:Label ID="lblConsultaAno" runat="server" CssClass="accordionContent" 
            Text="Mudar Ano de Consulta:"></asp:Label>
        &nbsp;<asp:DropDownList ID="drpAno" runat="server" CssClass="menu" Height="26px" 
            Width="123px" AutoPostBack="True" 
            onselectedindexchanged="drpAno_SelectedIndexChanged" Font-Bold="True" 
           >
        </asp:DropDownList>
        <br />
        <br />
        
         <center>   <asp:Label ID="lblMsg" runat="server" CssClass="failureNotification"></asp:Label></center>
        
        <br />

        <div id="dvPublicacao" runat="server" align="left">
      <table cellpadding="1" 
            style="background-color: White; border: Outset 2px Silver; text-align: center; width: 100%;" 
            class="btGeral" align="left" dir="ltr">
        
       
        <tr>
          <td>
                <b><asp:Label ID="lblMeses" runat="server" Text=" Mês: " CssClass="Text"></asp:Label></b>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth1" runat="server" CssClass="" 
                    onclick="lbtMonth_Click">1</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth2" runat="server" CssClass="" 
                    onclick="lbtMonth2_Click">2</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth3" runat="server" CssClass="" 
                    onclick="lbtMonth3_Click">3</asp:LinkButton>
            </td>
            <td class="style2">
                <asp:LinkButton ID="lbtMonth4" runat="server" CssClass="" 
                    onclick="lbtMonth4_Click" style="font-size: 9pt">4</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth5" runat="server" CssClass="" 
                    onclick="lbtMonth5_Click">5</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth6" runat="server" CssClass="" 
                    onclick="lbtMonth6_Click">6</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth7" runat="server" CssClass="" 
                    onclick="lbtMonth7_Click">7</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth8" runat="server" CssClass="" 
                    onclick="lbtMonth_Click8">8</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth9" runat="server" CssClass="" 
                    onclick="lbtMonth_Click9">9</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth10" runat="server" CssClass="" 
                    onclick="lbtMonth_Click10">10</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth11" runat="server" CssClass="" 
                    onclick="lbtMonth_Click11">11</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lbtMonth12" runat="server" CssClass="" 
                    onclick="lbtMonth_Click12">12</asp:LinkButton>
            </td>
        </tr>

          <tr>
           <td>
                <b><asp:Label ID="lblQuantidadesArquivos" runat="server" Text="Status: " CssClass="Text"></asp:Label></b>
            </td>

            <td>
                <asp:Image ID="img1" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img2" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img3" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td class="style2">
                <asp:Image ID="img4" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img5" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img6" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img7" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img8" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img9" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img10" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img11" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
            <td>
                <asp:Image ID="img12" runat="server" Height="18px" 
                    ImageUrl="~/images/vermelhoStatus.png" Width="23px" />
            </td>
        </tr>
        </table>
        </div>
        
        </fieldset>


  
</asp:Content>
