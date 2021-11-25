$('body').on('click', '.btn-add-cart', function () {
    e.preventDefault();
    const id = $(this).data('id');
    $.ajax({
        type: "POST",
        url: '/GioHang/AddGioHang',
        data: {
            id: id,
        },
        success: function (res) {
            alert(OK);
            $('#lbl_number_items_header').text(res.length);
        },
        error: function (err) {
            console.log(err);
        }
    });
})

function loadSanPhamTheoHang() {
    debugger;
    var id = $(this).data('id');
    alert(id);
    $.ajax({
        url: `/get-data-sanpham-theohang/${id}`,
        type: 'GET',
        dataType: 'html',
        success: (result) => {
            $("#loadAllSanPham")[0].innerHTML = result;
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
}
