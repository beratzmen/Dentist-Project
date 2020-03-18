$(document).ready(function () {
    $("#txtSearchArticle").on('keyup', function () {
        SearchArticle(1);
    });
});

function GetByCategoryId(pageNumber, categoryId) {
    $.get("/Blog/GetByCategoryId/", { "pageNumber": pageNumber, "categoryId": categoryId }, function (response) {
        $('#divArticleListPartial').html(response);
    });
}

function SearchArticle(pageNumber) {
    $.get("/Blog/Search/", { "pageNumber": pageNumber, "keyword": $("#txtSearchArticle").val() }, function (response) {
        $('#divArticleListPartial').html(response);
    });
}

function commentScrollToBottom(commentId, fullName) {
    $("#hdnReplyId").val(commentId);
    $("#divReplyStatus").css("display", "block");
    document.getElementById("lblReplyFullName").innerHTML = fullName;
    MoveScroll("divComment", true);
}

function clearReplyValue() {
    $("#hdnReplyId").val(null);
    document.getElementById("lblReplyFullName").innerHTML = null;
    $("#divReplyStatus").css("display", "none");
}

function MoveScroll(elementId, isBottom) {
    var elmnt = document.getElementById(elementId);
    if (isBottom) {
        elmnt.scrollIntoView(false); // Bottom
    }
    else {
        elmnt.scrollIntoView(true); // Top
    }
}