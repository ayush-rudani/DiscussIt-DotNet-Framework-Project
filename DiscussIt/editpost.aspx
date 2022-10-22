<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="editpost.aspx.cs" Inherits="DiscussIt.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 3% 20% 5% 20%;">
        <h3 class="Title mb-4" style="text-align: center; text-transform: uppercase; margin-bottom: 3%;">Edit Question</h3>
        <div class="mb-3">
            <asp:Label runat="server" Text="Label" class="form-label">Title</asp:Label>
            <asp:TextBox runat="server" class="form-control" ID="tbTitle"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label runat="server" Text="Label" class="form-label">Content</asp:Label>
            <asp:TextBox class="form-control" ID="tbContent" runat="server" TextMode="MultiLine" Rows="10" style="width:100%; resize: none"></asp:TextBox>
        </div>
        <div style="display:flex; justify-content:center" class="mt-5">
            <asp:Button ID="BtnUpdatePost" runat="server" OnClick="BtnUpdatePost_Click" Text="Update" CssClass="btn btn-outline-primary pb-1" class="btn"/>
        </div>
        
        <div class="mb-3">
            <asp:Label ID="lblError" Text="" runat="server" style="color: red;"/>
        </div>
    </div>
</asp:Content>
