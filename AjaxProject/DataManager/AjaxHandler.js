var  ret;
function Selector(param, proc) {
    var url = "AccessData/MultiList";
   
    return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            ret = data;
        },
        async:true,
        error: errorFn
    });
    
}
function Selector1(param, proc) {
    var url = "SingleList";
    return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            ret = data;

            
        },
        async: true,
        error: errorFn
    });

}
function FnLogin(param, proc) {
    var url = "AccessData/LoginAction";
    return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            ret = data;


        },
        async: true,
        error: errorFn
    });

}

function Action(param,proc) {
    var url = "SingleAction";
   return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            Result(data);
            //SuccMessage(data.d);
           
        },
        error: errorFn
       
   });
}
function ActionCheck(param, proc) {
    var url = "SingleAction";
    return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
           
            Result(data);

        },
        error: errorFn

    });
}

function ActionDelete(param, proc,ele)
{
    var url = "AccessData/SingleAction";
    return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            Result(data.d); 
            if (data.d == "Operation Successfully Performed") {
                FnRowDelete(ele);

            }
        },
        error: errorFn

    });
}

function ActionNewRecord(param, proc,Status) {
    var url = "AccessData/SingleAction";
    return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            Result(data);
            //SuccMessage(data.d);
           
        },
        error: errorFn

    });
}

function Action1(param,col,arry,proc,FnName) {
    var url = "AccessData/MultiAction";
    return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "colms": col,
            "Details":arry,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
           
            
           
            //else {
            //    ErrMessage(data.d);
            //}
           

        },
        error: errorFn
    });
}
function ActionUpdateZones(param, col, arry, proc) {
   
    var url = "DataManager/Data.aspx/DataProcessor1";
    return $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        data: JSON.stringify({
            "data": param,
            "colms": col,
            "Details": arry,
            "action": proc
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data == "Zone Updated")
            {
                FnZonesList();
            }

          



        },
        error: errorFn
    });
}
function errorFn(err, status, xhr) {
    console.log(status.toUpperCase() + "! " + xhr);
    //ErrMessage(status.toUpperCase() + "! " + xhr);
    toastr["error"]("Error, Server is down OR internet connection problem", 'Server Error!');
    //ErrMessage("Error, Server is down OR internet connection problem");
}

//function Once(fn, context) {
//    var result;
//    return function () {
//        if (fn) {
//            result = fn.apply(context || this, arguments);
//            fn = null;
//        }
//        return result;
//    };
//}

//var toast = Once(function (cl1, cl2, text) {
//    $toast = "<div class='container " + cl1 + "'>" +
//         "<button type='button' class='close cl-toast' style='margin-top:5px'>&times;</button>" +
//        "<h4 class='" + cl2 + "'>" + text + "</h4>" +
//    "</div>";

//    return $toast;
//});
