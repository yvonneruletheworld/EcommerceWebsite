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
            console.log(data.slGH);
            $("#soLuonggh").html(data.slGH);
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
$('body').on('click', '.btn-xoa-gioHang', function () {
    const id = $(this).data('id');
    $.ajax({
        url: `/GioHang/XoaGioHang`,
        data: {
            id: id
        },
        success: function (data) {
            Swal.fire({
                icon: 'success',
                title: 'Xóa giỏ hàng thành công',
                showConfirmButton: false,
                timer: 2500
            });
            console.log(data.slGH);
            $("#soLuonggh").html(data.slGH);
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Xóa giỏ hàng thất bại',
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

$('body').on('click', '.btn-them-yeuthich', function () {
    const id = $(this).data('id');
    $.ajax({
        url: '/YeuThich/ThemSanPhamYeuThich',
        data: {
            id: id,
            type: "ajax"
        },
        success: function (data) {
            if (data.code == 1) {
                Swal.fire({
                    icon: 'error',
                    title: 'Vui lòng đăng nhập',
                    showConfirmButton: false,
                    timer: 2500
                });
            }
            else if (data.code == 2) {
                console.log(data.sl);
                $("#soLuongyt").html(data.sl);
                Swal.fire({
                    icon: 'error',
                    title: 'OKe ',
                    showConfirmButton: false,
                    timer: 2500
                });
               
            }
            else {
                console.log(data.sl);
                $("#soLuongyt").html(data.sl);
                Swal.fire({
                    icon: 'success',
                    title: 'Thêm sản phẩm yêu thích thành công',
                    showConfirmButton: false,
                    timer: 2500
                });
               
            }
           
           
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
$('body').on('click', '.btn-them-binhluan', function () {

    //const sp = {};
    var fd = new FormData();
    //sp.id = $(this).data('id');
    //sp.NoiDung = $('#noiDung').val();
    //sp.soSao = $('#soSao').val();
    if (!model.khachHang) {
        var _pass = $("#pass-feedback-id").val();
        var _email = $("#email-feedback-id").val();

        fd.append('MatKhau', _pass);
        fd.append('Email', _email);
    }
    var _masp = $(this).data('id');
    var _nodung = $('#noiDung').val();
    var _sosao = $('#soSao').val();
    fd.append('SoSao', _sosao);
    fd.append('NoiDung', _nodung);
    fd.append('MaSanPham', _masp);
    $.ajax({
        url: '/Detail/ThemBinhLuan',
        data: fd,
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        success: function (data) {
            if (data.code == 1) {
                Swal.fire({
                    icon: 'error',
                    title: 'Vui lòng đăng nhập',
                    showConfirmButton: false,
                    timer: 2500
                });
            }
            else if (data.code == 2) {
                Swal.fire({
                    icon: 'error',
                    title: 'Vui lòng kiểm tra lại',
                    showConfirmButton: false,
                    timer: 2500
                });
            }
            else {
                Swal.fire({
                    icon: 'success',
                    title: 'Bình luận thành công',
                    showConfirmButton: false,
                    timer: 2500
                });
                $('#mymodal').modal('hide');
            }
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Bình luận thất bại',
                text: 'Vui lòng thử lại',
                showConfirmButton: false,
                timer: 2500
            });
        }
    });
})
