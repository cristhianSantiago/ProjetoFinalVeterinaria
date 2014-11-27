<%@ Page Title="" Language="C#" MasterPageFile="~/Sivet.Master" AutoEventWireup="true" CodeBehind="Teste.aspx.cs" Inherits="Interface.Teste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="grdCliente" runat="server" AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Double" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="RG" HeaderText="Identidade" />
                <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="Endereco" HeaderText="Endereço" />
                <asp:BoundField DataField="TelefoneResidencial" HeaderText="Residencial" />
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
