<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="DiscussIt.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div  style="margin: 5% 20% 5% 20%;">
     <div>
            <asp:Label runat="server" Text="Label" class="form-label white-text">Username</asp:Label>
            <asp:TextBox runat="server" class="form-control" ID="tbName" placeholder="Enter Username" ViewStateMode="Inherit"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Username is required." ControlToValidate="tbName" ForeColor="Red" Font-Size="12"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label runat="server" Text="Label" class="form-label white-text">Email</asp:Label>
            <asp:TextBox runat="server" class="form-control" TextMode="Email" ID="tbEmail" placeholder="Enter Email ID"></asp:TextBox>
            <div id="emailHelp" class="form-text disabled-text">We'll never share your email with anyone else.</div>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Email is required." ControlToValidate="tbEmail" Font-Size="12" ForeColor="Red"></asp:RequiredFieldValidator></div>
        
        <div>
            <asp:Label runat="server" Text="Label" class="form-label white-text">Password</asp:Label>
            <asp:TextBox runat="server" class="form-control" TextMode="Password" ID="tbPassword" placeholder="Enter Password"></asp:TextBox>
            <asp:RegularExpressionValidator runat="server" ErrorMessage="Password minimum length is 6." ControlToValidate="tbPassword" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,}$" ForeColor="Red" Font-Size="12"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Password is required." ControlToValidate="tbPassword" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label runat="server" Text="Label" class="form-label white-text">Confirm Password</asp:Label>
            <asp:TextBox runat="server" class="form-control" TextMode="Password" ID="tbConfirm" placeholder="Enter Confirm Password"></asp:TextBox>
            <asp:RegularExpressionValidator runat="server" ErrorMessage="Password minimum length is 6." ControlToValidate="tbConfirm" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,}$" ForeColor="Red" Font-Size="12"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Password is required." ControlToValidate="tbConfirm" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" ErrorMessage="Confirm Password and Password not match." ControlToCompare="tbPassword" ControlToValidate="tbConfirm" ForeColor="Red"></asp:CompareValidator>
        </div>
        
        <div class="mb-3" style="display:flex; justify-content:center">
            <asp:Button ID="RegisBtn" runat="server" OnClick="UserSignupBtn_Click" Text="Sign Up" class="btn btn-lg btn-block btn-outline-secondary"/>
        </div>
        <div style="display:flex; justify-content:center">
            <a href="userlogin.aspx" runat="server" class="btn btn-lg btn-block btn-outline-primary">Login</a>
        </div>

        <div>
            <asp:Label ID="lblError" Text="" runat="server" style="color: red;"/>
        </div>
 </div>

</asp:Content>
