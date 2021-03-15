<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD_Operations._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center">CRUD in ASP.net</h1>
        <h3 class="text-center">Login Here</h3>
    </div>

    <div class="container flex">
        <div class="row">
        <div class="col-md-3">

        </div>
        <div class="col-md-6">
            <div class="form-row align-middle justify-content-center ">
                <div class="col-12">
                  <label for="inputEmail4">Username: </label>
                  <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox><br />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Your Username" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-12">
                  <label for="inputPassword4">Password: </label><br />
                    <asp:TextBox ID="TextBox2" type="password" class="form-control" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please Enter Your Password" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-12">
                  <div class="d-grid gap-2 col-12 mx-auto">
                        <asp:Button ID="Button1" runat="server" Text="Log In" class="btn btn-primary" OnClick="Button1_Click" />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                </div>
              </div>
        </div>
        <div class="col-md-3">

        </div>
    </div>
    </div>

</asp:Content>
