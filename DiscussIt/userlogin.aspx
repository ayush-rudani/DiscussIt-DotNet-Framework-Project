<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="DiscussIt.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin: 5% 20% 5% 20%;">
        <div class="mb-3">
            <asp:Label runat="server" Text="Label" class="form-label white-text">Email</asp:Label>
            <asp:TextBox runat="server" class="form-control" TextMode="Email" ID="tbEmail"></asp:TextBox>
            <div id="emailHelp" class="form-text disabled-text">We'll never share your email with anyone else.</div>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Email is required." ControlToValidate="tbEmail" Font-Size="12" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <asp:Label runat="server" Text="Label" class="form-label white-text">Password</asp:Label>
            <asp:TextBox runat="server" class="form-control" TextMode="Password" ID="tbPassword"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Password is required." ControlToValidate="tbPassword" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ErrorMessage="Password minimum length is 6." ControlToValidate="tbPassword" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,}$" ForeColor="Red" Font-Size="12"></asp:RegularExpressionValidator>
        </div>
        <div class="mb-2" style="display:flex; justify-content:center">
            <asp:Button ID="Button1" runat="server" OnClick="UserLoginBtn_Click" Text="Login" class="btn btn-lg btn-block btn-outline-primary"/>
        </div>
         <div class="mb-2" style="display:flex; justify-content:center">
            <a href="usersignup.aspx" runat="server" class="btn btn-lg btn-block btn-outline-secondary">Sign up</a>
        </div>

        
        <div class="mb-3">
            <asp:Label ID="lblError" Text="" runat="server" style="color: red;"/>
        </div>
    </div>



</asp:Content>
