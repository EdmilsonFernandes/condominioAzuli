<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AreaAdministrativa.aspx.cs" Inherits="Azuli.Web.Portal.AreaAdministrativa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <style type="text/css">
        .style3
        {
            height: 28px;
            width: 243px;
        }
        .style4
        {
            font-size: 12pt;
            font-weight: 700;
        }
        .style5
        {
            font-size: 12pt;
        }
        .style6
        {
            font-size: 12pt;
            font-weight: bold;
        }
        .style7
        {
            font-size: 12pt;
            font-family: Calibri;
        }
        .style8
        {
            background-color: #F0F0F0;
            border-left: 2px solid #999999;
            border-right: 2px solid #999999;
            border-botom: 2px solid #999999;
            padding: 5px 5px 5px 5px;
            font-family: Calibri;
            font-size: 8pt;
            color: #666666;
            border-radius: 1em;
            height: 15px;
        }
        .style9
        {
            background-color: #F0F0F0;
            border-left: 2px solid #999999;
            border-right: 2px solid #999999;
            border-botom: 2px solid #999999;
            padding: 5px 5px 5px 5px;
            font-family: Verdana;
            font-size: 13pt;
            color: #666666;
            height: 15px;
             border-radius: 1em;
        }
        .style10
        {
            background-color: #F0F0F0;
            border-left: 2px solid #999999;
            border-right: 2px solid #999999;
            border-botom: 2px solid #999999;
            padding: 5px 5px 5px 5px;
            font-family: Verdana;
            font-size: 11pt;
            color: #666666;
            height: 15px;
            border-radius: 1em;
        }
        .style11
        {
            font-weight: bold;
            width: 404px;
        }
        .style13
        {
            font-size: 12pt;
            width: 329px;
        }
        .style14
        {
            width: 19px;
            height: 18px;
        }
        .style15
        {
            width: 23px;
            height: 17px;
        }
        .style16
        {
            font-weight: bold;
            font-family: Calibri;
            font-size: 14pt;
            color: #006600;
        }
       
        .style17
        {
            font-family: Verdana;
            font-size: 12pt;
        }
        .style19
        {
            font-size: 12pt;
            font-weight: bold;
        }
        .style20
        {
            font-size: 12pt;
            font-weight: bold;
            width: 131px;
        }
        .style23
        {
            height: 18px;
        }
        .style25
        {
            width: 36px;
            height: 22px;
        }
        .style26
        {
            width: 35px;
            height: 25px;
        }
        .style27
        {
            font-weight: bold;
            font-family: Verdana;
            font-size: 15pt;
            color: #006600;
        }
        .style28
        {
            width: 288px;
        }
        .style29
        {
            height: 18px;
            width: 288px;
        }
        .style30
        {
            font-weight: bold;
            font-family: Calibri;
            font-size: 12pt;
            color: #006600;
        }
        .style31
        {
            border-botom: 2px solid #999999;
            font-family: Verdana;
            font-size: 10pt;
            color: #666666;
            border-radius: 1em;
            height: 15px;
            width: 412px;
            font-weight: bold;
            border-left: 2px solid #999999;
            border-right: 2px solid #999999;
            padding: 5px;
            background-color: #F0F0F0;
        }
        .style32
        {
            border-botom: 2px solid #999999;
            font-family: Verdana;
            font-size: 12pt;
            color: #0000FF;
            border-radius: 1em;
            height: 15px;
            width: 412px;
            border-left: 2px solid #999999;
            border-right: 2px solid #999999;
            padding: 5px;
            background-color: #F0F0F0;
        }
        .style33
        {
            color: #0000FF;
        }
        .gridl
        {}
        .accordionContent
        {
            width: 441px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <br /><br /><br />
    <center> <div id="dvPesquisaMorador" align="center" runat="server">
    
      <fieldset class="loginDisplayLegend">
     <legend align="left" class="accordionContent">Agendamento para Moradores: </legend>
   <center>
     <asp:Label ID="Label8" runat="server" 
        style="font-weight: 700; font-family: Calibri; font-size: 13pt; color: #006600" 
        Text="Data de Reserva escolhida: "></asp:Label>
    :&nbsp;
    &nbsp;
    <asp:Label ID="lblDataReserva" runat="server" 
        style="font-weight: 700; font-family: Calibri; font-size: 14pt" 
        CssClass="accordionContent"></asp:Label>
            <br />
            <br />
            
             <table  style="height: 83px; width: 546px;" class="accordionContent">
                        <tr>
                            <td class="style3">
                                <asp:Label ID="lblSelecioneBloco" runat="server" Font-Bold="True" 
                                    Text="Selecione o Bloco:" style="font-size: 12pt"></asp:Label>
                            </td>
                            <td class="style13" align="left">
                                <asp:DropDownList ID="drpBloco" runat="server" Height="20px" Width="46px" 
                                    CssClass="style4">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                             <asp:ListItem>6</asp:ListItem>
                        </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <asp:Label ID="lblApart" runat="server" Font-Bold="True" 
                                    Text="Digite o Apartamento:" style="font-size: 12pt"></asp:Label>
                            </td>
                            <td class="style13" align="left">
                                <asp:TextBox ID="txtAp" runat="server" 
                                    onKeyPress="return Decimal(this,event);"  Width="58px" CssClass="style4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPesquisaAP" runat="server" 
                                    ControlToValidate="txtAp" ErrorMessage="Favor preencher o Apartamento!" 
                                    ValidationGroup="pesquisaAP" 
                                    style="font-family: Calibri; font-size: 11pt; color: #FF3300; font-weight: 700"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style13" align="left">
                                <asp:Button ID="btnOk" runat="server" CssClass="botao" Text="Pesquisar" 
                                    Width="103px" onclick="btnOk_Click" ValidationGroup="pesquisaAP" />
&nbsp;<asp:Button ID="btnOk0" runat="server" CssClass="botao" Text="voltar" 
                                    Width="75px" onclick="btnOk0_Click" />
                            </td>
                        </tr>
               
        </table></center>
  </fieldset> </div> </center>
  
 <center> 
     <asp:Label ID="lblMsgCadastro" runat="server" CssClass="accordionHeader" 
         ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:Label>
     <br />
    <asp:ImageButton ID="imgCalendar" runat="server" 
        DescriptionUrl="Voltar Calendario" Height="36px" 
        ImageUrl="~/images/calendario.png" onclick="ImageButton1_Click2" Width="42px" />
                        <asp:HyperLink ID="hplnkWelcomeAdmin" runat="server" ForeColor="Blue" 
                            NavigateUrl="~/WelcomeAdmin.aspx">Clique aqui para voltar ao calendário</asp:HyperLink>
                                </center>

 
    <div id="dvNewUser" align="center" runat="server">
    <fieldset class="loginDisplayLegend">
      <legend align="left" class="accordionContent">Novo Cadastro de Morador</legend>
   
  <center> <br /> <br />
     <asp:Label ID="lblMsg" runat="server" 
         Text="Label" style="font-family: Calibri; font-size: 17pt" 
          CssClass="accordionContent" Width="800px" Height="38px"></asp:Label>
   <br /><br />
     <asp:Button ID="btnCadastrar" runat="server" CssClass="botao" Text="Sim" 
         Width="74px" onclick="btnCadastrar_Click" Height="35px" />
&nbsp;
     <asp:Button ID="btnCancelar" runat="server" CssClass="botao" 
         onclick="btnCancelar_Click" Text="Não" Width="69px" Height="35px" />
          <br />

     <br /></center></fieldset></div>

     <div id="dvDadosMorador" align="center" runat="server">
     <fieldset class="loginDisplayLegend">
     <legend align="left" class="accordionContent">&nbsp;<img alt="" class="style15" 
             src="images/clientes.jpg" /> Dados do Morador para Reserva:
                
                        </legend>
  

    

     <table style="border: thin solid #C0C0C0; height: auto; width: 457px;" 
              class="accordionContent">
                            
                       <tr>
                            <td class="style20" align="right">
                                <asp:Label ID="Label3" runat="server" 
        style="font-weight: 700; font-family: Calibri; font-size: 13pt; color: #006600" 
        Text="Data da Reserva: "></asp:Label></td>
                            <td align="center">
                                <asp:Label ID="lblDataReserva2" runat="server" 
        style="font-weight: 700; font-family: Calibri; font-size: 12pt" 
        CssClass="accordionContent" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
                        </tr>
                
                       <tr>
                            <td class="style20" align="right">
                                <asp:Label ID="lblProprietario" runat="server" Font-Bold="True" Text="Nome:" 
                                    CssClass="style17"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblProprietarioDesc" runat="server" CssClass="style27"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20" align="right">
                                <asp:Label ID="lblBloco" runat="server" Font-Bold="True" Text="Bloco:" 
                                    CssClass="style17"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblBlocoDesc" runat="server" Text="6" CssClass="style27"></asp:Label>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="style20" align="right">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="APTO: " 
                                    CssClass="style17"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblApartDesc" runat="server" Text="301" CssClass="style27"></asp:Label>
                            </td>

                        </tr>
                       <tr>
                       <td class="style19" colspan="2" align="center">
                                     <asp:Button ID="btnOkPesquisa" runat="server" CssClass="botao" Text="Confirmar" 
                        Width="90px" onclick="btnOkPesquisa_Click" Height="27px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel0" runat="server" CssClass="botao" 
                        Text="Cancelar" onclick="btnCancel0_Click1" Height="27px" Width="90px"  />

      

        
                            &nbsp;&nbsp;&nbsp;<br />
                                     <br />
&nbsp;<asp:LinkButton ID="lnkHistoricoReservas" runat="server" onclick="lnkHistoricoReservas_Click">Morador já tem agendamentos - clique para ver..</asp:LinkButton>

      

        
                            </td>
                       
                       </tr>
                    
                </td>
            </tr>
        </table>

    
       
   </fieldset> </div>

   <center>  <div id="dvAgendamentosFuturos" runat="server">
      <fieldset>
       <legend id="lgFesta" class="style32" runat="server">Salão de Festa </legend>
         <asp:GridView ID="grdReservaProgramadaFesta" runat="server" 
             CssClass="gridl" AutoGenerateColumns="False" 
              EmptyDataText="Não existe reservas futuras para o Salão de festa" 
              Font-Bold="False" Font-Size="Small">
             <Columns>
                 <asp:TemplateField HeaderText="Data da Reserva">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataAgendamento") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("dataAgendamento", "{0:ddd}") + "-" + Eval("dataAgendamento","{0:dd/MM/yy}") %>'></asp:Label>
                     </ItemTemplate>
                     <HeaderStyle Width="120px" />
                     <ItemStyle HorizontalAlign="Left" ForeColor="#006600" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Reserva será aqui (Dias)">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("contadorFestaFuturo") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("contadorFestaFuturo") %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Left" />
                 </asp:TemplateField>


                  <asp:TemplateField HeaderText="Data solicitação da Reserva">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataInclusao") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("dataInclusao", "{0:ddd}") + "-" + Eval("dataInclusao","{0:dd/MM/yy}") %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle Font-Size="Small" ForeColor="Red" />
                 </asp:TemplateField>


                  <asp:TemplateField HeaderText="Data de PG" Visible="false">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("dataConfirmacaoPagamento") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("dataConfirmacaoPagamento", "{0:ddd}") + "-" + Eval("dataConfirmacaoPagamento","{0:dd/MM/yy}") %>'></asp:Label>
                     </ItemTemplate>
                      <HeaderStyle Width="120px" />
                     <ItemStyle ForeColor="#006600" />
                 </asp:TemplateField>

                  <asp:TemplateField HeaderText="PG feito em (Dias)" Visible="false">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("qtdDiasPagamentoFesta") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# ((int)Eval("qtdDiasPagamentoFesta") <= 0) ? "Pago no mesmo dia!" : Eval("qtdDiasPagamentoFesta")  %> '></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Left" />
                 </asp:TemplateField>

                


                 <asp:BoundField DataField="observacao" HeaderText="Obs.:" >
                 <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
             </Columns>
         </asp:GridView>
                
                        <br />
                     <hr />
           <legend id="lgChurras" class="style31" runat="server"><span class="style33">
               <font size="3">churrasqueira</font></span><br 
                   style="color: #0000FF" class="style5" />
             
          </legend> <br />
         <asp:GridView ID="grdReservaProgramadaChurras" runat="server" 
             CssClass="gridl" AutoGenerateColumns="False"  
              EmptyDataText="Não existe reservas futuras para churrasqueira" Font-Bold="True" 
              Font-Size="Small">
              <Columns>
                  <asp:TemplateField HeaderText="Data da Reserva">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataAgendamento") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Eval("dataAgendamento", "{0:ddd}") + "-" + Eval("dataAgendamento","{0:dd/MM/yy}") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" ForeColor="#006600" Width="120px" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Reserva será aqui (Dias)">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" 
                              Text='<%# Bind("contadorChurrasFuturo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" 
                              Text='<%# Bind("contadorChurrasFuturo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>


                  <asp:TemplateField HeaderText="Data solicitação da Reserva">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dataInclusao") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("dataInclusao", "{0:ddd}") + " / " + Eval("dataInclusao","{0:dd/MM/yy}") %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" ForeColor="#FF3300" Width="120px" />
                 </asp:TemplateField>


                  <asp:TemplateField HeaderText="Data de PG" Visible="false">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("dataConfirmacaoPagamento") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("dataConfirmacaoPagamento", "{0:ddd}") + " / " + Eval("dataConfirmacaoPagamento","{0:dd/MM/yy}") %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" ForeColor="#006600" Width="120px" />
                 </asp:TemplateField>

                  <asp:TemplateField HeaderText="PG foi feito em (Dias)" Visible="false">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("qtdDiasPagamentoChurras") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# ((int)Eval("qtdDiasPagamentoChurras") <= 0) ? "Pago no mesmo dia!" : Eval("qtdDiasPagamentoChurras")  %> '>></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>



                  <asp:TemplateField HeaderText="Obs.:">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("observacao") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Bind("observacao") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
             </Columns>
         </asp:GridView>
          <br />
         </fieldset>
      </div></center> 
                
        <div id="dvSalaoEstatistica1"  runat="server" 
                            
        
        
        
        
        
        
        
        
        
        
        style="position: absolute; top: 178px; left: 701px; height: 91px; width: 274px;">
        <table 
              class="accordionContent">
            <tr>
                <td align="center">
                
                        <img alt="" class="style26" 
                            src="images/salaoFesta.jpg" />&nbsp;
                        <asp:Label 
                            ID="Label23" runat="server" 
                            style="font-weight: 700; font-family: Calibri; font-size: 12pt; color: #0000FF;" 
                            Text="Salão de Festa"></asp:Label>
                
                        <tr>
                            <td class="style23" align="left">
                                <asp:Label ID="lblReservaFestaFoi" runat="server" 
                                    style="font-weight: 700"></asp:Label>
                                &nbsp;<asp:Label ID="lblSalao" runat="server" CssClass="style16">5</asp:Label>
                            &nbsp;<b>dia(s)</b></td>
                        </tr>
                    
                </td>
            </tr>
                
                        <tr>
                            <td class="style23" align="left">
                                <asp:Label ID="lblDataReservaUltimaDescription" runat="server" 
                                    style="font-weight: 700"></asp:Label>
                                &nbsp;<asp:Label ID="lblDataUltimaReservaSalao" runat="server" 
                                    CssClass="style30">31/08/2013</asp:Label>
                            </td>
                        </tr>
                    
                </table>
        </div>

        <div id="dvChurras"  runat="server" 
                            
        
        
        
        
        
        
        
        
        
        
        style="position: absolute; top: 292px; left: 703px; height: 79px; width: 283px;">
        <table 
              class="accordionContent">
            <tr>
                <td align="center" class="style28">
                
                        <img alt="" class="style25" src="images/churrasco.jpg" />&nbsp; 
                        <asp:Label 
                            ID="Label2" runat="server" 
                            style="font-weight: 700; font-family: Calibri; font-size: 12pt; color: #0000FF;" 
                            Text="Churrasqueira "></asp:Label>
                
                        <tr>
                            <td class="style29" align="left">
                                <asp:Label ID="lblReservaChurraFoi" runat="server" 
                                    style="font-weight: 700"></asp:Label>
                                &nbsp;<asp:Label ID="lblChurras" runat="server" CssClass="style16">5</asp:Label>
                            &nbsp;<b>dia(s)</b></td>
                        </tr>
                    
                </td>
            </tr>
                
                        <tr>
                            <td class="style29" align="left">
                                <asp:Label ID="lblDataReservaUltimaChurras" runat="server" 
                                    style="font-weight: 700"></asp:Label>
&nbsp;<asp:Label ID="lblDataUltimaReservachurras" runat="server" CssClass="style30">31/08/2013</asp:Label>
                            </td>
                        </tr>
                    
                </table>
        </div>
 
 <center> <div id="dvCadastro"  runat="server" align="center" >
 <fieldset class="loginDisplayLegend"> 
 <legend class="style9">
     <img alt="" class="style14" src="images/novo_morador_visitante.png" /> Cadastrar Moradores</legend>
 
      <table class="accordionContent" align="center">
            <tr>
                <td class="" align="center">
                    <table class="style1" border='0'>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="lblPropre1" runat="server" Font-Bold="True" Text="Morador" 
                                    CssClass="style7"></asp:Label>
                            </td>
                            <td class="">
                                <asp:TextBox ID="txtMorador1" runat="server" Width="167px" CssClass="style5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMorador1" runat="server" 
                                    ControlToValidate="txtMorador1" CssClass="failureNotification" ErrorMessage="*" 
                                    ValidationGroup="cadastraMorador"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Text="E-mail" 
                                    CssClass="style7"></asp:Label>
                            </td>
                            <td class="">
                            <asp:TextBox ID="txtEmail" runat="server" Width="165px" CssClass="style5" 
                                    AutoPostBack="True" >Não tem no momento</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Apartamento: " 
                                    CssClass="style7"></asp:Label>
                            </td>
                            <td class="">
                                 <asp:TextBox ID="txtApartamento" runat="server" 
                                     onKeyPress="return Decimal(this,event);"  Width="53px" CssClass="style6"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvAp" runat="server" 
                                     ControlToValidate="txtApartamento" CssClass="failureNotification" 
                                     ErrorMessage="*" ValidationGroup="cadastraMorador"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Bloco:" 
                                    CssClass="style7"></asp:Label>
                            </td>
                            <td class="">
                                 <asp:TextBox ID="txtBlocos" runat="server" 
                                     onKeyPress="return Decimal(this,event);"  Width="53px" CssClass="style6" />
                                 <asp:RequiredFieldValidator ID="rfvBloco" runat="server" 
                                     ControlToValidate="txtBlocos" CssClass="failureNotification" ErrorMessage="*" 
                                     ValidationGroup="cadastraMorador"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnCadastroMorador" runat="server" CssClass="botao" Text="Efetuar Cadastro" 
                        Width="150px" onclick="btnCadastroMorador_Click" 
                        ValidationGroup="cadastraMorador" 
                        style="font-family: Calibri; font-size: 12pt; font-weight: bold" />
&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="btnCancelarCadastro" runat="server" CssClass="botao" 
                        Text="Cancelar cadastro" onclick="btnCancelarCadastro_Click" 
                        style="font-family: Calibri; font-size: 12pt; font-weight: bold"  />
                </td>
            </tr>
        </table>
      
  </fieldset>   </div></center>


</asp:Content>
