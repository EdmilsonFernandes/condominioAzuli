<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAsman.aspx.cs" Inherits="Azuli.Web.Portal.LoginAsman" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <link id="bs-css" href="css/bootstrap-cerulean.css" rel="stylesheet">
        <style type="text/css">
            body
            {
                padding-bottom: 40px;
            }
            .sidebar-nav
            {
                padding: 9px 0;
            }
        </style>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="row-fluid">
                    <div class="span12 center login-header">
                        &nbsp;</div>
                    <!--/span-->
                </div>
                <!--/row-->
                <br />
                <br />
                <div class="row-fluid">
                    <div class="well span5 center login-box">
                        <div class="page-header">
                            <strong>Entre com seu: Condominio, Bloco, Apartamento e Senha
                        </strong>
                        </div>
                        <form class="form-horizontal" action="index.html" method="post">
                        <fieldset>
                            <div class="input-prepend" title="Condominio" data-rel="tooltip">
                                <span class="add-on"><i class="icon-bookmark"></i></span>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="0" Selected="True">Escolha seu condomínio ...</asp:ListItem>
                                    <asp:ListItem Value="1">Spazio Campo Azuli</asp:ListItem>
                                    <asp:ListItem Value="2">Residencial Ilha Bela</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="input-prepend" title="Apartamento" data-rel="tooltip">
                                <span class="add-on" style="font-weight: bold">Bloco: /span>
                                <asp:TextBox ID="txtApto" class="input-small" runat="server"></asp:TextBox>
                                <span class="add-on" style="font-weight: bold">Apto: </span>
                                <asp:TextBox ID="txtBloco" class="input-small" runat="server"></asp:TextBox>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="input-prepend" title="Digite sua Senha" data-rel="tooltip">
                                <span class="add-on">Senha</span><asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="clearfix">
                            </div>
                         
                            <div class="clearfix">
                            </div>
                            <p class="center span5">
                                <asp:Button ID="btnEntrar" class="btn btn-primary" Text="Entrar" runat="server" />
                            </p>
                        </fieldset>
                        </form>
                    </div>
                    <!--/span-->
                </div>
                <!--/row-->
            </div>
            <!--/fluid-row-->
        </div>
       
    </div>
    </form>
</body>
</html>
