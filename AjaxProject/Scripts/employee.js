//Load Data in Table when documents is ready
$(document).ready(function () {
    
    loadData();
});
//Load Data function
function loadData() {
    
    var param = [{ "name": "Code", "Value": '12' }];
    var proc = 'SelectEmployee';
    Selector1(param, proc).then(function (result) {
       
        $res = JSON.parse(result);
        
        var html = '';
        if ($res.length != []) {
            for ($i = 0; $i < $res.length; $i++) {
                html += '<tr>';
                html += '<td>' + $res[$i].EmployeeID + '</td>';
                html += '<td>' + $res[$i].Name + '</td>';
                html += '<td>' + $res[$i].Age + '</td>';
                html += '<td>' + $res[$i].state + '</td>';
                html += '<td>' + $res[$i].Country + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + $res[$i].EmployeeID + ')">Edit</a> | <a href="#" onclick="Delele(' + $res[$i].EmployeeID + ')">Delete</a></td>';
                html += '</tr>';
            }
            $('.tbody').html(html);
        }
        else {
           
        }
    });
    //$.ajax({
  
    //    url: "/Home/List",
    //    type: "GET",
    //    contentType: "application/json;charset=utf-8",
    //    dataType: "json",
    //    success: function (result) {
    //        var html = '';
    //        $.each(result, function (key, item) {
    //            html += '<tr>';
    //            html += '<td>' + item.EmployeeID + '</td>';
    //            html += '<td>' + item.Name + '</td>';
    //            html += '<td>' + item.Age + '</td>';
    //            html += '<td>' + item.State + '</td>';
    //            html += '<td>' + item.Country + '</td>';
    //            html += '<td><a href="#" onclick="return getbyID(' + item.EmployeeID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.EmployeeID + ')">Delete</a></td>';
    //            html += '</tr>';
    //        });
    //        $('.tbody').html(html);
    //    },
    //    error: function (errormessage) {
    //        alert(errormessage.responseText);
    //    }
    //});
}
//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    Action([
  { "name": "Name", "Value": $("#Name").val() }, { "name": "Age", "Value": $("#Age").val() },
  { "name": "State", "Value": $('#State').val() },{ "name": "Country", "Value": $("#Country").val() }], "[InsertUpdateEmployee]");
    //var empObj = {
    //    EmployeeID: $('#EmployeeID').val(),
    //    Name: $('#Name').val(),
    //    Age: $('#Age').val(),
    //    State: $('#State').val(),
    //    Country: $('#Country').val()
    //};
    //$.ajax({
    //    url: "/Home/Add",
    //    data: JSON.stringify(empObj),
    //    type: "POST",
    //    contentType: "application/json;charset=utf-8",
    //    dataType: "json",
    //    success: function (result) {
    //        alert(result);
    //        loadData();
    //        $('#myModal').modal('hide');
    //    },
    //    error: function (errormessage) {
    //        alert(errormessage.responseText);
    //    }
    //});
}
function Result(text)
{
    console.log(text);
    if (text == "Added")
    {
        toastr["success"]("Record Added Succesfully", 'Success Message!');
    }
    else if (text == "Updated") {
        toastr["success"]("Record Updated Succesfully", 'Success Message!');
    }
    else {
        toastr["error"](text, 'Error Message');
    }
}
//Function for getting the Data Based upon Employee ID
function getbyID(EmpID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
   
    $.ajax({
        url: "/Home/getbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#EmployeeID').val(result.EmployeeID);
            $('#Name').val(result.Name);
            $('#Age').val(result.Age);
            $('#State').val(result.State);
            $('#Country').val(result.Country);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//function for updating employee's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        EmployeeID: $('#EmployeeID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        State: $('#State').val(),
        Country: $('#Country').val(),
    };
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result);
            loadData();
            $('#myModal').modal('hide');
            $('#EmployeeID').val("");
            $('#Name').val("");
            $('#Age').val("");
            $('#State').val("");
            $('#Country').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting employee's record
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//Function for clearing the textboxes
function clearTextBox() {
    $('#EmployeeID').val("");
    $('#Name').val("");
    $('#Age').val("");
    $('#State').val("");
    $('#Country').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Age').val().trim() == "") {
        $('#Age').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Age').css('border-color', 'lightgrey');
    }
    if ($('#State').val().trim() == "") {
        $('#State').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#State').css('border-color', 'lightgrey');
    }
    if ($('#Country').val().trim() == "") {
        $('#Country').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Country').css('border-color', 'lightgrey');
    }
    return isValid;
}