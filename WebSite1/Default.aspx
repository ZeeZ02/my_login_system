<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        WELCOME TO MY LOGIN HACKER! DO YOUR WORSE!</h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="PassWord"></asp:Label>
&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;
    </p>
    <p>
        <asp:ListBox ID="ListBox1" runat="server" Height="196px" Width="905px">
        </asp:ListBox>
</p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Create User"></asp:Label>
</p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="UserName"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxCreateUser" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="PassWord"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxCreatePass" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="Creater User" />
</p>
    <p>
        <asp:ListBox ID="ListBox2" runat="server" Width="707px"></asp:ListBox>
</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </asp:Content>
