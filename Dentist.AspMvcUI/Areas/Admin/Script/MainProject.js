$(document).ready(function () {
    $("#txtSearch").on('keyup', function () {
        $.get("/Admin/Category/Search/", { "dataType": $('#myCategoryTab .active')[0].getAttribute("dataType"), "keyword": $("#txtSearch").val() }, function (response) {
            PopulateCategoryList(response);
        });
    });

    $(".homePageSwitch").on('click', function () {
        FindHomePageSwitchValue();
    });
});

function FindHomePageSwitchValue() {
    var currentValue = "";
    $.each($('.homePageSwitch:input:checked'), function () {
        if (StringIsNullOrEmptyOrWhiteSpace(currentValue)) {
            currentValue = $(this).attr("enumNumber");
        }
        else {
            currentValue += "," + $(this).attr("enumNumber");
        }
    });
    $("#hdnHomeSwitch").val(currentValue);
}

function getCategoryList(dataType) {
    $.ajax({
        url: '/Admin/Category/List/' + dataType,
        type: 'POST',
        data: dataType,
        success: function (response) {
            PopulateCategoryList(response);
        },
        error: function myfunction() {
            PopulateCategoryList(null);
        }
    });
}

function PopulateCategoryList(data) {
    var row = ""
    if (data == null || data.length <= 0) {
        row += '<tr><td>Gösterilecek kategori bulunamadı.</td></tr>';
    }
    else {
        $.each(data, function (index, item) {
            row += '<tr>';
            row += '<td>' + (StringIsNullOrEmptyOrWhiteSpace(item.Title) ? '' : item.Title) + '</td>';
            row += '<td>' + (StringIsNullOrEmptyOrWhiteSpace(item.Description) ? '' : item.Description) + '</td>';
            row += '<td><a href="/Admin/Category/Update/' + item.Id + '" class="btn btn-round btn-warning">Güncelle</a></td>';
            row += '<td><a href="/Admin/Category/Delete/' + item.Id + '" class="btn btn-round btn-danger">Sil</a></td>';
            //row += '<td><a onclick="DeleteCategory(' + item.Id + ',' + item.Title + ')"  class="btn btn-round btn-danger" data-toggle="modal" data-target="#exampleModalCenter"> Sil</a></td>';
            row += '</tr>';
        });
    }
    $("#tblCategory").html(row);
}

function StringIsNullOrEmptyOrWhiteSpace(text) {
    if (!text || text === " " || text === null) {
        return true;
    }
    else {
        return false;
    }
}