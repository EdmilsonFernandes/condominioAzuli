<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true"
    CodeBehind="gerenciamentoMoradorAdm.aspx.cs" Inherits="Azuli.Web.Portal.gerenciamentoMoradorAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <style type="text/css">
        .ObjectLarge
        {            margin-left: 2px;
        }
        .style3
        {
            width: 173px;
            text-align: left;
        }
        .style4
        {
            width: 280px;
        }
        .style5
        {
            width: 347px;
        }
        .style6
        {
            width: 52px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div id="dvCadastro" align="center" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Cadastro de Moradores</legend>
            <center>
                 <br />
                <label class="accordion-group"><b class="accordionHeaderSelected">Dados do morador responsável</b></label>
                <br />
                <table class="accordionContent">
                    <tr>
                        <td>
                            <asp:Label ID="lblcond01" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome do Morador responsável:</asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtCond01" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="273px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCond01"
                                ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblBloco" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Bloco:</asp:Label>
                        </td>
                        <td class="style3">
                        <asp:DropDownList ID="drpBloco" runat="server" Height="25px" Width="52px" 
                                            style="font-size: medium; font-weight: 700;" 
                                            CssClass="AlternatingRowStyle">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                        </asp:DropDownList>
                            <%--    <asp:TextBox ID="txtBloco" runat="server" Height="19px" Width="87px"></asp:TextBox>--%>
                            <asp:RequiredFieldValidator ID="rfvName0" runat="server" ControlToValidate="drpBloco"
                                ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblAP" runat="server" CssClass="Field" 
                                Style="font-weight: bold; font-size: 9pt; text-align: left;">Apartamento:</asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtAP" runat="server" Height="18px" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName1" runat="server" ControlToValidate="txtAP"
                                ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">E-mail</asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="200" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"
                                Width="144px">Não tem no momento</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="2">
                            &nbsp;<asp:RadioButtonList ID="lstRadioButton" runat="server" style="font-size: 9pt" 
                                Width="169px">
                                <asp:ListItem Selected="True" Value="Proprietário">Proprietário</asp:ListItem>
                                <asp:ListItem Value="Locatário">Locatário</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTelefone" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Telefone:</asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtTelefone" runat="server" MaxLength="200" 
                                AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"
                                Width="144px">Não tem no momento</asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div id="dvDesenv" runat="server" visible="False">
                <br />
                <label class="accordion-group"><b class="accordionHeaderSelected">Dependentes (esposa, Filhos e outros)</b></label>
                <br />
                <table class="accordionContent">
             
            
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtboxDepedente1" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Parentesco</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpdownParentesco1" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="273px">
                                <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                <asp:ListItem>Pai</asp:ListItem>
                                <asp:ListItem>Mãe</asp:ListItem>
                                <asp:ListItem>Filho(ª)</asp:ListItem>
                                <asp:ListItem>Tio(ª)</asp:ListItem>
                                <asp:ListItem>Sogro(ª)</asp:ListItem>
                                <asp:ListItem>Enteado(ª)</asp:ListItem>
                                <asp:ListItem>Primo(ª)</asp:ListItem>
                                <asp:ListItem>Outro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label13" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Nascimento</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDatanascimento1" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label17" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtNomeDepedente2" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label18" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Parentesco</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpdownParentesco2" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="273px">
                                <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                <asp:ListItem>Pai</asp:ListItem>
                                <asp:ListItem>Mãe</asp:ListItem>
                                <asp:ListItem>Filho(ª)</asp:ListItem>
                                <asp:ListItem>Tio(ª)</asp:ListItem>
                                <asp:ListItem>Sogro(ª)</asp:ListItem>
                                <asp:ListItem>Enteado(ª)</asp:ListItem>
                                <asp:ListItem>Primo(ª)</asp:ListItem>
                                <asp:ListItem>Outro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label19" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Nascimento</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDatanascimento2" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label20" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtNomeDepedente3" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label21" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Parentesco</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpdownParentesco3" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="273px">
                                <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                <asp:ListItem>Pai</asp:ListItem>
                                <asp:ListItem>Mãe</asp:ListItem>
                                <asp:ListItem>Filho(ª)</asp:ListItem>
                                <asp:ListItem>Tio(ª)</asp:ListItem>
                                <asp:ListItem>Sogro(ª)</asp:ListItem>
                                <asp:ListItem>Enteado(ª)</asp:ListItem>
                                <asp:ListItem>Primo(ª)</asp:ListItem>
                                <asp:ListItem>Outro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label22" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Nascimento</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataascimento3" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label23" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtNomeDepedente4" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label24" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Parentesco</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpdownParentesco4" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="273px">
                                <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                <asp:ListItem>Pai</asp:ListItem>
                                <asp:ListItem>Mãe</asp:ListItem>
                                <asp:ListItem>Filho(ª)</asp:ListItem>
                                <asp:ListItem>Tio(ª)</asp:ListItem>
                                <asp:ListItem>Sogro(ª)</asp:ListItem>
                                <asp:ListItem>Enteado(ª)</asp:ListItem>
                                <asp:ListItem>Primo(ª)</asp:ListItem>
                                <asp:ListItem>Outro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label25" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Nascimento</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDatanascimento4" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label26" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtNomeDepedente5" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label27" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Parentesco</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpdownParentesco5" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="273px">
                                <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                <asp:ListItem>Pai</asp:ListItem>
                                <asp:ListItem>Mãe</asp:ListItem>
                                <asp:ListItem>Filho(ª)</asp:ListItem>
                                <asp:ListItem>Tio(ª)</asp:ListItem>
                                <asp:ListItem>Sogro(ª)</asp:ListItem>
                                <asp:ListItem>Enteado(ª)</asp:ListItem>
                                <asp:ListItem>Primo(ª)</asp:ListItem>
                                <asp:ListItem>Outro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label28" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Nascimento</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDatanascimento5" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label14" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtNomeDepedente6" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label15" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Parentesco</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpdownParentesco6" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="273px">
                                <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                <asp:ListItem>Pai</asp:ListItem>
                                <asp:ListItem>Mãe</asp:ListItem>
                                <asp:ListItem>Filho(ª)</asp:ListItem>
                                <asp:ListItem>Tio(ª)</asp:ListItem>
                                <asp:ListItem>Sogro(ª)</asp:ListItem>
                                <asp:ListItem>Enteado(ª)</asp:ListItem>
                                <asp:ListItem>Primo(ª)</asp:ListItem>
                                <asp:ListItem>Outro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label16" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Nascimento</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDatanascimento6" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                 <br />
                <label class="accordion-group"><b class="accordionHeaderSelected">Empregados</b></label>
                <br />
                <table class="accordionContent">
             
            
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td style="text-align: left" class="style4">
                            <asp:TextBox ID="txtBoxNomeEmpregado" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label10" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">RG</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtBoxRG" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label11" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td style="text-align: left" class="style4">
                            <asp:TextBox ID="txtBoxNomeEmpregado1" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label30" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">RG</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxRG1" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    <br />
                <label class="accordion-group"><b class="accordionHeaderSelected">Veículos (Motos, Carros, Bicicletas, outros)</b></label>
                <br />
                <table class="accordionContent">
             
            
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Marca/Modelo</asp:Label>
                            :</td>
                        <td style="text-align: left" class="style4">
                            <asp:TextBox ID="TextBoxMarcaModelo1" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label29" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">COR:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxCor1" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label33" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Placa:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxPlaca1" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label34" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Marca/Modelo</asp:Label>
                            :</td>
                        <td style="text-align: left" class="style4">
                            <asp:TextBox ID="TextBoxMarcaModelo2" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label35" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">COR:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxCor2" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label36" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Placa:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxPlaca2" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label37" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Marca/Modelo</asp:Label>
                            :</td>
                        <td style="text-align: left" class="style4">
                            <asp:TextBox ID="TextBoxMarcaModelo3" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label38" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">COR:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxCor3" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label39" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Placa:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxPlaca3" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>

                            <br />
                <label class="accordion-group"><b class="accordionHeaderSelected">Em caso de emergência</b></label>
                <br />
                <table class="accordionContent">
             
            
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label31" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome:</asp:Label>
                            :</td>
                        <td style="text-align: left" class="style4">
                            <asp:TextBox ID="TextBoxNomeEmergencia" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label32" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Parentesco:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtBoxParentescoEmergencia" runat="server" 
                                CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label40" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Contato:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textboxContatoEmergencia" runat="server" 
                                CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                      <br />
                      <br />
                <label class="accordion-group"><b class="accordionHeaderSelected">Animais</b></label>
                <br />
                <table class="accordionContent">
             
            
                    <tr>
                    
                        <td>
                            <asp:Label ID="Label44" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Quantidade(s)</asp:Label>
                            :</td>
                        <td style="text-align: left" class="style6">
                            <asp:DropDownList ID="DropDownListQuantdAnimal" runat="server" Height="16px" 
                                style="font-weight: 700" Width="43px">
                                <asp:ListItem Selected="True">0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem Value="5"></asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label45" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Espécie:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxEspecieAnimal" runat="server" CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="580px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                      <br />
                <label class="accordion-group"><b class="accordionHeaderSelected">Informações da Imobiliária (Caso não seja proprietário)</b></label>
                <br />
                <table class="accordionContent">
             
            
                    <tr>
                    
                        <td class="style5">
                            <asp:Label ID="Label41" runat="server" CssClass="Field" Style="font-weight: bold;
                                font-size: 9pt">Nome da Empresa</asp:Label>
                            :</td>
                        <td style="text-align: left" class="style4">
                            <asp:TextBox ID="TextBoxEmpresaImobiliaria" runat="server" 
                                CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="234px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label42" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Telefone:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxTelefoneImobiliaria" runat="server" 
                                CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="Label43" runat="server" CssClass="Field" meta:resourcekey="lblActivity"
                                Style="font-weight: bold; font-size: 9pt">Contato:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBoxContatoImobiliaria" runat="server" 
                                CssClass="ObjectLarge" MaxLength="100"
                                Height="21px" Width="161px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    <br />
                    </div>
                <asp:ImageButton ID="ibtAddSave" runat="server" 
                     ImageUrl="~/images/botao cadastro.png" ValidationGroup="InputValidationGroup"
                    OnClick="ibtAddSave_Click" Width="100px" Height="31px" />
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ibtCancel" runat="server" ImageUrl="~/Images/cancel.png" OnClick="ibtCancel_Click"
                    Height="20px" Width="18px" />
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ibtSearch" runat="server" ImageUrl="~/images/search.png" OnClick="ibtSearch_Click"
                    Width="20px" />
                <br />
                <br />
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
       
   
                <br />

</center></fieldset>
  
    </div>
    <div id="dvGridAll" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Gerenciamento de Moradores</legend>
            <br />
    
    <center>
        
            <asp:GridView ID="grdGerenciamentoMoradores" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CssClass="gridl" DataKeyNames="PROPRIETARIO_BLOCO,PROPRIETARIO_AP"
                DataSourceID="SqlDataSourceGerenciamentoUser" Height="86px" Width="852px" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="NOME_PROPRIETARIO1" HeaderText="Condomino 01" SortExpression="NOME_PROPRIETARIO1" />
                    <asp:BoundField DataField="PROPRIETARIO_BLOCO" HeaderText="Bloco" ReadOnly="True"
                        SortExpression="PROPRIETARIO_BLOCO">
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PROPRIETARIO_AP" HeaderText="Apartamento" ReadOnly="True"
                        SortExpression="PROPRIETARIO_AP">
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                    <asp:BoundField HeaderText="Senha" DataField="PASSWORD">
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" />
                    <asp:BoundField DataField="PROPRIETARIO_IMOVEL" HeaderText="Sobre o Imóvel" />
                    <asp:CheckBoxField DataField="STATUS" HeaderText="ATIVO" SortExpression="STATUS" />
                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.png" DeleteImageUrl="~/images/delete.png"
                        EditImageUrl="~/images/edit.png" ShowEditButton="True" UpdateImageUrl="~/images/save.png" />
                </Columns>
            </asp:GridView>
    </center>  </fieldset></div>
  
    <asp:SqlDataSource ID="SqlDataSourceGerenciamentoUser" runat="server" ConnectionString="<%$ ConnectionStrings:azulli %>"
        DeleteCommand="DELETE FROM [PROPRIETARIO] WHERE [PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO AND [PROPRIETARIO_AP] = @PROPRIETARIO_AP"
        InsertCommand="INSERT INTO [PROPRIETARIO] ([NOME_PROPRIETARIO1], [PROPRIETARIO_BLOCO], [PROPRIETARIO_AP], [email],[STATUS],[TELEFONE],[PROPRIETARIO_IMOVEL]) VALUES (@NOME_PROPRIETARIO1, @PROPRIETARIO_BLOCO, @PROPRIETARIO_AP, @email, @STATUS,[TELEFONE],[PROPRIETARIO_IMOVEL])"
        SelectCommand="SELECT [NOME_PROPRIETARIO1],[PROPRIETARIO_BLOCO], [PROPRIETARIO_AP],[PASSWORD] ,[email],[STATUS],[TELEFONE],[proprietario_imovel] FROM [PROPRIETARIO] WHERE [STATUS] = 1  ORDER BY [DataCadastro] DESC"
        UpdateCommand="UPDATE [PROPRIETARIO] SET [NOME_PROPRIETARIO1] = @NOME_PROPRIETARIO1, [email] = @email, [TELEFONE] = @telefone, [PROPRIETARIO_IMOVEL]=@PROPRIETARIO_IMOVEL, [STATUS] = @STATUS WHERE [PROPRIETARIO_BLOCO] = @PROPRIETARIO_BLOCO AND [PROPRIETARIO_AP] = @PROPRIETARIO_AP">
        <DeleteParameters>
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="NOME_PROPRIETARIO1" Type="String" />
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="STATUS" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="NOME_PROPRIETARIO1" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="STATUS" Type="Boolean" />
            <asp:Parameter Name="PROPRIETARIO_BLOCO" Type="Int32" />
            <asp:Parameter Name="PROPRIETARIO_AP" Type="Int32" />
             <asp:Parameter Name="TELEFONE" Type="String" />
            <asp:Parameter Name="PROPRIETARIO_IMOVEL" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    
    
        <div id="dvPesquisa" runat="server">
            <fieldset class="loginDisplayLegend">
            <legend class="accordionContent">Pesquisando por:
                <asp:Label ID="lblPesquisa" runat="server"></asp:Label></legend>
         <center>   <asp:GridView ID="grdPesquisa" CssClass="gridl" EmptyDataText="Não existe dados para sua pesquisa!!" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Morador1">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("proprietario1") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("proprietario1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Morador2">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("proprietario2") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("proprietario2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bloco">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ap.bloco") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ap.bloco") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apartamento">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ap.apartamento") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ap.apartamento") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="E-mail">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Senha">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("senha") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("senha") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BackColor="#0066FF" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnFechar" runat="server" Text="Fechar" CssClass="btGeral" 
                onclick="btnFechar_Click" /> </center></fieldset>
        </div>
   
</asp:Content>
