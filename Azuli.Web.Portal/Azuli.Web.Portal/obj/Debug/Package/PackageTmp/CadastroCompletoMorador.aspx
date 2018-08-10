<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CadastroCompletoMorador.aspx.cs"
    Inherits="Azuli.Web.Portal.CadastroCompletoMorador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .ObjectLarge
        {
            margin-left: 2px;
            font-weight: 700;
            font-size: small;
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
        .style7
        {
            width: 244px;
        }
        .style8
        {
            width: 718px;
            text-align: left;
        }
        .style11
        {
            width: 95px;
            height: 27px;
        }
        .style12
        {
            height: 27px;
        }
        .style13
        {
            height: 27px;
            width: 718px;
        }
        .style14
        {
            width: 95px;
        }
        .style15
        {
            height: 27px;
            width: 121px;
        }
        .style21
        {
            width: 121px;
        }
        .style23
        {
            font-weight: bold;
        }
        .style33
        {
            width: 1023px;
            height: 57px;
        }
        .style36
        {
            width: 1023px;
        }
        .style39
        {
            width: 412px;
            height: 57px;
        }
        .style40
        {
            width: 412px;
        }
        .style41
        {
            width: 219px;
            height: 57px;
        }
        .style42
        {
            width: 219px;
        }
        .field
        {
            font-weight: 700;
            font-size: medium;
        }
    </style>t
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script type="text/jscript">
        jQuery(function ($) {
            $("#txtCPF").mask("999.999.999-99");
            $("#txtTelefone").mask("(099) 9999-9999");
            $("#txtCelular").mask("(099) 99999-9999");
            $("#TextBoxPlaca1").mask("aaa - 9999");
            $("#TextBoxPlaca2").mask("aaa - 9999");
            $("#TextBoxPlaca3").mask("aaa - 9999");
            $("#txtDatanascimento1").mask('99/99/9999');
            $("#txtDatanascimento2").mask('99/99/9999');
            $("#txtDatanascimento3").mask('99/99/9999');
            $("#txtDatanascimento4").mask('99/99/9999');
            $("#txtDatanascimento5").mask('99/99/9999');
            $("#txtDatanascimento6").mask('99/99/9999');
            $("#txtCep").mask('99999-999');
            
        });
    </script>
<style type="text/css">
    .accountInfo
    {}
</style>
    <style type="text/css">
        .field
        {}
        .style3
        {
            width: 650px;
        }
        .style23
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="dvCadastro" runat="server">
        <fieldset class="loginDisplayLegend">
            <legend class="accordionHeaderSelected">Cadastro de condôminos</legend>
            <center>
                <br />
                <label class="accordion-group">
                    <b class="accordionHeaderSelected">Cadastro da unidade</b></label>
                <br />
                <table class="GridView">
                    <tr>
                        <td class="">
                            <asp:Label ID="lblBloco" runat="server" CssClass="Field" 
                                Style="font-weight: bold; font-size: medium">Bloco:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpBloco" runat="server" Height="25px" Width="154px" Style="font-size: medium; font-weight: 700;"
                                CssClass="AlternatingRowStyle">
                                <asp:ListItem>Escolha o bloco ...</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                            <%--    <asp:TextBox ID="txtBloco" runat="server" Height="19px" Width="87px"></asp:TextBox>--%>
                            <asp:RequiredFieldValidator ID="rfvName0" runat="server" ControlToValidate="drpBloco" ValidationGroup="InputValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblAP" runat="server" CssClass="Field" 
                                Style="font-weight: bold; font-size: medium; text-align: left;">Apartamento:</asp:Label>
                            &nbsp;
                            <asp:DropDownList ID="ddLApartamentos" runat="server" 
                                Style="font-weight: 700; font-size: medium;" CssClass="AlternatingRowStyle">
                                <asp:ListItem Selected="True">Escolha o AP ..</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblAP0" runat="server" CssClass="Field" 
                                Style="font-weight: bold; font-size: medium; text-align: left;">Qtds de Garagem:</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlQuantidadeGarage" runat="server" 
                                Style="font-weight: 700; font-size: medium;" 
                                CssClass="AlternatingRowStyle" Height="37px" Width="62px">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
                <label class="accordion-group">
                    <b class="accordionHeaderSelected">Identificação do Proprietário</b></label>
                <br />
                <table class="GridView" dir="ltr">
                    <tr class="form">
                        <td class="style11" align="left">
                            <asp:Label ID="lblcond01" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                        </td>
                        <td class="style13" align="left">
                            <asp:TextBox ID="txtCond01" runat="server" CssClass="Field" MaxLength="100" Width="452px" Style="font-weight: bold"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCond01"
                                ValidationGroup="InputValidationGroup" Style="color: #FF3300; font-weight: 700">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="style15">
                            <asp:RadioButtonList ID="lstRadioButtonTipo" runat="server" 
                                Style="font-size: small; font-weight: 700;" Width="155px"
                                CssClass="page" AutoPostBack="True" 
                                OnSelectedIndexChanged="lstRadioButton_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="Proprietário">Proprietário</asp:ListItem>
                                <asp:ListItem Value="Locatário">Locatário</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="style12">
                            <asp:RadioButtonList ID="lsrEstadoCivil" runat="server" Style="font-size: medium; font-weight: 700;"
                                Width="124px" CssClass="page" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="Casado">Casado(ª)</asp:ListItem>
                                <asp:ListItem Value="Solteiro">Solteiro(ª)</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="form" align="left">
                            <asp:Label ID="lblTelefone0" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">CPF:</asp:Label>
                        </td>
                        <td class="form" align="left">
                            &nbsp;
                            <asp:TextBox ID="txtCPF" runat="server" ClientIDMode="Static" MaxLength="200" AutoPostBack="True" Width="144px"
                                OnTextChanged="txtCPF_TextChanged" CssClass="style23"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCond01"
                                ValidationGroup="InputValidationGroup" Style="color: #FF3300; font-weight: 700">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;<asp:Label ID="lblMessageCPF" runat="server" Style="font-weight: 700"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTelefone1" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">RG:</asp:Label>
                            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtRg" runat="server" MaxLength="200" AutoPostBack="True"
                                Width="169px" CssClass="style23"></asp:TextBox>
                        </td>
                        <td align="left" class="form" colspan="2">
                            <asp:Label ID="lblEmail" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">E-mail</asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="200" AutoPostBack="True" 
                                Width="132px" CssClass="style23" ontextchanged="txtEmail_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                ValidationGroup="InputValidationGroup" Style="font-weight: 700; color: #FF3300">*</asp:RequiredFieldValidator>
                            <asp:Label ID="lblValidaEmail" runat="server" 
                                style="font-weight: 700; color: #FF3300"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="form" align="left">
                            <asp:Label ID="lblTelefone4" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">CEP:</asp:Label>
                        </td>
                        <td class="form" align="left">
                            &nbsp;
                            <asp:TextBox ID="txtCep" runat="server" ClientIDMode="Static" MaxLength="200" 
                                AutoPostBack="True" Width="144px" 
                                CssClass="style23" ontextchanged="txtCep_TextChanged"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblTelefone3" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">Bairro:</asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txtBairro" runat="server" MaxLength="200" AutoPostBack="True" Width="221px" Style="margin-top: 0px"
                                CssClass="style23"></asp:TextBox>
                        </td>
                        <td class="form" align="left">
                            <asp:Label ID="lblTelefone" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">Fone Residencial:</asp:Label>
                        </td>
                        <td class="form">
                            <asp:TextBox ID="txtTelefone" runat="server" ClientIDMode="Static" MaxLength="200" AutoPostBack="True"
                                Width="121px" CssClass="style23"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCond01"
                                ValidationGroup="InputValidationGroup" Style="color: #FF3300; font-weight: 700">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="form" align="left">
                            <asp:Label ID="lblTelefone2" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">Endereço:</asp:Label>
                        </td>
                        <td class="form" align="left">
                            &nbsp;
                            <asp:TextBox ID="txtEndereco" runat="server" MaxLength="200" AutoPostBack="True" Width="448px" 
                                CssClass="style23"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCond01"
                                ValidationGroup="InputValidationGroup" Style="color: #FF3300; font-weight: 700">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="form" align="left">
                            <asp:Label ID="lblTelefone5" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">Celular:</asp:Label>
                        </td>
                        <td class="form">
                            <asp:TextBox ID="txtCelular" runat="server" ClientIDMode="Static" MaxLength="200" AutoPostBack="True"
                                Width="144px" CssClass="style23"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="form" align="left">
                            <asp:Label ID="lblTelefone6" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                font-size: 9pt">Cidade:</asp:Label>
                        </td>
                        <td class="form" align="left">
                            &nbsp;
                            <asp:TextBox ID="txtCidade" runat="server" MaxLength="200" AutoPostBack="True" Width="448px" 
                                CssClass="style23"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCond01"
                                ValidationGroup="InputValidationGroup" Style="color: #FF3300; font-weight: 700">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style21">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <div id="dvDesenv" runat="server">
                    <br />
                    <label class="accordion-group">
                        <b class="accordionHeaderSelected">Demais moradores</b></label>
                    <br />
                    <table class="GridView">
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtboxDepedente1" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Parentesco</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpdownParentesco1" runat="server" CssClass="ObjectLarge" Height="21px" Width="273px">
                                    <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                    <asp:ListItem>Esposa</asp:ListItem>
                                    <asp:ListItem>Pai</asp:ListItem>
                                    <asp:ListItem>Mãe</asp:ListItem>
                                    <asp:ListItem>Filho(ª)</asp:ListItem>
                                    <asp:ListItem>Tio(ª)</asp:ListItem>
                                    <asp:ListItem>Sogro(ª)</asp:ListItem>
                                    <asp:ListItem>Enteado(ª)</asp:ListItem>
                                    <asp:ListItem>Primo(ª)</asp:ListItem>
                                    <asp:ListItem>Outros</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label13" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Nascimento</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDatanascimento1" ClientIDMode="Static" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtNomeDepedente2"  runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label18" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Parentesco</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpdownParentesco2" runat="server" CssClass="ObjectLarge" Height="21px" Width="273px">
                                    <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                    <asp:ListItem>Esposa</asp:ListItem>
                                    <asp:ListItem>Pai</asp:ListItem>
                                    <asp:ListItem>Mãe</asp:ListItem>
                                    <asp:ListItem>Filho(ª)</asp:ListItem>
                                    <asp:ListItem>Tio(ª)</asp:ListItem>
                                    <asp:ListItem>Sogro(ª)</asp:ListItem>
                                    <asp:ListItem>Enteado(ª)</asp:ListItem>
                                    <asp:ListItem>Primo(ª)</asp:ListItem>
                                    <asp:ListItem>Outross</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label19" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Nascimento</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDatanascimento2" runat="server" ClientIDMode="Static" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtNomeDepedente3" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label21" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Parentesco</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpdownParentesco3" runat="server" CssClass="ObjectLarge" Height="21px" Width="273px">
                                    <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                    <asp:ListItem>Esposa</asp:ListItem>
                                    <asp:ListItem>Pai</asp:ListItem>
                                    <asp:ListItem>Mãe</asp:ListItem>
                                    <asp:ListItem>Filho(ª)</asp:ListItem>
                                    <asp:ListItem>Tio(ª)</asp:ListItem>
                                    <asp:ListItem>Sogro(ª)</asp:ListItem>
                                    <asp:ListItem>Enteado(ª)</asp:ListItem>
                                    <asp:ListItem>Primo(ª)</asp:ListItem>
                                    <asp:ListItem>Outross</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label22" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Nascimento</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDatanascimento3" runat="server" ClientIDMode="Static"  CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtNomeDepedente4" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Parentesco</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpdownParentesco4" runat="server" CssClass="ObjectLarge" Height="21px" Width="273px">
                                    <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                    <asp:ListItem>Esposa</asp:ListItem>
                                    <asp:ListItem>Pai</asp:ListItem>
                                    <asp:ListItem>Mãe</asp:ListItem>
                                    <asp:ListItem>Filho(ª)</asp:ListItem>
                                    <asp:ListItem>Tio(ª)</asp:ListItem>
                                    <asp:ListItem>Sogro(ª)</asp:ListItem>
                                    <asp:ListItem>Enteado(ª)</asp:ListItem>
                                    <asp:ListItem>Primo(ª)</asp:ListItem>
                                    <asp:ListItem>Outros</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label25" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Nascimento</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDatanascimento4" ClientIDMode="Static" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtNomeDepedente5" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label27" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Parentesco</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpdownParentesco5" runat="server" CssClass="ObjectLarge" Height="21px" Width="273px">
                                    <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                    <asp:ListItem>Esposa</asp:ListItem>
                                    <asp:ListItem>Pai</asp:ListItem>
                                    <asp:ListItem>Mãe</asp:ListItem>
                                    <asp:ListItem>Filho(ª)</asp:ListItem>
                                    <asp:ListItem>Tio(ª)</asp:ListItem>
                                    <asp:ListItem>Sogro(ª)</asp:ListItem>
                                    <asp:ListItem>Enteado(ª)</asp:ListItem>
                                    <asp:ListItem>Primo(ª)</asp:ListItem>
                                    <asp:ListItem>Outros</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label28" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Nascimento</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDatanascimento5" ClientIDMode="Static" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtNomeDepedente6" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Parentesco</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpdownParentesco6" runat="server" CssClass="ObjectLarge" Height="21px" Width="273px">
                                    <asp:ListItem Selected="True" Value="-1">Escolhe o parentesco...</asp:ListItem>
                                    <asp:ListItem>Esposa</asp:ListItem>
                                    <asp:ListItem>Pai</asp:ListItem>
                                    <asp:ListItem>Mãe</asp:ListItem>
                                    <asp:ListItem>Filho(ª)</asp:ListItem>
                                    <asp:ListItem>Tio(ª)</asp:ListItem>
                                    <asp:ListItem>Sogro(ª)</asp:ListItem>
                                    <asp:ListItem>Enteado(ª)</asp:ListItem>
                                    <asp:ListItem>Primo(ª)</asp:ListItem>
                                    <asp:ListItem>Outros</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label16" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Nascimento</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDatanascimento6" ClientIDMode="Static" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <label class="accordion-group">
                        <b class="accordionHeaderSelected">Empregados</b></label>
                    <br />
                    <table class="GridView">
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                            </td>
                            <td style="text-align: left" class="style4">
                                <asp:TextBox ID="txtBoxNomeEmpregado" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label10" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">RG</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtBoxRG" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px" Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                            </td>
                            <td style="text-align: left" class="style4">
                                <asp:TextBox ID="txtBoxNomeEmpregado1" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label30" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">RG</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBoxRG1" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px" Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <label class="accordion-group">
                        <b class="accordionHeaderSelected">Veículos (Carros e Motos)</b></label>
                    <br />
                    <table class="GridView">
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Marca/Modelo</asp:Label>
                                :
                            </td>
                            <td style="text-align: left" class="style4">
                                <asp:TextBox ID="TextBoxMarcaModelo1" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label29" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">COR:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBoxCor1" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px" Width="161px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label33" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Placa:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBoxPlaca1" runat="server" ClientIDMode="Static" CssClass="ObjectLarge" MaxLength="100" Height="21px" Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label34" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Marca/Modelo</asp:Label>
                                :
                            </td>
                            <td style="text-align: left" class="style4">
                                <asp:TextBox ID="TextBoxMarcaModelo2" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label35" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">COR:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBoxCor2" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px" Width="161px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label36" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Placa:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBoxPlaca2" runat="server"  ClientIDMode="Static" CssClass="ObjectLarge" MaxLength="100" Height="21px" Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label37" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Marca/Modelo</asp:Label>
                                :
                            </td>
                            <td style="text-align: left" class="style4">
                                <asp:TextBox ID="TextBoxMarcaModelo3" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label38" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">COR:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBoxCor3" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px" Width="161px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label39" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Placa:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBoxPlaca3"  ClientIDMode="Static" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px" Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <label class="accordion-group">
                        <b class="accordionHeaderSelected">Em caso de emergência</b></label>
                    <br />
                    <table class="GridView">
                        <tr>
                            <td>
                                <asp:Label ID="Label31" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome:</asp:Label>
                                :
                            </td>
                            <td style="text-align: left" class="style4">
                                <asp:TextBox ID="TextBoxNomeEmergencia" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="234px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label32" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Parentesco:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtBoxParentescoEmergencia" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="161px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:Label ID="Label40" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Contato:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textboxContatoEmergencia" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="161px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <label class="accordion-group">
                        <b class="accordionHeaderSelected">Animais</b></label>
                    <br />
                    <table class="GridView">
                        <tr>
                            <td>
                                <asp:Label ID="Label44" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Quantidade(s)</asp:Label>
                                :
                            </td>
                            <td style="text-align: left" class="style6">
                                <asp:DropDownList ID="DropDownListQuantdAnimal" runat="server" Height="16px" Style="font-weight: 700"
                                    Width="43px">
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
                                <asp:Label ID="Label45" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                    font-size: 9pt">Espécie:</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBoxEspecieAnimal" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                    Width="580px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <label class="accordion-group">
                        <b class="accordionHeaderSelected">Observações</b></label>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="GridView">
                                <tr>
                                    <td align="left" class="style39">
                                        <asp:Label ID="Label1" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Aluga vaga de garagem?</asp:Label>
                                    </td>
                                    <td class="style41" style="text-align: left">
                                        <asp:CheckBox ID="chkAluga" runat="server" AutoPostBack="True" CssClass="style23" OnCheckedChanged="chkAluga_CheckedChanged"
                                            Text="Sim" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="ChkNaoAluga" runat="server" AutoPostBack="True" CssClass="style23"
                                            OnCheckedChanged="ChkNaoAluga_CheckedChanged" Text="Não" />
                                    </td>
                                    <td style="text-align: left" class="style3" id="tdAlugaGaragem" runat="server">
                                        <asp:Label ID="lblBloco0" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Bloco:</asp:Label>
                                        <asp:DropDownList ID="drpBlocoAluga" runat="server" AutoPostBack="True" CssClass="AlternatingRowStyle"
                                            Height="19px" OnSelectedIndexChanged="drpBlocoAluga_SelectedIndexChanged" Style="font-size: small;
                                            font-weight: 700;" Width="143px">
                                            <asp:ListItem Value="-1">Escolha o bloco ...</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblAP1" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt; text-align: left;">Apto:</asp:Label>
                                        <asp:DropDownList ID="ddLApartamentosAluga" runat="server" AutoPostBack="True" CssClass="AlternatingRowStyle"
                                            OnSelectedIndexChanged="ddLApartamentosAluga_SelectedIndexChanged" 
                                            Style="font-weight: 700; font-size: small;">
                                            <asp:ListItem Value="-1">Escolha o AP ...</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblBloco1" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nº da Garagem:</asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtNumeroGaragem" runat="server" CssClass="field" 
                                            Height="21px" MaxLength="100" Width="79px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style40">
                                        <asp:Label ID="Label3" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Possui bicicletas?</asp:Label>
                                    </td>
                                    <td align="left" class="style42">
                                        <asp:Label ID="Label46" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Quantas: </asp:Label>
                                        &nbsp;&nbsp;<asp:DropDownList ID="drlQtdBicicleta" runat="server" Height="16px" Style="font-weight: 700"
                                            Width="43px">
                                            <asp:ListItem Selected="True">0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem Value="5"></asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                    </td>
                                    <td style="text-align: left" class="style3">
                                        <asp:CheckBox ID="chkBikePequena" Text="Pequenas" runat="server" CssClass="style23" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="CheckBikeMedia" Text="Médias" runat="server" CssClass="style23" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="chkGrande" Text="Grandes" runat="server" CssClass="style23" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <div id="dvImobiliaria" runat="server">
                        <label class="accordion-group">
                            <b class="accordionHeaderSelected">Informações da Imobiliária (Caso não seja proprietário)</b></label>
                        <br />
                        <table class="GridView">
                            <tr>
                                <td class="style5">
                                    <asp:Label ID="Label41" runat="server" CssClass="Field" Style="font-weight: bold; font-size: 9pt">Nome da Empresa</asp:Label>
                                    :
                                </td>
                                <td style="text-align: left" class="style4">
                                    <asp:TextBox ID="TextBoxEmpresaImobiliaria" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                        Width="234px"></asp:TextBox>
                                </td>
                                <td style="margin-left: 40px">
                                    <asp:Label ID="Label42" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                        font-size: 9pt">Telefone:</asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="TextBoxTelefoneImobiliaria" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                        Width="161px"></asp:TextBox>
                                </td>
                                <td style="margin-left: 40px">
                                    <asp:Label ID="Label43" runat="server" CssClass="Field" meta:resourcekey="lblActivity" Style="font-weight: bold;
                                        font-size: 9pt">Contato:</asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="TextBoxContatoImobiliaria" runat="server" CssClass="ObjectLarge" MaxLength="100" Height="21px"
                                        Width="161px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                </div>
                <asp:Button ID="btnFinalizaCadastro" runat="server" CssClass="modalHeader" 
                    Height="42px" onclick="btnFinalizaCadastro_Click" Text="Finalizar Cadastro" 
                    Width="158px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFinalizaCadastro0" runat="server" CssClass="modalHeader" 
                    Height="42px" onclick="btnFinalizaCadastro_Click" Text="Limpar cadastro" 
                    Width="158px" />
                &nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                <br />
            </center>
        </fieldset>
    </div>
</asp:Content>
