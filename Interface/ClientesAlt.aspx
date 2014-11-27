<%@ Page Title="" Language="C#" MasterPageFile="~/Sivet.Master" AutoEventWireup="true" CodeBehind="ClientesAlt.aspx.cs" Inherits="Interface.ClientesAlt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="margin-left: -15px;">
        <img src="Content/imagem/ClientesTitulo.png" /></p>
    <asp:Literal ID="ltrTitulo" runat="server"></asp:Literal><br />
    <div id="divForm" runat="server">
    <label>Nome</label><asp:TextBox ID="nome" runat="server"></asp:TextBox><br />
    <label>CPF</label><asp:TextBox ID="cpf" runat="server"></asp:TextBox>
    <label>RG</label><asp:TextBox ID="rg" runat="server"></asp:TextBox><br />
    <label>Data de Nascimento</label><asp:TextBox ID="dataNascimento" runat="server"></asp:TextBox><br />
    <label>Celular</label><asp:TextBox ID="Celular" runat="server"></asp:TextBox>
    <label>WhastApp</label><asp:TextBox ID="whatsapp" runat="server"></asp:TextBox><br />
    </div>
    <div class="grid_12 divBotao">
                <asp:HiddenField ID="hdfID" runat="server" />
               <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="Voltar" onclick="window.location = 'Clientes.aspx';" />
                
            </div>
       
    
    <asp:Panel ID="pnlExcluir" runat="server" Visible="false">
        <div class="grid_12">
            Tem certeza que deseja excluir o cliente 
            <asp:Literal ID="ltrExcluir" runat="server"></asp:Literal>
            ?
        </div>
        <div class="clear"></div>

        <div class="grid_12 divBotao">
                <asp:Button ID="btnSim" runat="server" Text="Sim" OnClick="btnSim_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="Não" onclick="window.location = 'Listar.aspx';" />
            </div>
    </asp:Panel>
</asp:Content>
