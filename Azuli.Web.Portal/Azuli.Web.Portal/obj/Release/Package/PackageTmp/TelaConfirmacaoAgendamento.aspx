<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TelaConfirmacaoAgendamento.aspx.cs" Inherits="Azuli.Web.Portal.TelaConfirmacaoAgendamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /> <br />
    <div id="DivConfirma" runat="server" class="botao">
        <fieldset class="login">
            <legend class="accordionContent">Reserva Efetuada com Sucesso!</legend>
            <br />
            <table id="tbConfirma" style="width: 899px; height: 380px;" runat="server">
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="lblBocoTitle" runat="server" Font-Bold="True" Text="Bloco:"></asp:Label>
                        &nbsp;<asp:Label ID="lblBlocoConfirma" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblApTitle" runat="server" Font-Bold="True" Text="Ap:"></asp:Label>
                        <asp:Label ID="lblApConfirma" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblDataConfirma" runat="server" Font-Bold="True" Text="Data: "></asp:Label>
                        &nbsp;<asp:Label ID="lblConfirmaData" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
        
        <td>
            <hr />
            <p style="color: #3A5FCD; font-weight: bold;">
                &nbsp;</p>
            <p style="color: #3A5FCD; font-weight: bold;" class="style14">
                Favor atentar às informações abaixo:
            </p>
            <table style="text-align: justify;">
                <tr>
                    <td class="style17">
                        <ul style="color: red">
                            <li style="font-size: medium">Para que sua reserva seja liberada efetivamente, favor
                                acertar os valores da reserva, o pagamento terá que ser efetuado no mesmo dia, caso
                                não ocorra sua reserva será cancelada automáticamente!</li>
                        </ul>
                        <ul style="color: #3A5FCD">
                            <li>É permitido cancelar o agendamento somente apenas com 15 dias de antencedencias
                            </li>
                        </ul>
                        <ul style="color: #3A5FCD">
                            <li>Proíbido colar ou colocar qualquer tipo de material na parede como: cola, durex,
                                prego e entre mais..</li>
                        </ul>
                        <ul style="color: #3A5FCD">
                            <li>Durante a reserva é proibido a utilização da Piscina</li>
                        </ul>
                        <ul style="color: #3A5FCD">
                            <li>Após as 22:00 é permitido ficar nas áreas, porém não pode haver barulhos que incomodem
                                os moradores</li>
                        </ul>
                        <ul style="color: #3A5FCD">
                            <li>Morador será responsável por qualquer ato do seus visitantes, que quebrem as normas
                                do condominio</li>
                        </ul>
                        <p>
                            &nbsp;</p>
                        <p>
                            &nbsp;</p>
                        <p>
                            <asp:Button ID="btnOKConfirma" runat="server" CssClass="botao" OnClick="btnOKConfirma_Click"
                                Text="Ok" Width="63px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="27px" ImageUrl="~/images/print.jpg"
                                OnClick="ImageButton1_Click1" />
                        </p>
                    </td>
                </tr>
            </table>
        
      
      
            </table> </fieldset> </div> 

</asp:Content>
