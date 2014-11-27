<%@ Page Title="" Language="C#" MasterPageFile="~/Sivet.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Interface.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p style="margin-left: -15px;">
        <img src="Content/imagem/ClientesTitulo.png" /></p>
    <p style="margin-left: 675px;">
        <asp:Button ID="Incluir" runat="server" Text="Incluir Cliente" CssClass="botao" />
    </p>
    <br />
    <div>
        <asp:GridView ID="grdCliente" runat="server" AutoGenerateColumns="False" CssClass="tabela">
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="RG" HeaderText="Identidade" />
                <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="TelefoneCelular" HeaderText="Celular" />
                <asp:BoundField DataField="Whatsapp" HeaderText="WhatsApp" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbEditar" runat="server" OnCommand="lkbEditar_Command" CommandArgument='<%#Eval("IdCliente") %>'>Editar</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lkbExcluir" runat="server">Excluir</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
