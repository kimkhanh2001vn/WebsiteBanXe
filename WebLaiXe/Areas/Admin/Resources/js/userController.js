var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/UserAdministrators/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status === true) {
                        btn.html('<span class="label label-success">Actived</span>');
                    }
                    else {
                        btn.html('<span class="label label-danger">Locked</span>');
                    }
                }
            });
        });
    }
};
user.init();