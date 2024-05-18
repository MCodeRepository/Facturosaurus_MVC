
$(document).ready(function() {
  $("#CreateNewCustomerModal form").submit(function (event) {
    event.preventDefault();

    $.ajax({
      url: $(this).attr('action'),
      type: $(this).attr('method'),
      data: $(this).serialize(),
      success: function (data) {
          toastr["success"]("Kontrahent został utworzony")
          setTimeout(function () {
              location.reload();
          }, 2000);
      },
        error: function (jqXHR, textStatus, errorThrown) {
            var response = jqXHR.responseJSON;
            var errorMessage = response && response.NipNumber && response.NipNumber[0] ? response.NipNumber[0] : "Nieznany błąd";

            toastr["error"]("Błąd tworzenia kontrahenta: " + errorMessage);
      }
    })
  });
});

