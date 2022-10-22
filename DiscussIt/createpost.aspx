<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="createpost.aspx.cs" Inherits="DiscussIt.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div style="margin: 3% 20% 5% 20%;">
        <h3 class="Title mb-4" style="text-align: center; text-transform: uppercase; margin-bottom: 3%;">Ask a question</h3>
        <div class="mb-3">
            <asp:Label runat="server" Text="Label" class="form-label">Title</asp:Label>
            <small id="emailHelp" class="form-text text-muted">Be specific and imagine you’re asking a question to another person</small>
            <asp:TextBox runat="server" class="form-control" ID="tbTitle"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Title is Required." ControlToValidate="tbTitle" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <asp:Label runat="server" Text="Label" class="form-label">Body</asp:Label>
            <small id="emailHelp" class="form-text text-muted">Include all the information someone would need to answer your question</small>
            <asp:TextBox class="form-control" ID="tbContent" runat="server" TextMode="MultiLine" Rows="10" style="width:100%; resize: none"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Content is required." ControlToValidate="tbContent" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="display:flex; justify-content:center">
            <asp:Button ID="ButtonPost" runat="server" OnClick="ButtonPost_Click" Text="Post" CssClass="btn btn-outline-primary pb-1" class="btn" style="width:100px"/>
        </div>
        
        <div class="mb-3">
            <asp:Label ID="lblError" Text="" runat="server" style="color: red;"/>
        </div>
    </div>

</asp:Content>
