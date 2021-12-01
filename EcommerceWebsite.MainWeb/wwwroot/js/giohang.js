$('body').on('click', '.btn-add-cart', function () {
    const id = $(this).data('id');
    $.ajax({
        url: '/GioHang/AddGioHang',
        data: {
            id: id,
            soLuong: 1,
            type: "ajax"
        },
        success: function (data) {
            Swal.fire({
                icon: 'success',
                title: 'Thêm giỏ hàng thành công',
                showConfirmButton: false,
                timer: 2500
            });
            console.log(data.soLuong);
            $("#soLuongGioHang").html(data.soLuong);
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Thêm giỏ hàng thất bại',
                text: 'Vui lòng thử lại',
                showConfirmButton: false,
                timer: 2500
            });
        }
    });
})

$('body').on('click', '.btn-hienthisanpham-hang', function () {
    var id = $(this).data('id');
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
})
    $('body').on('click', '.btn-hienthisanpham-loai', function () {
        var id = $(this).data('id');
        $.ajax({
            url: `/get-data-sanpham-loai/${id}`,
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
    })
$('body').on('click', '.btn-timkiem', function () {
    var id = $('#keyword').val();
    $.ajax({
        url: `/timKiemsanPham/${id}`,
        type: 'GET',
        dataType: 'html',
        success: (result) => {
            
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
})