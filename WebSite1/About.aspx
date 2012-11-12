<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
<p>
        <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </p>
    <p>
        Put content here.
    </p>
</asp:Content>
