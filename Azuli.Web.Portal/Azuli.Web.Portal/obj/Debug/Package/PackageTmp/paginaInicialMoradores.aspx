<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="paginaInicialMoradores.aspx.cs" Inherits="Azuli.Web.Portal.paginaInicialMoradores" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style1
        {
            font-family: "Segoe UI";
            font-size: medium;
            color:black;
        }
        .style3
        {
            width: 33px;
            height: 27px;
        }
        .style7
        {
            font-family: "Segoe UI";
            font-weight: normal;
            font-size: small;
            font-variant: normal;
        }
        .style8
        {
            font-weight: normal;
        }
        .GridViewPager
        {
            width: 177px;
        }
        .style10
        {
            font-weight: bold;
        }
        .style11
        {
            font-weight: bold;
            color: #333333;
            font-size: small;
            align:center;
        }
        .style12
        {
            font-weight: bold;
            color: #000000;
        }
        .style13
        {
            background-color: #F0F0F0;
            border-left: 1px solid #0093d4;
    border-right: 1px solid #0093d4;
    border-bottom: 1px solid #0093d4;
    border-top:  1px solid #0093d4;
            padding: 5px 5px 5px 5px;
            font-family: Verdana;
            font-size: 10pt;
            color: #666666;
            border-radius: 1em;
            height: 15px;
        }
        .style14
        {
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  
 <center>   <fieldset class="loginDisplayLegend">
        <legend class="style13">Seja bem vindo ao Sistema</legend>
   <div id="dvMsg" runat="server" style="position:relative;">
    <table  style="text-align:justify;">
        <tr>
            <td align="center">
                <img  alt="1" src="images/azuli.jpg" style="width: 96%; height: 119px" />
            </td>
            <td align="center">
                <h1 align="left">
                    &nbsp; Senhor(ª)
                    <asp:Label ID="lblMorador" runat="server" ForeColor="Blue"></asp:Label>&nbsp;<span
                        class="style7">- Você tem
                        <asp:LinkButton ID="lnkBtnMsg" runat="server" Font-Bold="True" Font-Size="Medium"
                            ForeColor="#009900" OnClick="lnkBtnMsg_Click1">0</asp:LinkButton>
                        <span class="style8">&nbsp;mensagens&nbsp;
                            <img alt="" class="style3" src="images/correio.jpg" /></span></span> </h1>
                          
                      

            </td>
            
             
     
        </tr>
        
        </table>
        <div style="position:absolute; top: -42px; left: 536px; width: 157px; height: 78px;">
        <div  id="dvUteis"  class="containerTel" runat="server">
            <div class="headerEnqueteTel">
                <span class="style12"> Telefones Utéis <img src="images/tel.jpg"  alt="" width="20px" height="20px"/></span>
            </div>
            <div class="mainbodyTel">
          
              <p><b>Portaria - Ramal 94 / Tel: 3302-5729 </b> </p>
               <b> Sindico - Ramal 93 / Tel: 3027-7997</b>  <br />
            </div>
            <div class="FooterEnqueteTel">

            </div>
       
      </div>
      </div>
       
       
    </div>

    <hr />
        <table  class="style14">
            <tr>
                <td align="center">

    
    <fieldset>
        <legend class="accordionContent">  <asp:Label ID="Label5" runat="server" 
                Text="Clique no Calendário abaixo para Consultar Reservas!"></asp:Label></legend>
       
       <table class="style21">
          <tr>
              <td align="right">
                  <asp:ImageButton ID="ImageButton1" runat="server" Height="91px" 
                      ImageUrl="~/images/calendario.png" Width="109px" />
              </td>
              <td>
                  <asp:HyperLink ID="hplSucess" runat="server" 
                      style="font-weight: 900; font-size: 9pt;color:green;" CssClass="accordionContent" 
                      Font-Bold="False" NavigateUrl="~/telaAgendamento.aspx" Width="330px">Clique aqui e consulte as reservas disponíveis</asp:HyperLink>
              </td>
          </tr>
      </table>
          
        
        </fieldset></td>
                <td align="center">
        <fieldset>
<legend class="accordionContent">  <asp:Label ID="Label2" runat="server" 
                Text="Faço Download dos arquivos abaixo!"></asp:Label></legend>
        <li style="color: #000080">
            <asp:LinkButton ID="link1" runat="server" OnClick="link1_Click">Regimento Interno do Condominio Azuli &nbsp;<img alt=""  src="images/pdf.jpg" style="height: 24px; width: 24px" /></asp:LinkButton></li>
         <li style="color: #000080">
            <asp:LinkButton ID="lnkDonwload" runat="server"  OnClick="lnkDonwload_Click">Funcionalidades do sistema SGC! &nbsp;<img alt=""  src="images/pdf.jpg" style="height: 24px; width: 24px" /></asp:LinkButton></li>
       </fieldset></td>
            </tr>
        </table>
        <hr />
       
        <div  id="dvEnquete" style="position:absolute" class="container" runat="server">
            <div class="headerEnquete">
                <span class="style12">         Enquete - Condomínio Azuli </span>
            </div>
            <div class="mainbody">
                <b style="color: #000000">Você julga importante a utilização de um
                <br />
                software de gestão/colaboração no condomínio?</b><br />
                <br />
                <table class="GridViewPager">
                    <asp:RadioButtonList ID="rdlEnquete" runat="server" 
                        DataSourceID="SqlDataSourceRadio" DataTextField="descricaoEnquete" DataValueField="idEnquete">
                        <asp:ListItem Value="1"> Indispensável   </asp:ListItem>
                        <asp:ListItem Value="2"> Muito importante</asp:ListItem>
                        <asp:ListItem Value="3"> Importante</asp:ListItem>
                        <asp:ListItem Value="4"> Pouco Importante</asp:ListItem>
                        <asp:ListItem Value="5"> Dispensável</asp:ListItem>
                       
                    </asp:RadioButtonList>
                    <br />
                
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                        ID="lblMsg"  runat="server" 
                        CssClass="accordionContent" Font-Bold="True" ForeColor="#0066FF" 
                        Visible="False"></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSourceRadio" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:azulli %>" 
                        SelectCommand="SELECT idEnquete, descricaoEnquete FROM [Enquete]"></asp:SqlDataSource>
                </table>
            </div>
            <div class="FooterEnquete">
                <asp:Button ID="btnVotar" Text="     VOTAR" runat="server" BackColor="#99CCFF" 
                    CssClass="GridViewEdit" Font-Bold="True" ForeColor="Black" Width="82px" 
                    onclick="btnVotar_Click" Height="23px"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkResultado" OnClick="lnkResultado_Click" runat="server" 
                    Font-Bold="True">Ver Resultado</asp:LinkButton>
            </div>
       
      </div>
       <div  id="dvResultado" style="position:absolute" class="container" runat="server">
            <div class="headerEnquete">
                <span class="style12">Enquete - Condomínio Azuli </span>
            </div>
            <div class="mainbody">
                <b style="color: #000000">Você julga importante a utilização de um
                <br />
                software de gestão/colaboração no condomínio?</b><br />
              <div style="margin-top: 8px;">
                                        Muito importante</div>
                                    <div>
                                        <div id="dvMuitoImport" runat="server" style="float: left; background-color: #B9E1F6; width: 0%">
                                            &nbsp;</div>
                                        <div style="float: left; font-size: 11px;">
                                              &nbsp;<asp:Label 
                                                  ID="lblMuitoImportante" runat="server" CssClass="style10">0 voto(s), (0%)</asp:Label>
                                        </div>
                                    </div>
                                    <br>
                                
                                    <div style="margin-top: 8px;">
                                        Indispensável</div>
                                    <div>
                                        <div id="dvIndisp" runat="server" style="float: left; background-color: #B9E1F6; width:0%">
                                            &nbsp;</div>
                                        <div style="float: left; font-size: 11px;">
                                            &nbsp; <asp:Label ID="lblIndispensavel" runat="server" CssClass="style10">0 voto(s), (0%)</asp:Label>
                                        </div>
                                    </div>
                                    <br>
                                
                                    <div style="margin-top: 8px;">
                                        Importante</div>
                                    <div>
                                        <div id="dvImportante" runat="server" style="float: left; background-color: #B9E1F6; width:0%">
                                            &nbsp;</div>
                                        <div style="float: left; font-size: 11px;">
                                             &nbsp;<asp:Label ID="lblImportante" runat="server" CssClass="style10">0 voto(s), (0%)</asp:Label>
                                        </div>
                                    </div>
                                    <br>
                                
                                    <div style="margin-top: 8px;">
                                        Dispensável</div>
                                    <div>
                                        <div id="dvDispen" runat="server" style="float: left; background-color: #B9E1F6; width: 0%">
                                            &nbsp;</div>
                                        <div style="float: left; font-size: 11px;">
                                            &nbsp; <asp:Label ID="lblDispensavel" runat="server" CssClass="style10">0 voto(s), (0%)</asp:Label>
                                        </div>
                                    </div>
                                    <br>
                                
                                    <div style="margin-top: 8px;">
                                        Pouco Importante</div>
                                    <div>
                                        <div id="dvPoucoImpor" runat="server" style="float: left; background-color: #B9E1F6; width: 0%">
                                            &nbsp;</div>
                                        <div style="float: left; font-size: 11px;">
                                             &nbsp;<asp:Label ID="lblPoucoImportante" runat="server" CssClass="style10">0 voto(s), (0%)</asp:Label>
                                        </div>
                                    </div>
                                    <br>
                                
                            <br>
                           
               
            </div>
            <div class="FooterEnquete">
                 <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tbody><tr>
                                    <td>
                                        <b>Total:&nbsp;<span><asp:Label ID="lblTotal" runat="server"></asp:Label></span>&nbsp;voto(s)</b>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="lnkVoltar" runat="server" Font-Bold="True" 
                                            onclick="lnkVoltar_Click1">Voltar</asp:LinkButton>
                                    </td>
                                </tr>
                            </tbody></table>
            </div>
       
      </div>

      
        <div  id="dvClassificado" class="containerClass" 
         
        runat="server">
            <div class="headerEnqueteClass">
                <span class="style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img alt="" src="images/class.jpg" style="height: 30px; width: 214px" /></span>
            </div>
            <div class="mainbodyClass">
           
             
          
            <asp:GridView ID="grdClassificado" runat="server" AutoGenerateColumns="False"  EmptyDataText="Não existem Anúncios no momento"
                CssClass="gridl" ShowHeader="false">
                <Columns>
                    <asp:TemplateField Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" 
                                Text='<%# Bind("idClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("idClassificado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField DataImageUrlField="classificadoimg1" 
                        DataImageUrlFormatString="~/ServerFile/Classificados/{0}">
                        <ControlStyle Width="45px" />
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
                    <asp:TemplateField HeaderText="Preço">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" 
                                Text='<%# Bind("valorVendaClassificado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" 
                                Text='<%# Bind("valorVendaClassificado","{0:N2}")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="True" ForeColor="#333333" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView> 
            </div>
            <div class="FooterEnqueteClass">
               <center> <asp:Button ID="btnClassificados" 
                       Text="            Clique aqui e veja mais ..." runat="server" BackColor="#99CCFF" 
                    CssClass="GridViewEdit" Font-Bold="True" ForeColor="Black" Width="250px" 
                    onclick="btnClassificados_OnClick" Height="24px"  /></center>
           
            </div>
       
      </div>
       <br /><br /> <br /><br /> <br /><br /> <br /><br /> <br /><br /> <br /><br /> <br /><br /><br /><br /> <br /><br /><br /><br /> <br /><br />
       </fieldset>   </center>

  
</asp:Content>
