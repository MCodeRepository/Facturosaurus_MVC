$(document).ready(function () {

    $('.modifyButton').click(function () {

        var customerId = $(this).data('item-id');

        $.ajax({
            url: '/Customer/' + customerId,
            type: 'GET',
            data: { id: customerId },
            success: function (result) {
                $('#ModifyCustomerModal input[name="NipNumber"]').val(result.nipNumber);
                $('#ModifyCustomerModal select[name="Active"]').val(result.active.toString());
                $('#ModifyCustomerModal input[name="CustomerName"]').val(result.customerName);
                $('#ModifyCustomerModal input[name="ShortCustomerName"]').val(result.shortCustomerName);
                $('#ModifyCustomerModal input[name="StreetName"]').val(result.streetName);
                $('#ModifyCustomerModal input[name="BildingNumber"]').val(result.bildingNumber);
                $('#ModifyCustomerModal input[name="ApartmentNumber"]').val(result.apartmentNumber);
                $('#ModifyCustomerModal input[name="ZipCode"]').val(result.zipCode);
                $('#ModifyCustomerModal input[name="City"]').val(result.city);
                $('#ModifyCustomerModal input[name="BankName"]').val(result.bankName);
                $('#ModifyCustomerModal select[name="AccountCurrency"]').val(result.accountCurrency.toString());
                $('#ModifyCustomerModal input[name="AccountNumber"]').val(result.accountNumber);
                $('#ModifyCustomerModal input[name="PhoneNumber"]').val(result.phoneNumber);
                $('#ModifyCustomerModal input[name="AddressEmail"]').val(result.addressEmail);
            },
            error: function (xhr, status, error) {
                
                console.error(xhr.responseText);
            }
        });
    });

    $("#ModifyCustomerModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Kontrahent został zmodyfikowany")
                setTimeout(function () {
                    location.reload();
                }, 2000); 
            },
            error: function (jqXHR, textStatus, errorThrown) {
                var response = jqXHR.responseJSON;
                var errorMessage = response && response.NipNumber && response.NipNumber[0] ? response.NipNumber[0] : "Nieznany błąd";

                toastr["error"]("Błąd modyfikacji kontrahenta: " + errorMessage);
            }
        })
    });
});