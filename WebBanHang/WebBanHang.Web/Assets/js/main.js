// giohang 
checkQuantity();

function checkQuantity() {
    var quantityArr = document.getElementsByClassName('quantity');
    for (var i = 0; i < quantityArr.length; ++i) {
        if (quantityArr[i].value == 1) {
            document.getElementsByClassName('decrement')[i].disabled = true;
        } else {
            document.getElementsByClassName('decrement')[i].disabled = false;
        }
    }
}

function changeQuantity(c) {
    var quantityArr = document.getElementsByClassName('quantity');
    var decrementArr = document.getElementsByClassName('decrement');
    var incrementArr = document.getElementsByClassName('increment');
    
    for (var i = 0; i < quantityArr.length; ++i) {
        if (incrementArr[i] == c) {
            quantityArr[i].value = parseInt(quantityArr[i].value) + 1;
            var id = quantityArr[i].getAttribute("data-id");
            var quantity = quantityArr[i].value;
            $.ajax({
                url: "/Cart/Updatecart",
                data: {
                    id: id,
                    quantity: quantity
                },
                type: "POST",
                dataType: "json",
                success: function (response) {
                    if (response.status) {
                        window.location.href = "/Cart";
                    }
                }
            });
        }
        if (decrementArr[i] == c) {
            quantityArr[i].value = parseInt(quantityArr[i].value) - 1;
            var id = quantityArr[i].getAttribute("data-id");
            var quantity = quantityArr[i].value;
            $.ajax({
                url: "/Cart/UpdateCart",
                data: {
                    id: id,
                    quantity: quantity
                },
                type: "POST",
                dataType: "json",
                success: function (response) {
                    if (response.status) {
                        window.location.href = "/Cart";
                    }
                }
            });
        }
    }
    checkQuantity();
}
