<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CRUD_Operations.CRUDHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col form-group">
                <%--<h1>Your Session: <asp:Label ID="Label1" runat="server"></asp:Label> is active.</h1>--%>
                
                <hr />
                <table style="width: 100%; height: 93px;">
                    <thead>
                        <tr>
                            <th>S. No.</th>
                            <th>Name</th>
                            <th>Email</th>
                            <th>Contact No.</th>
                            <th>Salary</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    
                    <tbody id="lbltbl" runat="server">
                    </tbody>
                </table>                
            </div>
        </div>
    </div>
<!-- Modal -->
    <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="EditModalLongTitle">Edit Record</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true" style="margin-top: -162%;float: right;">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                    <div class="container-fluid">
                    <div class="form-row">
                        <div class="col-sm-3">
                            <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label><input class="form-control" id="empname" placeholder="Name" type="text" runat="server" autoclear="true"/>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="Label6" runat="server" Text="Email: "></asp:Label><input class="form-control" id="empmail" placeholder="Email" type="text" runat="server" autoclear="true"/>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="Label7" runat="server" Text="Contact No: "></asp:Label><input class="form-control" id="empcontact" placeholder="Contact" type="text" runat="server" autoclear="true"/>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="Label8" runat="server" Text="Salary: "></asp:Label><input class="form-control" id="empsalary" placeholder="Salary" type="text" runat="server" autoclear="true"/>
                        </div>
                    </div>
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <%--<button type="button" class="btn btn-primary" onclick="update()" data-dismiss="modal">Save changes</button>--%>
                  <input class="btn btn-primary" id="edit_btn" type="button" value="Save changes" data-dismiss="modal" onclick="update()" />
              </div>
            </div>
          </div>
        </div>
<!--Modal for Delete-->
<div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLongTitle">Delete Record</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <p>Confirm to delete the record.</p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="deleteRec()">Delete</button>
            </div>
        </div>
    </div>
</div>
<!--Alert Modal-->
<!-- Modal -->
<div class="modal fade" id="Alert Modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
        <div class="modal-header">
        <h5 class="modal-title" id="AlertModalTitle">Alert!!!</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
        </div>
        <div class="modal-body">
            
        </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Ok</button>
        </div>
    </div>
    </div>
</div>
<!-- End of Alert Modal-->
    <input type="hidden" value="" id="empid" />

    <!--Modal for new record-->
        <div class="modal fade" id="AddModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="AddModalLongTitle">Add New Record</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                    <div class="container-fluid">
                    <div class="form-row">
                        <div class="col-sm-3">
                            <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label><input class="form-control" id="ename" type="text" runat="server" autoclear="true"/>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label><input class="form-control" id="email" type="text" runat="server" autoclear="true"/>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="Label4" runat="server" Text="Contact No: "></asp:Label><input class="form-control" id="econtact" type="text" runat="server" autoclear="true"/>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="Label5" runat="server" Text="Salary: "></asp:Label><input class="form-control" id="esalary" type="text" runat="server" autoclear="true"/>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-sm-12" style="margin: 1% 40%;">
                           
                        </div>
                    </div>
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <input class="btn btn-primary" ID="btn_add" type="button" value="Add Record" data-dismiss="modal" onclick="AddRec()" />
              </div>
            </div>
          </div>
        </div>
        <!--End Modal for new record-->
<script>
    //Add New Record
    function AddRec() {
        var mdbutton = document.getElementById("btn_add");
        var ename = document.getElementById("MainContent_ename").value;
        var eemail = document.getElementById("MainContent_email").value;
        var econtact = document.getElementById("MainContent_econtact").value;
        var esalary = document.getElementById("MainContent_esalary").value;
        if (ename == "" || ename.length < 3) {
            document.getElementById("MainContent_ename").style.borderColor = "red";
            mdbutton.setAttribute("data-dismiss", "none");
            return (false);
        } else {
            document.getElementById("MainContent_ename").style.borderColor = "green";
        }
        if (econtact.length != 10) {
            document.getElementById("MainContent_econtact").style.borderColor = "red";
            mdbutton.setAttribute("data-dismiss", "none");
            return (false);
        } else {
            document.getElementById("MainContent_econtact").style.borderColor = "green";
        }
        if (Number.isNaN(esalary) || esalary.length < 3) {
            document.getElementById("MainContent_esalary").style.borderColor = "red";
            mdbutton.setAttribute("data-dismiss", "none");
            return (false);
        } else {
            document.getElementById("MainContent_esalary").style.borderColor = "green";
        }
        if (!/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(eemail)) {
            document.getElementById("MainContent_email").style.borderColor = "red";
            mdbutton.setAttribute("data-dismiss", "none");
            return (false);
        } else {
            document.getElementById("MainContent_email").style.borderColor = "green";
        }
            
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.open("POST", "/Add.aspx?name=" + ename + "&email=" + eemail + "&contact=" + econtact + "&salary=" + esalary, false);

        //$.ajax({
        //    url: "Add.aspx",
        //    cache: false,
        //    data: { name:ename,email:eemail,contact:econtact,salary:esalary},
        //    success: function (response) {
        //        console.log(response)
        //    }
        //});
        xmlhttp.send();
        mdbutton.setAttribute("data-dismiss", "modal");
        document.getElementById("MainContent_ename").value = "";
        document.getElementById("MainContent_email").value = "";
        document.getElementById("MainContent_econtact").value = "";
        document.getElementById("MainContent_esalary").value = "";
        refresh();
    }
    //Identifier for the record updater
    function updateEmp(sid) {
        fill(sid);
        document.getElementById("empid").value = sid;
    }
    //Fill Data on Edit Record Modal
    function fill(id) {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.open("POST", "DataFill.aspx?id=" + id, false);
        xmlhttp.send(null);
        var responseString = xmlhttp.responseText.toString();
        var indexofsplitter = responseString.indexOf("|", 0);
        var initialIndex = 0;
        var values = [];
        for (i = 0; i < 4; i++) {
            values[i] = responseString.substring(initialIndex, indexofsplitter);
            initialIndex = indexofsplitter + 1;
            indexofsplitter = responseString.indexOf("|", indexofsplitter + 1);
        }
        document.getElementById("MainContent_empname").value = values[0];
        document.getElementById("MainContent_empmail").value = values[1];
        document.getElementById("MainContent_empcontact").value = values[2];
        document.getElementById("MainContent_empsalary").value = values[3];
        xmlhttp.abort;
    }
    //For-Updating any Record
    function update() {
        var mdbutton = document.getElementById("edit_btn");
        var name = document.getElementById("MainContent_empname");
        var email = document.getElementById("MainContent_empmail");
        var contact = document.getElementById("MainContent_empcontact");
        var salary = document.getElementById("MainContent_empsalary");
        var id = document.getElementById("empid").value;

        if (name.value === "" || name.value.length < 3) {
            document.getElementById("MainContent_empname").style.borderColor = "red";
            mdbutton.setAttribute("data-dismiss", "none");
            return (false);
        } else {
            document.getElementById("MainContent_empname").style.borderColor = "green";
        }
        if (!/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email.value)) {
            document.getElementById("MainContent_empmail").style.borderColor = "red";
            mdbutton.setAttribute("data-dismiss", "none");
            return (false);
        } else {
            document.getElementById("MainContent_empmail").style.borderColor = "green";
        }
        if (contact.value.length != 10) {
            document.getElementById("MainContent_empcontact").style.borderColor = "red";
            mdbutton.setAttribute("data-dismiss", "none");
            return (false);
        } else {
            document.getElementById("MainContent_empcontact").style.borderColor = "green";
        }
        if (Number.isNaN(salary.value) || salary.value.length < 3) {
            document.getElementById("MainContent_empsalary").style.borderColor = "red";
            mdbutton.setAttribute("data-dismiss", "none");
            return (false);
        } else {
            document.getElementById("MainContent_empsalary").style.borderColor = "green";
        }
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.open("POST", "Edit.aspx?name=" + name.value + "&email=" + email.value + "&contact=" + contact.value + "&salary=" + salary.value+"&id="+id, false);
        xmlhttp.send(null);
        mdbutton.setAttribute("data-dismiss", "modal");
        document.getElementById("MainContent_empname").value = "";
        document.getElementById("MainContent_empmail").value = "";
        document.getElementById("MainContent_empcontact").value = "";
        document.getElementById("MainContent_empsalary").value = "";
        document.getElementById("empid").value = "";
        refresh();
    }
    //Identifier For the Delete Button
    function del(sid) {
        document.getElementById("empid").value = sid;
    }
    //For Deleting a record
    function deleteRec() {
        var id = document.getElementById("empid").value;
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.open("POST", "Delete.aspx?id=" + id, false);
        xmlhttp.send(null);
        document.getElementById("empid").value = "";
        refresh();
        xmlhttp.abort;
    }
    //Refreshes the Employee Details Table
    function refresh() {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.open("POST", "refresh.aspx", false);
        xmlhttp.send(null);
        document.getElementById("MainContent_lbltbl").innerHTML = xmlhttp.responseText;
        //xmlhttp.abort;
    }
</script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
</asp:content>