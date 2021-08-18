var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/Cart/PayMent";
        });   

        $('#btnUpdate').off('click').on('click', function () {
            var listCar = $('.txtquantity');
            var CartList = [];
            $.each(listCar, function (i, item) {
                CartList.push({
                    Quantity: $(item).val(),
                    Car: {
                        ID: $(item).data('id')
                    }
                })
            });
            $.ajax({
                url: 'Cart/Update',
                data: {
                    cartModel: JSON.stringify(CartList)
                },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            });
        });
       
        $('#btnRemoveAll').off('click').on('click', function () {
            $.ajax({
                url: 'Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        })
        $('.btn-delete').off('click').on('click', function () {
            $.ajax({
                data: { id: $(this).data('id') },
                url: 'Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            });
        });
        
        //truyen vao e e.preventDefault xu ly # cua the a
    }
}
cart.init();