$(document).ready(function () {

    $("#form1").submit(function () {

        Login();
        return false;
    });
});
function Login() {
    var param = [{ "name": "Username", "Value": $("#txtUsername").val() },
{ "name": "password", "Value": $("#txtPassword").val() }];
    var proc = 'LoginEmployee';
    FnLogin(param, proc).then(function (result) {


        if (result == "Incorrect" || result == "Error") {
            toastr["error"]("Incorrect Username/password", 'Login Failed!');
           
           
        }
        else {
            toastr["success"]("Valid User", 'Login Success!');
           
            window.location.href = result;

        }
    });

    //var empLogin = {
    //    username: $("#txtUsername").val(),
    //    password: $("#txtPassword").val()
    //};
    //$.ajax({
    //    url: "Home/SingleAction",
    //    type: "POST",
    //  //  contentType: "application/json;charset=utf-8",
    //    dataType: "json",
    //    data: JSON.stringify(empLogin),
    //    contentType: "application/json; charset=utf-8",
    //    success: successFn,
    //    error: errorFunction,
    //});

}
function Result(text)
{
    //if (text == "Record Already Exists" || text == "Incorrect" || text == "Error") {
    //    ErrMessage(text);
    //}
    //else {
    //    SuccMessage(text);
    //}
}


/*
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        EmployeeID: $('#EmployeeID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        State: $('#State').val(),
        Country: $('#Country').val()
    };*/
function errorFunction(result) {

    toastr["error"]("Error,Something went wrong! ", 'Server Error!');

}
function successFn(result) {
   
    $res = JSON.parse(result);
    
    if ($res.length != []) {
       
        window.location.href = "Home/Index";
    }
    else {
        toastr["error"]("Incorrect Username/password", 'Login Failed!');

    }
   
}
