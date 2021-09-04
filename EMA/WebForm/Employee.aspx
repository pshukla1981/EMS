<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EMA.WebForm.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="padding: 50px;">
        <div>
            <div class="row">
                <div class="col-md-1">
                    Enter  Id
                </div>
                <div class="col-md-2">
                    <input id="txtsearch" type="text" class="form-control" placeholder="Enter employee id" />
                </div>
                <div class="col-md-1">
                    <input id="btnsearch" type="button" value="Search" class="btn btn-primary" />
                </div>
            </div>
            <div id="divajax" class="row">
                <div class="col-lg-8">

                    <fieldset>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtcode">Code</label>
                                    <input id="txtcode" type="text" class="form-control" placeholder="Employee Code" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtname">Name</label>
                                    <input id="txtname" type="text" class="form-control" placeholder="Name" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtemail">Email</label>
                                    <input type="text" id="txtemail" class="form-control" placeholder="Email" />
                                </div>

                            </div>

                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtdepartment">Department</label>
                                    <input type="text" id="txtdepartment" class="form-control" placeholder="Your Department" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtdepartment">Mobile</label>
                                    <input type="text" id="txtmobile" class="form-control" placeholder="Your Mobile" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtjoining">Joining Date</label>
                                    <input type="text" id="txtjoining" class="form-control" placeholder="Joining Date" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtdesignation">Designation</label>
                                    <input type="text" id="txtdesignation" class="form-control" placeholder="Designation" />
                                </div>
                            </div>
                        </div>

                        <div id="divresult" class="alert alert-success">
                        </div>

                    </fieldset>



                </div>

            </div>
        </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-3.3.1.min.js"></script>
<link href="../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../Content/Site.css" rel="stylesheet" />

<script type="text/javascript">
    $(document).ready(function () {
        $("#btnsearch").click(function () {
            var txtsearch = $("#txtsearch").val();
            if (txtsearch != "") {
                $.ajax({
                    url: "/WebForm/Employee.aspx/GetEmployyeById",
                    method: "POST",
                    contentType: "application/json",
                   // data: '{Id:' + txtsearch + '}', 
                    data: JSON.stringify({Id: txtsearch}),
                     dataType: "json",
                    success: function (response) {
                        $("#txtcode").val(response.d.EmpCode);
                        $("#txtname").val(response.d.EmpName);
                        $("#txtemail").val(response.d.EmpEmail);
                        $("#txtdepartment").val(response.d.DepartmentName);
                        $("#txtmobile").val(response.d.MobileNumber);
                        $("#txtjoining").val(response.d.JoiningDate);
                        $("#txtdesignation").val(response.d.DesignationName);
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
            }
            else {
                alert('Please enter empid to search');
            }


        });

    });
</script>
