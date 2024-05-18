$(document).ready(function () {
    $('.deleteButton').click(function () {
        var customerId = $(this).data('item-id');

        $.ajax({
            url: '/Customer/' + customerId,
            type: 'DELETE',
            data: { id: customerId },
            success: function (result) {
                toastr["success"]("Kontrahent został usunięty")
                setTimeout(function () {
                    location.reload();
                }, 2000);
            },
            error: function (xhr, status, error) {
                toastr["error"]("Błąd usuwania kontrahenta")
            }
        });
    });
});