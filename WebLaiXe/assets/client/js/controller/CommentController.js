//import { swal } from "../../../../Areas/Admin/Resources/js/sweetalert";

$("#btncomment").off('click').on('click', function () {
    $.ajax({
        url: "/home/PublishComment",
        dataType: 'json',
        type: 'POST',
        data: $('#commentform').serialize(),
    }).done(function (res) {
        if (res.Success) {
            window.location.reload();
        }
        else {
            swal("Error!", Response.Message, "error");
        }
    }).fail(function () {
        swal("Error!", "Error comment . Please try again", "error");
    });
});
            
       