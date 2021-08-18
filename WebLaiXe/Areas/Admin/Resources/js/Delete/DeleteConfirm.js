var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.Delete').on('click', function (e) {
            swal({
                title: "Bạn có chắc không?",
                text: "Sau khi xóa, bạn sẽ không thể khôi phục nội dung này!",
                icon: "warning",
                buttons: true,
                dangerMode: true
            })
                .then((willDelete) => {
                    if (willDelete) {
                        //e.preventDefault();
                        var btn = $(this);
                        var id = btn.data('id');
                        var category = $('section.content').data('category');
                        /*DELETE*/
                        $.ajax({
                            type: "POST",
                            url: "/Admin/" + category + "/DeleteConfirmed",
                            data: JSON.stringify({ ID: id, CATEGORY: category }),
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            success: function (json) {
                                swal("Đã xóa thành công nội dung này!", {
                                    icon: "success"
                                });
                                if (json.isRedirect) {
                                    window.setTimeout(function () {
                                        window.location.href = json.redirectUrl;                                        
                                    }, 1300);
                                }
                            },
                            error: function () {
                                swal("Xảy ra lỗi trong quá trình xóa!");
                            }
                        });
                    } 
                });
        });

    
    }
};
user.init();