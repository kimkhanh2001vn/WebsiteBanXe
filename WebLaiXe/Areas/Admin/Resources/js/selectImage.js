function selectImage(action, id) {

    var finder = new CKFinder();
    finder.selectActionFunction = function (fileUrl) {
        $.ajax({
            method: "GET",
            url: action,
            data: { picture: fileUrl }
        }).done(function (path) {
            if (path !== '') {
                alert("Lỗi cập nhật hình ảnh:" + path);
            }
            else {
                $("#" + id).attr("src", fileUrl);
            }
        });
    };
    finder.popup();
}