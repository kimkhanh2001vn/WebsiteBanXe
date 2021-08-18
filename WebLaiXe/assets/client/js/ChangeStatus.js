var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('td.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
                var btn = $(this);
            var category = $('section.content').data('category');
            var id = btn.data('id');
                $.ajax({
                    url: "/Admin/" + category + "/ChangStatus",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {

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