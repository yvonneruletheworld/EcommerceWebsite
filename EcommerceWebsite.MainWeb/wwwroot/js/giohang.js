
function layGioHang() {
    $.ajax({
        url: '/get-data-giohang',
        type: 'GET',
        success: (result) => {
            if (result.code == 500) {
                location.href = "/Home/Index";
                Swal.fire({
                    icon: 'error',
                    title: 'Giỏ hàng trống',
                    showConfirmButton: false,
                    timer: 2500
                });
   
            }
            else {
                $("#gioHang")[0].innerHTML = result;
            }
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
}
$('body').on('click', '.btn-add-cart', function () {
    const id = $(this).data('id');
    const giaSP = $("#giaSanPham").val();
    let soLuong = 1;
    if ($("#soLuongThemGH").val() != null) {
        soLuong = $("#soLuongThemGH").val();
    }
    $.ajax({
        url: '/GioHang/AddGioHang',
        data: {
            id: id,
            soLuong: soLuong,
            giaSP: giaSP,
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
            id: id,
          
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
            layGioHang()
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
$('body').on('click', '.btn-sua-gioHang', function () {
    const id = $(this).data('id');
    const soLuong = $("#soLuongGH-"+id+"").val();
    $.ajax({
        url: `/GioHang/suaGioHang`,
        data: {
            id: id,
            soLuong: soLuong,
        },
        success: function (data) {
            Swal.fire({
                icon: 'success',
                title: 'Cập nhật giỏ hàng thành công',
                showConfirmButton: false,
                timer: 2500
            });
            console.log(data.slGH);
            $("#soLuonggh").html(data.slGH);
            layGioHang()
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Cập nhật giỏ hàng thất bại',
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
        type: 'POST',
        url: '/Detail/post-cmt',
        dataType: 'JSON',
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
        error: function (err) {
            Swal.fire({
                icon: 'error',
                title: 'Đã xảy ra lỗi',
                text: 'Vui lòng thử lại',
                showConfirmButton: false,
                timer: 2500
            });
            console.log(err);
        }
    });
})
function layThanhToan() {
    $.ajax({
        url: '/get-data-thanhtoan',
        type: 'GET',
        success: (result) => {
            if (result.code == 500) {
                location.href = "/KhachHang/client-login";
                Swal.fire({
                    icon: 'error',
                    title: 'Vui lòng bạn đăng nhập',
                    showConfirmButton: false,
                    timer: 2500
                });
            }
            else {
                $("#gioHang")[0].innerHTML = result;
            }
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
}
///KHÁCH HÀNG
function danhSachDiaChiKH() {
    $('#dsDiaChi').modal('show');
    layDiaChiKH();
}
function layDiaChiKH() {
    $.ajax({
        url: '/get-data-diachikhachhang',
        type: 'GET',
        success: (result) => {
           $("#DsDiaChiKH")[0].innerHTML = result;
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
}
//THANH TOÁN
function ThanhToan() {
    const MaDC = $('#maDiaChiKH').val();
    const PtThanhToan = $('#pTThanhToan').val();
    const MaKM = $('#maKhuyenMai').val();
    $.ajax({
        url: '/GioHang/ThanhToan',
        data: {
            MaKM: MaKM,
            MaDC: MaDC,
            PtThanhToan: PtThanhToan,
            type: "ajax"
        },
        success: function (data) {
            Swal.fire({
                icon: 'success',
                title: 'Đặt hàng thành công',
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
}