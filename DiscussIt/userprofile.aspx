<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="DiscussIt.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-12">
            <div class="card mt-5">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                            <img width="80px" src="assets/images/generaluser.png" />
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <center>
                           <h2><asp:Label ID="lbluser" runat="server" Text=""></asp:Label></h2>
                        </center>
                     </div>
                  </div>
                    <div class="row">
                     <div class="col">
                        <center>
                           <h6><asp:Label ID="lbluseremail" runat="server" Text=""></asp:Label></h6>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Username</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox runat="server" class="form-control" ID="tbName" ViewStateMode="Inherit"></asp:TextBox>
                           </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username is required." ControlToValidate="tbName" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>
                      <div class="col-md-6">
                        <label>Old Password</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" TextMode="Password" ID="oldpass" runat="server"></asp:TextBox>
                           </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Old Password is required." ControlToValidate="oldpass" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>
                   </div>
                   <div class="row">
                      <div class="col-md-6">
                        <label>New Password</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" TextMode="Password" ID="newpass" runat="server"></asp:TextBox>
                           </div>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="New Password is required." ControlToValidate="newpass" ForeColor="Red"></asp:RequiredFieldValidator><br>
                           <asp:RegularExpressionValidator runat="server" ErrorMessage="New Password minimum length is 6." ControlToValidate="newpass" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,}$" ForeColor="Red" Font-Size="12"></asp:RegularExpressionValidator>
                        </div>
                     </div>
                      <div class="col-md-6">
                        <label>Confirm New Password</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" TextMode="Password" ID="cnewpass" runat="server"></asp:TextBox>
                           </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm New Password is required." ControlToValidate="cnewpass" ForeColor="Red"></asp:RequiredFieldValidator><br>
                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Confirm New Password minimum length is 6." ControlToValidate="cnewpass" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,}$" ForeColor="Red" Font-Size="12"></asp:RegularExpressionValidator>
                        </div>
                     </div>
                  </div>
                   <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="New Password  and Confirm New Password not match." ControlToCompare="newpass" ControlToValidate="cnewpass" ForeColor="Red"></asp:CompareValidator>
                  <div class="row mt-2">
                      <center>
                         <div class="col-4">
                             <asp:Button ID="updateprofile" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="updateprofile_Click" />
                         </div>
                      </center>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
        
      </div>
   </div>
</asp:Content>
