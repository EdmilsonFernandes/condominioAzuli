<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="agendamentosPendentesAdm.aspx.cs" Inherits="Azuli.Web.Portal.agendamentosPendentesAdm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            height: 28px;
            width: 188px;
        }
        .style1
        {
            width: 664px;
        }
        .style5
        {
            height: 28px;
            width: 260px;
        }
        .gridl
        {
            margin-right: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


      <fieldset class="loginDisplayLegend">
     <legend align="left" class="accordionContent">Agendamentos Pendentes
          </legend>
           <div id="dvReservaMes" runat="server" align="left">
      
        <table class="style1">
            <tr>
                <td class="style4">
                    <asp:Label ID="lblMes" runat="server" Font-Bold="True" Text="Mês:"></asp:Label>
                    &nbsp; <asp:DropDownList ID="drpMeses" runat="server" CssClass="btGeral" Font-Bold="True"
                        Height="16px" Width="101px" AutoPostBack="True" 
                        onselectedindexchanged="drpMeses_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    <asp:Label ID="lblAno" runat="server" Font-Bold="True" Text="Ano:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="drpAno" runat="server" CssClass="btGeral" Font-Bold="True"
                        Height="16px" Width="101px" AutoPostBack="True" 
                        onselectedindexchanged="drpAno_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="lbSalao" runat="server" Font-Bold="True" Text="Área :"></asp:Label>
                    &nbsp;<asp:DropDownList ID="drpSalao" runat="server" CssClass="btGeral" Font-Bold="True"
                        Height="19px" Width="127px" AutoPostBack="True" OnSelectedIndexChanged="drpSalao_SelectedIndexChanged">
                        <asp:ListItem Value="1">todas</asp:ListItem>
                        <asp:ListItem>Festa</asp:ListItem>
                        <asp:ListItem>Churrasqueira</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table></div>
          </fieldset>

            
    <div id="dvFesta" runat="server">

     <fieldset class="login">
        <legend class="accordionContent">São de Festas -  <asp:Label ID="lblMesAnoFesta" runat="server" CssClass="FooterStyle"></asp:Label></legend> 
           <center><br />
     
          
&nbsp;<br />
               <asp:GridView ID="grdReservaProgramadaFesta" runat="server" 
                   AutoGenerateColumns="False" CssClass="gridl" 
                   EmptyDataText="Não existe reservas futuras para o Salão de festa" 
                   Font-Bold="False" Font-Size="Small">
                   <Columns>
                   <asp:TemplateField HeaderText="Bloco">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ap.bloco") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#3BA4CB" Font-Bold="True" ForeColor="White" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apartamento">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ap.apartamento") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#3BA4CB" Font-Bold="True" ForeColor="White" />
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="Data da Reserva">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("dataAgendamento") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label4" runat="server" 
                                   Text='<%# Eval("dataAgendamento", "{0:ddd}") + "-" + Eval("dataAgendamento","{0:dd/MM/yy}") %>'></asp:Label>
                           </ItemTemplate>
                           <HeaderStyle Width="120px" />
                           <ItemStyle ForeColor="#006600" HorizontalAlign="Left" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Data solicitação da Reserva">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("dataInclusao") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label5" runat="server" 
                                   Text='<%# Eval("dataInclusao", "{0:ddd}") + "-" + Eval("dataInclusao","{0:dd/MM/yy}") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Font-Size="Small" ForeColor="Red" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Dias em Atraso">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox7" runat="server" 
                                   Text='<%# Eval("qtdDiasPagamentoFesta") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label7" runat="server" 
                                   
                                   Text='<%# ((int)Eval("qtdDiasPagamentoFesta") <= 0) ? "Pago no mesmo dia!" : Eval("qtdDiasPagamentoFesta")  %> '></asp:Label>
                           </ItemTemplate>
                           <ItemStyle HorizontalAlign="Left" />
                       </asp:TemplateField>
                       <asp:ButtonField ButtonType="Button" Text="Confirmar ">
                       <ControlStyle BackColor="#007832" Font-Bold="True" ForeColor="White" />
                       </asp:ButtonField>
                       <asp:ButtonField ButtonType="Button" Text="Cancelar">
                       <ControlStyle BackColor="#D60501" Font-Bold="True" ForeColor="White" />
                       </asp:ButtonField>
                   </Columns>
               </asp:GridView>
               <br />
            <br />
               <asp:ImageButton ID="imgBtExcelFesta" runat="server" 
                   ImageUrl="~/images/excel.png" onclick="imgBtExcelFesta_Click" Width="21px" />
            &nbsp;
            <br />
       </center></fieldset> </div>
    
       <div id="dvChurrasco" runat="server">
    <fieldset class="login">
        <legend class="accordionContent">Área de Churrasco - <asp:Label ID="lbMesAnoChurras" runat="server" CssClass="FooterStyle"></asp:Label></legend>
    <center>
    <br />
     
       
            <br />
        <asp:GridView ID="grdReservaProgramadaChurras" runat="server" 
            AutoGenerateColumns="False" CssClass="gridl" 
            EmptyDataText="Não existe reservas futuras para churrasqueira" Font-Bold="True" 
            Font-Size="Small">
            <Columns>

               <asp:TemplateField HeaderText="Bloco">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ap.bloco") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#3BA4CB" Font-Bold="True" ForeColor="White" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apartamento">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ap.apartamento") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#3BA4CB" Font-Bold="True" ForeColor="White" />
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Data da Reserva">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("dataAgendamento") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" 
                            Text='<%# Eval("dataAgendamento", "{0:ddd}") + "-" + Eval("dataAgendamento","{0:dd/MM/yy}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle ForeColor="#006600" HorizontalAlign="Center" Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data solicitação da Reserva">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("dataInclusao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" 
                            Text='<%# Eval("dataInclusao", "{0:ddd}") + " / " + Eval("dataInclusao","{0:dd/MM/yy}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle ForeColor="#FF3300" HorizontalAlign="Center" Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dias em atraso">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" 
                            Text='<%# Eval("qtdDiasPagamentoChurras") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" 
                            
                            Text='<%# ((int)Eval("qtdDiasPagamentoChurras") <= 0) ? "Pago no mesmo dia!" : Eval("qtdDiasPagamentoChurras")  %> '>&gt;</asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" Text="Confirmar">
                <ControlStyle BackColor="#007832" Font-Bold="True" ForeColor="White" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Button" Text="Cancelar">
                <ControlStyle BackColor="#D60501" Font-Bold="True" ForeColor="White" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        <br />
            <br />
            <asp:ImageButton ID="imgBtExcelChurras" runat="server" 
            ImageUrl="~/images/excel.png" onclick="imgBtExcelChurras_Click" Width="21px" />
    </center></fieldset>  </div>


</asp:Content>
