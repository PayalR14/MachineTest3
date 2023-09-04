$(document).ready(function () {
    GetItemList();
  
    
});

var SaveItem = function () {
   
    var itemID = $("#hdnItemID").val();
    var itemDescr = $("#txtItemDescr").val();
    var balQty = $("#txtBalQty").val();
    var createdOn = $("#txtCreatedOn").val();
    var model = { ItemID: itemID, ItemDescr: itemDescr, BalQty: balQty, CreatedOn: createdOn };
    $.ajax({
        url: "/ItemMaster/SaveItemMaster",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Saved Successfully");
            GetItemList();
            ClearData();
           
           
           
        }
    })
};

var GetItemList = function () {
    $.ajax({
        url: "/ItemMaster/ListItem",
        method: "post",
        contentType: "appliaction/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblItem tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ItemID +
                    "</td><td>" + elementValue.ItemDescr +
                    "</td><td>" + elementValue.BalQty +
                    "</td><td>" + elementValue.CreatedOn + "</td><td><input type='submit' value='Edit' class='btn btn-success' Onclick='EditItem(" + elementValue.ItemID + ")'/><input type='submit' value='Delete' class='btn btn-danger' Onclick='DeleteItem(" + elementValue.ItemID +")'/></tr></td>";
            })
            $("#tblItem tbody").append(html);
        }
    });
}

var EditItem = function (ItemID) {
    debugger;
    var model = { ItemID: ItemID };
    $.ajax({
        url: "/ItemMaster/EditItem",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnItemID").val(response.model.ItemID);
            $("#txtItemDescr").val(response.model.ItemDescr);
            $("#txtBalQty").val(response.model.BalQty);
            $("#txtCreatedOn").val(response.model.CreatedOn);
            GetItemList();

           
        }
    });
}

var DeleteItem = function (ItemID) {
    var model = { ItemID: ItemID };
    $.ajax({
        url: "/ItemMaster/DeleteItem",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully");
            GetItemList();
            
        }

    });
}

var ClearData = function () {
    $("#hdnItemID").val("");
    $("#txtItemDescr").val("");
    $("#txtBalQty").val("");
    $("#txtCreatedOn").val("");

}

