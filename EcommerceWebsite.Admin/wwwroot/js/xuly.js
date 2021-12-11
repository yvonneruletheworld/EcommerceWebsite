
$('body').on('click', '.btn-xuly-donhang', function () {
    const id = $(this).data('id');
    $.ajax({
        url: '/DonHang/TienHanhDuyetDonHang',
        data: {
            id: id,

        },
        success: function (data) {
            if (data.code == 1) {
                Swal.fire({
                    icon: 'error',
                    title: 'Duyệt đơn thất bại',
                    text: 'Vui lòng thử lại',
                    showConfirmButton: false,
                    timer: 2500
                });
            }
            else {
                Swal.fire({
                    icon: 'success',
                    title: 'Duyệt đơn thành công',
                    showConfirmButton: false,
                    timer: 2500
                });
            }
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Duyệt đơn thất bại',
                text: 'Vui lòng thử lại',
                showConfirmButton: false,
                timer: 2500
            });
        }
    });
})