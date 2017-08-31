// Write your JavaScript code.
function GetProducts(page, pageSize) {
    $.ajax({
        method: 'GET',
        url: 'products',
        data: {
            page: page,
            pageSize: pageSize
        },
        dataType: 'json',
        beforeSend: function () {
            $('#tbl tbody tr').remove();
            $('#Pager li').remove();
        },
        success: function (data) {
            if (data.products.length > 0) {
                $('#Table').css('display', 'block');
                $.each(data.products, function (i, item) {
                    var rows = "<tr ><td class='bg-primary' onclick='GetDetails(event, \"" + item.id + "\")'>" + item.name + "</td>" +
                        "<td>" + item.description + "</td>" +
                        "<td>" + item.price + "</td>" +
                        "<td class='bg-warning' onclick='Edit(\"" + item.id + "\")'><span class='glyphicon glyphicon-pencil'></span>" + "</td>" +
                        "</tr>";
                    $('#tbl tbody').append(rows);

                });
                if (data.page > 1) {
                    $('#Pager').append('<li><a href="#" onclick="GetProducts(' + '1' + ',10)"> ' + '1' + '</a></li>');
                }
                if (data.page > 2) {
                    $('#Pager').append('<li><a href="#" onclick="GetProducts(' + (data.page - 1) + ',10)"> ' + (data.page - 1) + '</a></li>');
                }
                $('#Pager').append('<li><a href="#" onclick="GetProducts(' + data.page + ',10)"> ' + data.page + '</a></li>');
                if (data.page + 1 <= data.pages) {
                    $('#Pager').append('<li><a href="#" onclick="GetProducts(' + (data.page+1) + ',10)"> ' + (data.page+1)  + '</a></li>');
                }
                if (data.pages > 2) {
                    $('#Pager').append('<li><a href="#" onclick="GetProducts(' + data.pages + ',10)"> ' + data.pages + '</a></li>');
                }
            }
            else {
                $('#Table').append('<div class="row"><p>There are no products.</p></div>');
            }
        }
    });
}

function GetDetails(event, id) {
    $.ajax({
        url: 'product/' + id,
        type: 'GET',
        dataType: 'json',
        beforeSend: function () {
            $('#tblDtl tbody tr').remove();
        },
        success: function (data) {
            if (data.history.length > 0) {
                $('#tableDtl').css('display', 'block');
                $.each(data.history, function (i, item) {
                    var rows = "<tr class='table tab-content'><td>" + item.name + "</td>" +
                        "<td>" + item.description + "</td>" +
                        "<td>" + item.price + "</td>" +
                        "<td>" + item.createdTime + "</td>" +
                        "</tr>";
                    $('#tblDtl tbody').append(rows);
                });
            }
        }
    });
    event.stopPropagation();
}

function AddProduct(btnClicked) {
    var $form = $(btnClicked).parents('form');
    var name = $form.find('#nm').val();
    var description = $form.find('#dscptn').val();
    var price = $form.find('#prc').val();
    console.log(JSON.stringify({ name, description, price }));
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        type: 'POST',
        dataType: 'application/json',
        url: 'product',
        data: JSON.stringify({ name, description, price }),
        complete: function () {
            GetProducts(1, 10);
        }
    });
}

function Edit(id)
{
    $('#editTbl').css('display', 'block');
    $('#updatePrdct #hidden').children().remove();
    $('#updatePrdct #hidden').append("<input type='hidden' id='productId' name='Id' value='\"" + id + "\"'>");
    $('#updatePrdct #hidden').append("<label>Edit for product Id: " + id + " </label>");
}

function UpdateProduct(btnClicked)
{
    var $form = $(btnClicked).parents('form');
    var name = $form.find('#nm').val();
    var description = $form.find('#dscptn').val();
    var price = $form.find('#prc').val();
    var id = $form.find('#productId').val();
    id = id.replace("\"", '').replace("\"",'');
    console.log(JSON.stringify({ id, name, description, price }));
    $.ajax({
        type: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        dataType: 'application/json',
        url: 'product',
        data: JSON.stringify({ id, name, description, price }),
        complete: function () {
            $('#editTbl').css('display', 'none');
            GetDetails(this, id);
            GetProducts(1, 10);
        }
    });
}