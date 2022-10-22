<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="replies.aspx.cs" Inherits="DiscussIt.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card" style="border: solid 1px; margin: 1% 1%">
            <div class="card-header header-bg ">
                <%--Posted By :
            <asp:Label ID="NameLbl" runat="server" Text="Label"></asp:Label>
            <p style="margin: 0">
                <asp:Label ID="DateLbl" runat="server" Text="Label"></asp:Label>
            </p>--%>
                <div class="d-flex justify-content-between">
                    <div>
                        Posted By:<b>
                            <asp:Label ID="NameLbl" runat="server" Text='Label'></asp:Label></b>
                    </div>
                    <div>
                        <span style="margin: 0; width: 90%">
                            <asp:Label ID="DateLbl" runat="server" Text="Label"></asp:Label>
                        </span>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <h6 class="card-subtitle mb-2 text-muted">Category
                </h6>
                <h5 class="card-title">
                    <asp:Label ID="TitleLbl" runat="server" Text="Label"></asp:Label>
                </h5>
                <p class="card-text">
                    <asp:Label ID="ContentLbl" runat="server" Text="Label"></asp:Label>
                </p>
            </div>
        </div>
        <asp:Repeater ID="ReplyRepeater" runat="server">
            <ItemTemplate>
                <div class="card reply-container reply-area mx-2 mt-2">
                    <div class="card-body">
                        <div class="card-subtitle mb-2 text-muted">
                            <div class="d-flex justify-content-between">
                                <div>
                                    Replied By :
                        <asp:Label Text='<%# Eval("UserName") %>' runat="server" />
                                </div>
                                <div>
                                    <p style="margin: 0">
                                        <asp:Label Text='<%# Eval("PostDate") %>' runat="server" />
                                    </p>
                                </div>
                                <% if (Session["role"].ToString() == "admin")
                                    {
                        %>
                                <div class="d-flex justify-content-end" style="font-size: x-large">
                                    <asp:LinkButton ID="DeleteLink" OnClientClick="return confirm('Are you sure you want to delete this post?');" OnClick="DeleteLink_Click" CommandArgument='<%#Eval("Id")%>' Style="text-decoration: none; color: rgb(133, 2, 2)" runat="server" CausesValidation="false">
                                    <i class='bx bxs-trash'></i>
                                    </asp:LinkButton>
                                </div>
                                <% 
                                    }
                        %>
                            </div>
                        </div>
                        <p class="card-text" style="font-size: larger">
                            <asp:Label Text='<%# Eval("ReplyContent") %>' runat="server" />
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div style="margin: 1% 1%" errormessage="Reply is required.">
            <div class="mb-2 mt-1">
                <asp:Label runat="server" Text="Label" class="form-label">Your Reply</asp:Label>
                <asp:TextBox class="form-control" ID="tbContent" runat="server" TextMode="MultiLine" Rows="4" Style="width: 100%; resize: none"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Reply is required." ControlToValidate="tbContent" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
            <div style="display: flex; justify-content: flex-start; margin-right: 1%;">
                <asp:Button ID="PostReplyBtn" runat="server" Text="Reply" CssClass="btn btn-outline-primary pb-1" class="btn" OnClick="PostReplyBtn_Click" />
            </div>
        </div>
    </div>
</asp:Content>
