
$('body').on('click', '.btn-xuly-donhang', function () {
    const id = $(this).data('id');
    $.ajax({
        url: '/DonHang/TienHanhDuyetDonHang',
        data: {
            id: id,

        },
        success: function (data) {
            if (data.code == 1) {
                swal("Thất bại!", "Duyệt đơn thất bại!", "error");

               
            }
            else {
                swal("Thành công!", "Duyệt đơn thành công!", "success");
                location.reload();
            }
        },
        error: function () {
            swal("Thất bại!", "Duyệt đơn thất bại!", "error");
        }
    });
})
function format2(n) {
    return n.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
}