<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PendenciaReservaMorador.aspx.cs" Inherits="Azuli.Web.Portal.PendenciaReservaMorador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .gridl
        {
        }
        .style3
        {
            font-size: 11pt;
        }
        .style5
        {
            font-size: small;
            font-weight: bold;
        }
        .style6
        {
            font-size: medium;
            font-weight: bold;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function lgFesta_onclick() {

        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <center><div id="dvPesquisaMorador" align="center" runat="server">
      
       
              <center> <div id="dvAgendamentosFuturos" runat="server">

                    <fieldset>
                        <legend id="lgFesta" class="accordionContent" runat="server" onclick="return lgFesta_onclick()">
                            <span class="style3">Áreas Reservadas Bloco e Apartamento :</span> <asp:Label ID="lblBlocoApto" runat="server" Font-Size="12pt" style="color: #0000FF"></asp:Label>
                           
                        </legend>
                        
             
                        <br />
                        <table class="accordionContent" 
                            style="border-style: groove; border-width: thin">
                            <tr>
                                <td colspan="1" rowspan="1" 
                                    style="border-color: #3BA4CB; border-bottom-style: groove; border-width: thin">
                                    <span class="style3"> 
                            <asp:Image ID="Image4" runat="server" Height="16px" 
                                ImageUrl="~/images/festa.jpg" Width="21px" />
                       
                                &nbsp;</span><span class="style6">Salão de Festa</span>&nbsp; 
                                                   
                                </td>
                                <td style="border-color: #3BA4CB; border-bottom-style: groove; border-width: thin" 
                                    align="center">
                                    <br />
                       
                        <asp:GridView ID="grdReservaProgramadaFesta" runat="server" CssClass="gridl" AutoGenerateColumns="False"
                            EmptyDataText="Não existe
            reservas  para o Salão de festa" Font-Bold="False" Font-Size="Small" Width="502px">
                            <Columns>
                                <asp:TemplateField HeaderText="Data da Reserva">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataAgendamento") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#
            Eval("dataAgendamento", "{0:ddd}") + "-" + Eval("dataAgendamento","{0:dd/MM/yy}")
            %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Left" ForeColor="#006600" Font-Size="12pt" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Data
            solicitação da Reserva">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataInclusao") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("dataInclusao", "{0:ddd}")
            + "-" + Eval("dataInclusao","{0:dd/MM/yy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="12pt" ForeColor="Red" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Obs.:">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("observacao") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("observacao") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Font-Size="9pt" ForeColor="#CC3300" />
                                </asp:TemplateField>
                              
                              
                            </Columns>
                        </asp:GridView>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                 
                            <span class="style33"><span class="style3">
                            <asp:Image ID="Image5" runat="server" Height="17px" 
                                ImageUrl="~/images/churrasco.jpg" Width="26px" />
                            &nbsp;</span><span class="style6">Churrasqueira</span>
                            </span>
                                </td>
                                <td align="center">
                                 
                                     <br
                            style="color: #0000FF" class="style5" />
                    
                        <asp:GridView ID="grdReservaProgramadaChurras" runat="server" CssClass="gridl" AutoGenerateColumns="False"
                            EmptyDataText="Não existe
            reservas para churrasqueira" Font-Bold="True" Font-Size="Small">
                            <Columns>
                                <asp:TemplateField HeaderText="Data da Reserva">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataAgendamento") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#
            Eval("dataAgendamento", "{0:ddd}") + "-" + Eval("dataAgendamento","{0:dd/MM/yy}")
            %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" ForeColor="#006600" Width="120px" 
                                        Font-Size="12pt" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Data solicitação da Reserva">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataInclusao")
            %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("dataInclusao", "{0:ddd}") + " / " + Eval("dataInclusao","{0:dd/MM/yy}")
            %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" ForeColor="#FF3300" Width="200px" 
                                        Font-Size="12pt" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Obs.:">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("observacao") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("observacao") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" ForeColor="#CC3300" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                                     <br />
                                </td>
                            </tr>
                        </table>
                        
                     <br /><br />
                        
              <center>  <table class="style21">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="ImageButton1"  runat="server" Height="49px" ImageUrl="~/images/calendario.png"
                                Width="61px" oncommand="ImageButton1_Command" />
                        </td>
                        <td>
                            <asp:HyperLink ID="hplSucess" runat="server" Style="font-weight: 700; font-size: 9pt;
                                color: green;" CssClass="accordionContent" Font-Bold="False" NavigateUrl="~/telaAgendamento.aspx">Voltar para Reservas</asp:HyperLink>
                        </td>
                    </tr>
                </table></center>
         </div> </fieldset> </center>   </div>
  
    </center>
</asp:Content>
