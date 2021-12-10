



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
    const giaSP = $("#giaSanPham-"+id).val();
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
                location.href = "/CuaHang/Index";
                $("#soLuongyt").html(data.sl);
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
//$('body').on('click', '.btn-them-binhluan', function () {

//    //const sp = {};
//    var fd = new FormData();
//    //sp.id = $(this).data('id');
//    //sp.NoiDung = $('#noiDung').val();
//    //sp.soSao = $('#soSao').val();
//    if (!model.khachHang) {
//        var _pass = $("#pass-feedback-id").val();
//        var _email = $("#email-feedback-id").val();

//        fd.append('MatKhau', _pass);
//        fd.append('Email', _email);
//    }
//    var _masp = $(this).data('id');
//    var _nodung = $('#noiDung').val();
//    var _sosao = $('#soSao').val();
//    fd.append('SoSao', _sosao);
//    fd.append('NoiDung', _nodung);
//    fd.append('MaSanPham', _masp);
//    $.ajax({
//        type: 'POST',
//        url: '/Detail/post-cmt',
//        dataType: 'JSON',
//        data: fd,
//        contentType: false, // Not to set any content header
//        processData: false, // Not to process data
//        success: function (data) {
//            if (data.code == 1) {
//                Swal.fire({
//                    icon: 'error',
//                    title: 'Vui lòng đăng nhập',
//                    showConfirmButton: false,
//                    timer: 2500
//                });
//            }
//            else if (data.code == 2) {
//                Swal.fire({
//                    icon: 'error',
//                    title: 'Vui lòng kiểm tra lại',
//                    showConfirmButton: false,
//                    timer: 2500
//                });
//            }
//            else {
//                Swal.fire({
//                    icon: 'success',
//                    title: 'Bình luận thành công',
//                    showConfirmButton: false,
//                    timer: 2500
//                });
//                $('#mymodal').modal('hide');
//            }
//        },
//        error: function (err) {
//            Swal.fire({
//                icon: 'error',
//                title: 'Đã xảy ra lỗi',
//                text: 'Vui lòng thử lại',
//                showConfirmButton: false,
//                timer: 2500
//            });
//            console.log(err);
//        }
//    });
//})

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
    const TongTien = $('#tongTienKhuyenMai').text();
    const ThanhTien = $('#thanhTienHang').text();
    const PhiShip = $('#phiShip').text();
    $.ajax({
        url: '/GioHang/ThanhToan',
        data: {
            MaKM: MaKM,
            MaDC: MaDC,
            TongTien: TongTien,
            ThanhTien: ThanhTien,
            PhiShip: PhiShip,
            PtThanhToan: PtThanhToan,
            type: "ajax"
        },
        success: function (data) {
            location.href = "/Home/Index";
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
///Hiện thi gio hàng Mini
function layGioHangMini() {
    $.ajax({
        url: '/get-data-minigiohang',
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
                $(".minicart")[0].innerHTML = result;
            }
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
}
//Khuyến mãi
function danhSachKhuyenMai() {
    $('#dsKhuyenMai').modal('show');
    layKhuyenMai();
}
function layKhuyenMai() {
    $.ajax({
        url: '/get-data-khuyenmaigiohang',
        type: 'GET',
        success: (result) => {
            $("#danhSachKhuyenMai")[0].innerHTML = result;
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
}
$('body').on('click', '.layChiTietKhuyenMai', function () {
    var maKM = $(this).data('id');
    $.ajax({
        url: `/get-data-chitietkhuyenmai/${maKM}`,
        type: 'GET',
        success: (result) => {
            $("#CTKhuyemMai")[0].innerHTML = result;
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
});
//Áp dụng khuyến mãi
function format2(n) {
    return n.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
}
function  ApDungKhuyenMai() {
    var maKM = $('#maKhuyenMaiCT').val();
    $('#maKhuyenMai').val(maKM);
    $('#dsKhuyenMai').modal('hide');
    var tienGiamGia = parseFloat($('#tienGiam').val());
    var tienGiamGia2 = format2(tienGiamGia).split(".")[0];

    var TongTien = parseFloat($('#tienTongTien').val());
    
    var TongTien2 = format2(TongTien).split(".")[0];
    console.log(TongTien2);
    var TienTra = parseFloat($('#tienPhaiTra').val());
   
    var TienTra2 = format2(TienTra).split(".")[0];
    console.log(TienTra2);
    $('#tienTruocDo').text(TongTien2 + " VNĐ ");
    $('#tongTienKhuyenMai').text(TienTra2 );
    console.log(format2(tienGiamGia));
    var html = `<th >Giảm giá</th>
                 <td><span class="amount">${tienGiamGia2} VNĐ</span></td>`;
    $(".tienGiam").html(html);
}
//Sản phẩm mới nhât
function sanPhamMoiNhat() {
    
    $.ajax({
        url: '/get-data-laySanPhamMoiNhat',
        type: 'GET',
        success: (result) => {
            $("#loadAllSanPham")[0].innerHTML = result;
        },
        error: (err) => {
            alert('failed');
            console.log(err);
        }
    });
}