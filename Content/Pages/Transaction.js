$(document).ready(function () {
    GetTransList();
    
    
})

var SaveTrans = function () {
    var transId = $("#hdnTransID").val();
    var itemID = $("#txtItemID").val();
    var transType = $("#txtTransType").val();
    var transQty = $("#txtTransQty").val();
    var transDate = $("#txtTransDate").val();
    var model = { TransID: transId, ItemID: itemID, TransType: transType, TransQty: transQty, TransDate: transDate };
    $.ajax({
        url: "/Transaction/SaveTrans",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Saved Successfully");
           
            GetTransList();
            ClearData();
        }
    })
};

var GetTransList = function () {
    $.ajax({
        url: "/Transaction/GetTransList",
        method: "post",
        contentType: "appliaction/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Trans tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.TransID +
                    "</td><td>" + elementValue.ItemID +
                    "</td><td>" + elementValue.TransType +
                    "</td><td>" + elementValue.TransQty +
                    "</td><td>" + elementValue.TransDate + "</td><td><input type='submit' value='Edit' class='btn btn-success' Onclick='EditTrans(" + elementValue.TransID + ")'/><input type='submit' value='Delete' class='btn btn-danger' Onclick='DeleteTrans(" + elementValue.TransID + ")'/></tr></td>";
            })
            $("#Trans tbody").append(html);
        }
    });
}

var EditTrans= function (TransID) {
    debugger;
    var model = { TransID: TransID };
    $.ajax({
        url: "/Transaction/EditTrans",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnTransID").val(response.model.TransID);
            $("#txtItemID").val(response.model.ItemID);
            $("#txtTransType").val(response.model.TransType);
            $("#txtTransQty").val(response.model.TransQty);
            $("#txtTransDate").val(response.model.TransDate);

          
        }
    });
}

var DeleteTrans = function (TransID) {
    var model = { TransID: TransID };
    $.ajax({
        url: "/Transaction/DeleteTrans",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully");
            GetTransList();

            
        }

    });
}

var ClearData = function () {
    $("#hdnTransID").val("");
    $("#txtItemID").val("");
    $("#txtTransType").val("");
    $("#txtTransQty").val("");
    $("#txtTransDate").val("");
}
